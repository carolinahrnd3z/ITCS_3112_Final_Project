using ITSC_3112_Final_Project.Domain;
using ITSC_3112_Final_Project.Repositories;

namespace ITCS_3112_Final_Project.Services;

public class LoginService : ILoginService
{
    private readonly IFacultyRepository facultyRepository;

    public LoginService(IFacultyRepository facultyRepository)
    {
        this.facultyRepository = facultyRepository;
    }

    public Faculty? Login(string username, string password)
    {
        var facultyList = facultyRepository.GetAll();

        return facultyList.FirstOrDefault(f =>
            f.Username == username &&
            f.Password == password);
    }
}