using Sitecore.Security.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Abstractions.Security.Authentication
{
    public interface IAuthenticationManager
    {
        User BuildVirtualUser(string userName, bool isAuthenticated);
        bool CheckLegacyPassword(User user, string password);
        User GetActiveUser();
        bool Login(string userName);
        bool Login(User user);
        bool Login(string userName, bool persistent);
        bool Login(string userName, string password);
        bool Login(string userName, string password, bool persistent);
        bool LoginVirtualUser(User user);
        void Logout();
        void SetActiveUser(string userName);
        void SetActiveUser(User user);
    }
}
