using ITSC_3112_Final_Project.Domain;

namespace ITCS_3112_Final_Project.Services;

public interface ILoginService
{
    Faculty? Login(string username, string password);
}