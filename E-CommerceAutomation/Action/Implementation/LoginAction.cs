using CoreAutomation.Interfce;
using ECommerceAutomation.Action.Abstraction;
using ECommerceAutomation.Page.Abstraction;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Page;
using ECommerceAutomation.Test;
using System.Reflection;

namespace ECommerceAutomation.Action
{
    public class LoginAction: ECommerceTestBase, ILoginAction
    {
        private readonly ILoginPage? loginPage;
        public IDictionary<string, string> Data = null;
        public LoginAction(IBrowserHelper browserHelper, IReportHelper reportHelper, ILoginData loginData, ILoggerHelper loggerHelper)
        {
            this.browserHelper = browserHelper;
            this.reportHelper = reportHelper;
            this.loggerHelper = loggerHelper;

            if (loginPage == null)
                loginPage = new LoginPage(browserHelper, reportHelper, loggerHelper);

            this.loginData = loginData;
            Data = this.loginData.helper.Data;
        }
        public void SetYourCredentials()
        {
            try
            {
                loginPage.ClickOnContinue();
                loginPage.ClickOnToSignIn();
                loginPage.SetEmail(Data[loginData.email]);
                loginPage.SetPassword(Data[loginData.password]);
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void PressLogIn()
        {
            try
            {
                loginPage.ClickOnLogIn();
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void LoginToYourAccount()
        {
            try 
            {
                SetYourCredentials();
                PressLogIn();
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
