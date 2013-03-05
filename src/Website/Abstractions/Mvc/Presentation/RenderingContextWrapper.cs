using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.Mvc.Presentation
{
    public class RenderingContextWrapper : IRenderingContext
    {
        private readonly RenderingContext _renderingContext;

        public RenderingContextWrapper(RenderingContext renderingContext)
        {
            if (renderingContext == null)
                throw new ArgumentNullException("renderingContext");

            _renderingContext = renderingContext;
        }

        public Sitecore.Data.Items.Item ContextItem
        {
            get { return _renderingContext.ContextItem; }
        }

        public Sitecore.Mvc.Presentation.Rendering Rendering
        {
            get { return _renderingContext.Rendering; }
        }
    }
}