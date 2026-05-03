using ITCS_3112_Final_Project.Domain;

namespace ITCS_3112_Final_Project.Services;

public interface ILoginService
{
    /// <summary>
    /// Attempts to log in a faculty member using provided credentials.
    /// </summary>
    /// <param name="username">The username of the faculty member.</param>
    /// <param name="password">The password of the faculty member.</param>
    /// <returns>
    /// The matching faculty member if login is successful; otherwise null.
    /// </returns>
    Faculty? Login(string username, string password);
}