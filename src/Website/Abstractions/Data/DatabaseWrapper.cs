using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Website.Abstractions.Data
{
    public class DatabaseWrapper : IDatabase
    {
        private readonly Database _database;

        public DatabaseWrapper(Database database)
        {
            _database = database;
        }

        public Item GetItem(string path)
        {
            return _database.GetItem(path);
        }
    }
}