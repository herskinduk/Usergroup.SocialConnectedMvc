using FakeItEasy;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Specialized;
using System.Web;
using Website.Abstractions.Data;
using Website.Abstractions.Links;
using Website.Abstractions.Mvc.Presentation;
using Website.Configuration.SocialConnected;
using Xunit;

namespace Website.Tests
{
    public class SocialConnectedSettingsProviderShould
    {
        private readonly ILinkManager _linkManager = A.Fake<ILinkManager>();
        private readonly IPageContext _pageContext = A.Fake<IPageContext>();
        private readonly IRenderingContext _renderingContext = A.Fake<IRenderingContext>();
        private readonly IDatabase _database = A.Fake<IDatabase>();
        private readonly SocialConnectedSettingsProvider _settingsProvider;

        public SocialConnectedSettingsProviderShould()
        {
            _settingsProvider = new SocialConnectedSettingsProvider(
                _linkManager,
                _pageContext,
                _renderingContext,
                _database);

            A.CallTo(() => _linkManager.GetDefaultUrlOptions())
                .Returns(new Sitecore.Links.UrlOptions());

            var database = A.Fake<IDatabase>();
            A.CallTo(database).WithReturnType<Item>().Returns(new TestItem());
        }

        [Fact]
        public void GetSettingsShouldGenerateValidCampaingUrl()
        {
            // Arrange
            A.CallTo(() => _linkManager.GetItemUrl(A<Item>.Ignored, A<UrlOptions>.Ignored))
                .Returns("http://host/path?sneaky=parameter");

            A.CallTo(() => _pageContext.Item)
                .Returns(new TestItem());

            var rendering = new Sitecore.Mvc.Presentation.Rendering();
            rendering.Parameters["Goal"] = "TestGoal";
            rendering.Parameters["EventName"] = "TestEvent";
            rendering.Parameters["Campaign"] = ID.NewID.ToString();
            A.CallTo(() => _renderingContext.Rendering)
                .Returns<Sitecore.Mvc.Presentation.Rendering>(rendering);

            // Act
            var settings = _settingsProvider.GetSettings();

            // Assert
            Assert.True(Uri.IsWellFormedUriString(settings.CampaignQueryString, UriKind.RelativeOrAbsolute));
        }

        [Fact]
        public void GetSettingsShouldGenerateCampaingUrlWithScCampParameter()
        {
            // Arrange
            A.CallTo(() => _linkManager.GetItemUrl(A<Item>.Ignored, A<UrlOptions>.Ignored))
                .Returns("http://host/path?sneaky=parameter");

            A.CallTo(() => _pageContext.Item)
                .Returns(new TestItem());

            var rendering = new Sitecore.Mvc.Presentation.Rendering();
            rendering.Parameters["Goal"] = "TestGoal";
            rendering.Parameters["EventName"] = "TestEvent";
            var campaignId = ID.NewID;
            rendering.Parameters["Campaign"] = campaignId.ToString();
            A.CallTo(() => _renderingContext.Rendering)
                .Returns<Sitecore.Mvc.Presentation.Rendering>(rendering);

            // Act
            var settings = _settingsProvider.GetSettings();

            NameValueCollection query = null;
            Uri uri = null;
            if (Uri.TryCreate(settings.CampaignQueryString, UriKind.RelativeOrAbsolute, out uri))
            {
                query = HttpUtility.ParseQueryString(uri.Query);
            }

            // Assert
            Assert.NotNull(uri);
            Assert.NotNull(query);
            Assert.Contains<string>("sc_camp", query.AllKeys);
            Assert.True(ShortID.IsShortID(query["sc_camp"]), "sc_camp must be a ShortID");
            Assert.Equal<ID>(ShortID.Parse(query["sc_camp"]).ToID(), campaignId);
        }
    }
}
