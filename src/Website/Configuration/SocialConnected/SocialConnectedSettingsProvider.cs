using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using Website.Abstractions.Data;
using Website.Abstractions.Links;
using Website.Abstractions.Mvc.Presentation;

namespace Website.Configuration.SocialConnected
{
    public class SocialConnectedSettingsProvider
    {
        private readonly ILinkManager _linkManager;
        private readonly IPageContext _pageContext;
        private readonly IRenderingContext _renderingContext;
        private readonly IDatabase _database;

        public SocialConnectedSettingsProvider()
            : this(
                new LinkManagerWrapper(),
                new PageContextWrapper(PageContext.CurrentOrNull ?? new PageContext()),
                new RenderingContextWrapper(RenderingContext.CurrentOrNull ?? new RenderingContext()),
                null)
        {
            _database = new DatabaseWrapper(_pageContext.Database);
        }

        public SocialConnectedSettingsProvider(
            ILinkManager linkManager,
            IPageContext pageContext,
            IRenderingContext renderingContext,
            IDatabase database)
        {
            _linkManager = linkManager;
            _pageContext = pageContext;
            _renderingContext = renderingContext;
            _database = database;
        }

        public SocialConnectedSettings GetSettings()
        {
            return new SocialConnectedSettings()
            {
                EventUrl = "/layouts/system/Social/Sharing/SocialEvents.aspx",
                GoalName = Settings.GetSetting("Social.DefaultTweetGoal"),
                EventName = GetEventName(),
                CampaignQueryString = GetCampaignQueryString(),
                SharePageUrl = GetSharePageUrl()
            };
        }

        private ID GetCamapignId()
        {
            string str = string.Empty;
            var rendering = _renderingContext.Rendering;
            if (rendering.Parameters["Campaign"] != null)
            {
                str = rendering.Parameters["Campaign"];
            }

            if (ID.IsID(str))
            {
                return ID.Parse(str);
            }
            return ID.Null;
        }

        protected string GetEventName()
        {
            string str = string.Empty;
            var rendering = _renderingContext.Rendering;
            if (rendering.Parameters["Goal"] != null)
            {
                var item = _database.GetItem(rendering.Parameters["Goal"]);
                if (item != null)
                    str = item.Name;
            }

            return str;
        }

        protected string GetSharePageUrl()
        {
            var options = _linkManager.GetDefaultUrlOptions();
            options.AlwaysIncludeServerUrl = true;
            return _linkManager.GetItemUrl(_pageContext.Item, options);
        }

        protected string GetCampaignQueryString()
        {
            var options = _linkManager.GetDefaultUrlOptions();
            options.AlwaysIncludeServerUrl = true;
            string itemUrl = _linkManager.GetItemUrl(_pageContext.Item, options);

            var urlString = new Sitecore.Text.UrlString(itemUrl);
            var campaignId = GetCamapignId();
            if (!campaignId.IsNull)
            {
                urlString.Add("sc_camp", campaignId.ToShortID().ToString());
            }

            return urlString.GetUrl();
        }

    }
}