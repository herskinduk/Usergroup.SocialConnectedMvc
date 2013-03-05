using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Website.Abstractions.Globalisation;
using Website.Abstractions.Mvc.Presentation;
using Website.Abstractions.Security.Authentication;
using Website.Configuration.SocialConnected;

namespace Website.Controllers
{
    public class SocialConnectedRenderingController : Controller
    {
        private readonly ITranslate _translate;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IPageContext _pageContext;
        private readonly IRenderingContext _renderingContext;
        private readonly SocialConnectedSettings _settings;
        private const string NETWORK_NAME = "NetworkName";

        public SocialConnectedRenderingController()
            : this(
                new SocialConnectedSettingsProvider().GetSettings(),
                new PageContextWrapper(PageContext.CurrentOrNull ?? new PageContext()),
                new RenderingContextWrapper(RenderingContext.CurrentOrNull ?? new RenderingContext()),
                new AuthenticationManagerWrapper(),
                new TranslateWrapper())
        {

        }

        public SocialConnectedRenderingController(
            SocialConnectedSettings settings,
            IPageContext pageContext,
            IRenderingContext renderingContext,
            IAuthenticationManager authenticationManager,
            ITranslate translate)
        {
            _settings = settings;
            _pageContext = pageContext;
            _renderingContext = renderingContext;
            _authenticationManager = authenticationManager;
            _translate = translate;
        }

        // ControllerRendering action
        public ActionResult TwitterTweet()
        {
            ViewBag.ItemId = _pageContext.Item.ID.ToString();
            ViewBag.EventUrl = _settings.EventUrl;
            ViewBag.EventName = _settings.EventName; 
            ViewBag.GoalName = _settings.GoalName;
            ViewBag.CampaignQueryString = _settings.CampaignQueryString;
            ViewBag.SharePageUrl = _settings.SharePageUrl;

            return View();
        }

        // ControllerRendering action
        public ActionResult FacebookLike()
        {
            ViewBag.CampaignQueryString = _settings.CampaignQueryString;

            return View();
        }

        public ActionResult GenericConnector()
        {
            var rendering = _renderingContext.Rendering;
            
            // Fix
            var networkName = rendering.Parameters[NETWORK_NAME];
            var networkDisplayName = rendering.Parameters[NETWORK_NAME];
            var isAuthenticated = _authenticationManager.GetActiveUser().IsAuthenticated;
            
            var model = new Models.SocialConnectConnector()
            {
                NetworkName = networkName,
                NetworkDisplayName = networkDisplayName,
                IsAuthenticated = isAuthenticated,
                LoginText = _translate.Text(string.Format(isAuthenticated ? "Attach {0} account" : "Login with {0}", networkDisplayName))
            };

            return View(model);
        }
    }
}
