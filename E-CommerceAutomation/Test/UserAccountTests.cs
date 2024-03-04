using NUnit.Framework;
using ECommerceAutomation.Test;

namespace UserAccountTests
{
    public class LoginTests : ECommerceTestBase
    {
        [SetUp]
        public void Setup()
        {
            SetUpLogin();
        }

        [Test, Order(1)]
        public void TC001_Login_to_your_account()
        {
            loginAction.LoginToYourAccount();
            loginVerification.VerifyLogIn();
        }
        [Test, Order(2)]
        public void TC002_Login_to_your_account_with_Wrong_Password()
        {
            loginAction.LoginToYourAccount();
            loginVerification.VerifyLoginNotSuccess();
        }
        [Test, Order(3)]
        public void TC003_Login_to_your_account_with_Wrong_EmailAddress()
        {
            loginAction.LoginToYourAccount();
            loginVerification.VerifyLoginNotSuccess();
        }
    }
}