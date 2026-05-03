using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Repositories;

namespace ITCS_3112_Final_Project.Services;

public class LoginService : ILoginService
{
    private readonly IFacultyRepository facultyRepository;

    /// <summary>
    /// Initializes a new instance of the LoginService with a faculty repository.
    /// </summary>
    /// <param name="facultyRepository">
    /// The repository used to access and authenticate faculty members.
    /// </param>
    public LoginService(IFacultyRepository facultyRepository)
    {
        this.facultyRepository = facultyRepository;
    }

    /// <summary>
    /// Attempts to log in a faculty member using a username and password.
    /// </summary>
    /// <param name="username">The faculty member's username.</param>
    /// <param name="password">The faculty member's password.</param>
    /// <returns>The matching faculty member if login succeeds; otherwise null.</returns>
    public Faculty? Login(string username, string password)
    {
        var facultyList = facultyRepository.GetAll();

        return facultyList.FirstOrDefault(f =>
            f.Username == username &&
            f.Password == password);
    }
}