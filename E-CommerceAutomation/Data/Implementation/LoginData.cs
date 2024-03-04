using ECommerceAutomation.Data.Abstraction;
using CoreAutomation.Interfce;
using CoreAutomation.Data;
using System.Reflection;

namespace ECommerceAutomation.Data
{
    public class LoginData :ILoginData
    {
        public LoginData(string testCaseName, string module)
        {
            helper = new ExcelHelper();
            string spreadsheet = $"{module}_{testCaseName.Split('_')[0]}";
            helper.LoadDatabyColumn(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $".\\Data\\{module}.xlsx", spreadsheet);
        }
        public IDataHelper helper { get; set; }
        public string email { get; } = "Email";
        public string password { get; } = "Password";
        public string expectedMessage { get; } = "ExpectedMessage";

    }
}
