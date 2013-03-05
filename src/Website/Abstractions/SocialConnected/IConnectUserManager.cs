using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Abstractions.SocialConnected
{
    public interface IConnectUserManager
    {
        void AttachUser(string networkName, bool isAsyncProfileUpdate, string appId);
        void LoginUser(string networkName, bool isAsyncProfileUpdate, string appId);
    }
}
