using ITSC_3112_Final_Project.Domain;

namespace ITSC_3112_Final_Project.Repositories;

public interface IFacultyRepository
{
    Faculty? GetByName(string name);
    Faculty? GetById(int employeeId);
    void Add(Faculty faculty);
    void Update(Faculty faculty);
}
