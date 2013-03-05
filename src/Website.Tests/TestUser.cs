using Sitecore.Security.Accounts;

namespace Website.Tests
{
    public class TestUser : User
    {
        public TestUser(bool isAuthenticated)
            : base("test\\test", isAuthenticated)
        {
        }
    }
}
