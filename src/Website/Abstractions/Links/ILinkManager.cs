using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Abstractions.Links
{
    public interface ILinkManager
    {
        //bool AddAspxExtension { get; }
        //bool AlwaysIncludeServerUrl { get; internal set; }
        //LanguageEmbedding LanguageEmbedding { get; }
        //LanguageLocation LanguageLocation { get; }
        //bool LowercaseUrls { get; }
        //LinkProvider Provider { get; }
        //LinkProviderCollection Providers { get; }
        //bool ShortenUrls { get; }
        //bool UseDisplayName { get; }

        //string ExpandDynamicLinks(string text);
        //string ExpandDynamicLinks(string text, bool resolveSites);
        UrlOptions GetDefaultUrlOptions();
        //string GetDynamicUrl(Item item);
        //string GetDynamicUrl(Item item, LinkUrlOptions options);
        string GetItemUrl(Item item);
        string GetItemUrl(Item item, UrlOptions options);
        //bool IsDynamicLink(string linkText);
        //DynamicLink ParseDynamicLink(string linkText);
        //RequestUrl ParseRequestUrl(HttpRequest request);

    }
}
