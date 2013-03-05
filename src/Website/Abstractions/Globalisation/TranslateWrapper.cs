using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.Globalisation
{
    public class TranslateWrapper : ITranslate
    {
        public bool HasPendingReloads
        {
            get { return Translate.HasPendingReloads; }
        }

        public void CachePhrase(string key, string phrase, Sitecore.Globalization.Language language, Sitecore.Globalization.DictionaryDomain domain)
        {
            Translate.CachePhrase(key, phrase, language, domain);
        }

        public System.Xml.Linq.XDocument CreateDictionary(Type type)
        {
            return Translate.CreateDictionary(type);
        }

        public Sitecore.Globalization.DictionaryDomain[] GetCachedDomains()
        {
            return Translate.GetCachedDomains();
        }

        public Sitecore.Globalization.Language[] GetCachedLanguages(Sitecore.Globalization.DictionaryDomain domain)
        {
            return Translate.GetCachedLanguages(domain);
        }

        public void ReloadDomainCache(Sitecore.Globalization.DictionaryDomain domain)
        {
            Translate.ReloadDomainCache(domain);
        }

        public void ReloadFromDatabase()
        {
            Translate.ReloadFromDatabase();
        }

        public void RemoveKeyFromCache(string key)
        {
            Translate.RemoveKeyFromCache(key);
        }

        public void RemoveKeyFromCache(string key, Sitecore.Globalization.Language language)
        {
            Translate.RemoveKeyFromCache(key, language);
        }

        public void RemoveKeyFromCache(string key, Sitecore.Globalization.Language language, Sitecore.Globalization.DictionaryDomain domain)
        {
            Translate.RemoveKeyFromCache(key, language, domain);
        }

        public void ResetCache()
        {
            Translate.ResetCache();
        }

        public void ResetCache(bool removeFileCache)
        {
            Translate.ResetCache(removeFileCache);
        }

        public string Text(string key)
        {
            return Translate.Text(key);
        }

        public string Text(string key, params object[] parameters)
        {
            return Translate.Text(key, parameters);
        }

        public string TextByDomain(string domain, string key, params object[] parameters)
        {
            return Translate.TextByDomain(domain, key, parameters);
        }

        public string TextByDomain(string domain, Sitecore.Globalization.TranslateOptions options, string key, params object[] parameters)
        {
            return Translate.TextByDomain(domain, options, key, parameters);
        }

        public string TextByLanguage(string key, Sitecore.Globalization.Language language)
        {
            return Translate.TextByLanguage(key, language);
        }

        public string TextByLanguage(string key, Sitecore.Globalization.Language language, string defaultValue)
        {
            return Translate.TextByLanguage(key, language, defaultValue);
        }

        public string TextByLanguage(string key, Sitecore.Globalization.Language language, string defaultValue, params object[] parameters)
        {
            return Translate.TextByLanguage(key, language, defaultValue, parameters);
        }

        public string TextByLanguage(string domainName, Sitecore.Globalization.TranslateOptions options, string key, Sitecore.Globalization.Language language, string defaultValue, params object[] parameters)
        {
            return Translate.TextByLanguage(domainName, options, key, language, defaultValue, parameters);
        }
    }
}