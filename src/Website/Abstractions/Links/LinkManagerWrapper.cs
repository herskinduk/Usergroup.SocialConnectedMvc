using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.Links
{
    public class LinkManagerWrapper : ILinkManager
    {
        public Sitecore.Links.UrlOptions GetDefaultUrlOptions()
        {
            return LinkManager.GetDefaultUrlOptions();
        }

        public string GetItemUrl(Sitecore.Data.Items.Item item)
        {
            return LinkManager.GetItemUrl(item);
        }

        public string GetItemUrl(Sitecore.Data.Items.Item item, Sitecore.Links.UrlOptions options)
        {
            return LinkManager.GetItemUrl(item, options);
        }
    }
}