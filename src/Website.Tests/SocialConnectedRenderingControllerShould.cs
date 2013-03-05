using FakeItEasy;
using Sitecore.Data.Items;
using Sitecore.Security.Accounts;
using System.Web.Mvc;
using Website.Abstractions.Globalisation;
using Website.Abstractions.Links;
using Website.Abstractions.Mvc.Presentation;
using Website.Abstractions.Security.Authentication;
using Website.Configuration.SocialConnected;
using Website.Controllers;
using Xunit;

namespace Website.Tests
{
    public class SocialConnectedRenderingControllerShould
    {
        private readonly SocialConnectedSettings settings = new SocialConnectedSettings() 
        {
            CampaignQueryString = "/TestCampaignQueryString.aspx",
            GoalName = "TestGoal",
            EventName = "TestEvent",
            EventUrl = "/TestEventUrl.aspx",
            SharePageUrl = "/TestSharePageUrl.aspx?parameter1=1"
        };

        private readonly IAuthenticationManager authenticationManager = A.Fake<IAuthenticationManager>();
        private readonly ITranslate translate = A.Fake<ITranslate>();
        private readonly ILinkManager linkManager = A.Fake<ILinkManager>();
        private readonly IPageContext pageContext = A.Fake<IPageContext>();
        private readonly IRenderingContext renderingContext = A.Fake<IRenderingContext>();
        private readonly SocialConnectedRenderingController controller;
        
        public SocialConnectedRenderingControllerShould()
        {
            controller = new SocialConnectedRenderingController(
                settings,
                pageContext,
                renderingContext,
                authenticationManager,
                translate);

            A.CallTo(() => translate.Text(A<string>.Ignored))
                .ReturnsLazily((string translationText) => translationText);
        }

        [Fact]
        public void GenericConnectorShouldReturnViewResult()
        {
            //Arrange
            var rendering = new Sitecore.Mvc.Presentation.Rendering();
            rendering.Parameters["NetworkName"] = "SocialNetworkName";
            A.CallTo(() => renderingContext.Rendering)
                .Returns<Sitecore.Mvc.Presentation.Rendering>(rendering);

            var user = new TestUser(true);
            A.CallTo(() => authenticationManager.GetActiveUser())
                .Returns<User>(user);

            //Act
            var result = controller.GenericConnector() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TwitterTweetShouldReturnViewResult()
        {
            //Arrange
            var rendering = new Sitecore.Mvc.Presentation.Rendering();
            rendering.Parameters["NetworkName"] = "SocialNetworkName";
            A.CallTo(() => renderingContext.Rendering)
                .Returns<Sitecore.Mvc.Presentation.Rendering>(rendering);

            var user = new TestUser(true);
            A.CallTo(() => authenticationManager.GetActiveUser())
                .Returns<User>(user);

            A.CallTo(() => pageContext.Item)
                .Returns(new TestItem());

            //Act
            var result = controller.TwitterTweet() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TwitterTweetShouldPopulateViewbag()
        {
            //Arrange
            var rendering = new Sitecore.Mvc.Presentation.Rendering();
            rendering.Parameters["NetworkName"] = "SocialNetworkName";
            A.CallTo(() => renderingContext.Rendering)
                .Returns<Sitecore.Mvc.Presentation.Rendering>(rendering);

            var user = new TestUser(true);
            A.CallTo(() => authenticationManager.GetActiveUser())
                .Returns<User>(user);

            var testItem = new TestItem();
            A.CallTo(() => pageContext.Item)
                .Returns(testItem);

            //Act
            var result = controller.TwitterTweet() as ViewResult;

            //Assert
            Assert.NotNull(result.ViewBag.ItemId);
            Assert.NotNull(result.ViewBag.EventName);
            Assert.NotNull(result.ViewBag.EventUrl); ;
            Assert.NotNull(result.ViewBag.GoalName);
            Assert.NotNull(result.ViewBag.CampaignQueryString);
            Assert.NotNull(result.ViewBag.SharePageUrl);
        }

        public void FacebookLikeShouldReturnViewResult()
        {
            //Arrange
            var rendering = new Sitecore.Mvc.Presentation.Rendering();
            rendering.Parameters["NetworkName"] = "SocialNetworkName";
            A.CallTo(() => renderingContext.Rendering)
                .Returns<Sitecore.Mvc.Presentation.Rendering>(rendering);

            var user = new TestUser(true);
            A.CallTo(() => authenticationManager.GetActiveUser()).Returns<User>(user);

            A.CallTo(() => linkManager.GetDefaultUrlOptions())
                .Returns(new Sitecore.Links.UrlOptions());
            A.CallTo(() => linkManager.GetItemUrl(A<Item>.Ignored))
                .Returns("http://host/path");

            A.CallTo(() => pageContext.Item)
                .Returns(new TestItem());


            //Act
            var result = controller.FacebookLike() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

    }

}
