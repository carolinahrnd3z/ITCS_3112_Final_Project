using ITSC_3112_Final_Project.Domain;

namespace ITSC_3112_Final_Project.Repositories;

public class FacultyRepository : IFacultyRepository
{
    private readonly List<Faculty> facultyMembers = new List<Faculty>();

    public Faculty? GetByName(string name)
    {
        return facultyMembers.FirstOrDefault(f =>
            f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Faculty? GetById(int employeeId)
    {
        return facultyMembers.FirstOrDefault(f => f.EmployeeId == employeeId);
    }

    public void Add(Faculty faculty)
    {
        facultyMembers.Add(faculty);
    }

    public void Update(Faculty faculty)
    {
        Faculty? existing = GetById(faculty.EmployeeId);

        if (existing == null)
        {
            return;
        }

        existing.Name = faculty.Name;
        existing.Email = faculty.Email;
        existing.PhoneNumber = faculty.PhoneNumber;
        existing.EmployeeId = faculty.EmployeeId;
    }
}
