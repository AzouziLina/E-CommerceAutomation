using NUnit.Framework;
using ECommerceAutomation.Page.Abstraction;
using ECommerceAutomation.Page;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Verification.Abstraction;
using ECommerceAutomation.Test;
using System.Reflection;
using CoreAutomation.Interfce;

namespace ECommerceAutomation.Verification
{
    public class LoginVerification : ECommerceTestBase, ILoginVerification
    {
        public IDictionary<string, string> Data = null;
        private readonly ILoginData loginData;
        private readonly ILoginPage? loginPage;

        public LoginVerification(IBrowserHelper browserHelper, IReportHelper reportHelper, ILoginData loginData, ILoggerHelper loggerHelper)
        {
            this.browserHelper = browserHelper;
            this.reportHelper = reportHelper;
            this.loggerHelper = loggerHelper;

            if (loginPage == null)
                loginPage = new LoginPage(browserHelper, reportHelper, loggerHelper);

            this.loginData = loginData;
            Data = this.loginData.helper.Data;
        }

        public void VerifyLogIn()
        {
            try
            {
                Assert.IsTrue(loginPage.IsLogInDone(Data[loginData.expectedMessage]));
                reportHelper.SetStepStatusPassed("Log in was done succesfully : " + Data[loginData.expectedMessage]);
            }
            catch (AssertionException assertionex)
            {
                reportHelper.SetStepStatusFailed("Log in was not done succesfully : "+ assertionex);
                throw assertionex;
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void VerifyLoginNotSuccess()
        {
            try
            {
                Assert.IsTrue(loginPage.IsErrorMessageDisplayed(Data[loginData.expectedMessage]));
                reportHelper.SetStepStatusPassed("Expected Error message was displayed succesfully : " + Data[loginData.expectedMessage]);
            }
            catch (AssertionException assertionex)
            {
                reportHelper.SetStepStatusFailed("Expected message not appears : " + assertionex);
                throw assertionex;
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
    }
}
