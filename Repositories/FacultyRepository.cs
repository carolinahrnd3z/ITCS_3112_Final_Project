using ITCS_3112_Final_Project.Domain;

namespace ITCS_3112_Final_Project.Repositories;

public class FacultyRepository : IFacultyRepository
{
    private readonly List<Faculty> facultyMembers = new List<Faculty>();

    /// <summary>
    /// Finds a faculty member by name.
    /// </summary>
    /// <param name="name">The faculty name to search for.</param>
    /// <returns>The matching faculty member, or null if no match is found.</returns>
    public Faculty? GetByName(string name)
    {
        return facultyMembers.FirstOrDefault(f =>
            f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Finds a faculty member by employee ID.
    /// </summary>
    /// <param name="employeeId">The employee ID to search for.</param>
    /// <returns>The matching faculty member, or null if no match is found.</returns>
    public Faculty? GetById(int employeeId)
    {
        return facultyMembers.FirstOrDefault(f => f.EmployeeId == employeeId);
    }

    /// <summary>
    /// Adds a faculty member to the repository.
    /// </summary>
    /// <param name="faculty">The faculty member to add.</param>
    public void Add(Faculty faculty)
    {
        facultyMembers.Add(faculty);
    }

    /// <summary>
    /// Updates an existing faculty member in the repository.
    /// </summary>
    /// <param name="faculty">The faculty member with updated information.</param>
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
    
    /// <summary>
    /// Gets all faculty members stored in the repository.
    /// </summary>
    /// <returns>A list of all faculty members.</returns>
    public List<Faculty> GetAll()
    {
        return facultyMembers;
    }
}
