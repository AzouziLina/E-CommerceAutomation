using NUnit.Framework;
using CoreAutomation.Test;
using ECommerceAutomation.Data;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Action;
using ECommerceAutomation.Action.Abstraction;
using ECommerceAutomation.Verification;
using ECommerceAutomation.Verification.Abstraction;

namespace ECommerceAutomation.Test
{
    public abstract class ECommerceTestBase:BaseTest
    {
        //Data:
        public ILoginData? loginData;
        //Actions:
        public ILoginAction? loginAction;
        //Verifications:
        public ILoginVerification? loginVerification;

        public void SetUpLogin()
        {
            loginData = new LoginData(TestContext.CurrentContext.Test.Name, "Login");
            loginAction = new LoginAction(browserHelper, reportHelper, loginData, loggerHelper);
            loginVerification = new LoginVerification(browserHelper, reportHelper, loginData, loggerHelper);
        }
    }
}
