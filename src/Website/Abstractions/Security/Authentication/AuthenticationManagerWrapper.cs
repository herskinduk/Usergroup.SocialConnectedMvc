using Sitecore.Security.Accounts;
using Sitecore.Security.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Abstractions.Security.Authentication
{
    public class AuthenticationManagerWrapper : IAuthenticationManager
    {
        public User BuildVirtualUser(string userName, bool isAuthenticated)
        {
            return AuthenticationManager.BuildVirtualUser(userName, isAuthenticated);
        }

        public bool CheckLegacyPassword(User user, string password)
        {
            return AuthenticationManager.CheckLegacyPassword(user, password);
        }

        public User GetActiveUser()
        {
            return AuthenticationManager.GetActiveUser();
        }

        public bool Login(string userName)
        {
            return AuthenticationManager.Login(userName);
        }

        public bool Login(User user)
        {
            return AuthenticationManager.Login(user);
        }

        public bool Login(string userName, bool persistent)
        {
            return AuthenticationManager.Login(userName, persistent);
        }

        public bool Login(string userName, string password)
        {
            return AuthenticationManager.Login(userName, password);
        }

        public bool Login(string userName, string password, bool persistent)
        {
            return AuthenticationManager.Login(userName, password, persistent);
        }

        public bool LoginVirtualUser(User user)
        {
            return AuthenticationManager.LoginVirtualUser(user);
        }

        public void Logout()
        {
            AuthenticationManager.Logout(); ;
        }

        public void SetActiveUser(string userName)
        {
            AuthenticationManager.SetActiveUser(userName);
        }

        public void SetActiveUser(User user)
        {
            AuthenticationManager.SetActiveUser(user);
        }
    }
}