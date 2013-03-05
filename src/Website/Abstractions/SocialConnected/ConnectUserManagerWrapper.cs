using Sitecore.Social.Core.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.SocialConnected
{
    public class ConnectUserManagerWrapper : IConnectUserManager
    {
        private readonly ConnectUserManager _connectUserManager;

        public ConnectUserManagerWrapper()
        {
            _connectUserManager = new ConnectUserManager();
        }

        public void AttachUser(string networkName, bool isAsyncProfileUpdate, string appId = null)
        {
            _connectUserManager.AttachUser(networkName, isAsyncProfileUpdate, appId);
        }

        public void LoginUser(string networkName, bool isAsyncProfileUpdate, string appId = null)
        {
            _connectUserManager.AttachUser(networkName, isAsyncProfileUpdate, appId);
        }
    }
}