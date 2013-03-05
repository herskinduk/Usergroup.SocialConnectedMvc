using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.Mvc.Presentation
{
    public interface IRenderingContext
    {
        Item ContextItem { get; }
        Rendering Rendering { get; }
    }
}