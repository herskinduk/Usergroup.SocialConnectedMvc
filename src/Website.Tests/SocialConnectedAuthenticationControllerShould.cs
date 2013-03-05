using FakeItEasy;
using Sitecore.Security.Accounts;
using System;
using System.Web.Mvc;
using Website.Abstractions.Security.Authentication;
using Website.Abstractions.SocialConnected;
using Website.Controllers;
using Xunit;

namespace Website.Tests
{
    public class SocialConnectedAuthenticationControllerShould : IDisposable
    {
        private readonly string networkName = "socialnetwork";
        private readonly IAuthenticationManager authenticationManager = A.Fake<IAuthenticationManager>();
        private readonly IConnectUserManager connectUserManager = A.Fake<IConnectUserManager>();

        public SocialConnectedAuthenticationControllerShould()
        {
        }

        [Fact]
        public void LoginShouldLoginUserWhenNotAuthenticated()
        {
            // Arrange
            var isAuthenticated = false;
            var controller = new SocialConnectedAuthenticationController(authenticationManager, connectUserManager);
            A.CallTo(() => authenticationManager.GetActiveUser())
                .Returns<User>(new TestUser(isAuthenticated));
            
            // Act
            controller.Login(networkName);

            // Assert
            A.CallTo(() => connectUserManager.LoginUser(networkName, true, null))
                .MustHaveHappened();
        }

        [Fact]
        public void LoginShouldAttachUserWhenAuthenticated()
        {
            // Arrange
            var isAuthenticated = true;
            var controller = new SocialConnectedAuthenticationController(authenticationManager, connectUserManager);
            A.CallTo(() => authenticationManager.GetActiveUser())
                .Returns<User>(new TestUser(isAuthenticated));

            // Act
            controller.Login(networkName);

            // Assert
            A.CallTo(() => connectUserManager.AttachUser(networkName, true, null))
                .MustHaveHappened();
        }

        [Fact]
        public void LogoutShouldCallAuthenticationManagerLogout()
        {
            // Arrange
            var controller = new SocialConnectedAuthenticationController(authenticationManager, connectUserManager);

            // Act
            controller.Logout();

            // Assert
            A.CallTo(() => authenticationManager.Logout())
                .MustHaveHappened();
        }

        [Fact]
        public void LogoutShouldReturnRedirectResult()
        {
            // Arrange
            var controller = new SocialConnectedAuthenticationController(authenticationManager, connectUserManager);

            // Act
            var result = controller.Logout();

            // Assert
            Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public void LogoutShouldRedirectToSiteRoot()
        {
            // Arrange
            var controller = new SocialConnectedAuthenticationController(authenticationManager, connectUserManager);

            // Act
            var result = controller.Logout();

            // Assert
            Assert.Equal(((RedirectResult)result).Url, "/");
        }
        public void Dispose()
        {
        }
    }
}
