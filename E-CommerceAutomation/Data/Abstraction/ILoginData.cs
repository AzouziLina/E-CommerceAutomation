using CoreAutomation.Interfce;

namespace ECommerceAutomation.Data.Abstraction
{
    public interface ILoginData
    {
        IDataHelper helper { get; set; }
        string email { get; }
        string password { get; }
        string expectedMessage { get; }
    }
}
