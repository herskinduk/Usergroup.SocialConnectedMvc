using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.Data
{
    public interface IDatabase
    {
        Item GetItem(string path);
    }
}