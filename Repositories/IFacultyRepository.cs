using ITCS_3112_Final_Project.Domain;

namespace ITCS_3112_Final_Project.Repositories;

public interface IFacultyRepository
{
    /// <summary>
    /// Finds a faculty member by name.
    /// </summary>
    /// <param name="name">The name to search for.</param>
    /// <returns>The matching faculty member, or null if not found.</returns>
    Faculty? GetByName(string name);
    
    /// <summary>
    /// Finds a faculty member by employee ID.
    /// </summary>
    /// <param name="employeeId">The employee ID to search for.</param>
    /// <returns>The matching faculty member, or null if not found.</returns>
    Faculty? GetById(int employeeId);
    
    /// <summary>
    /// Adds a new faculty member.
    /// </summary>
    /// <param name="faculty">The faculty member to add.</param>
    void Add(Faculty faculty);
    
    /// <summary>
    /// Updates an existing faculty member.
    /// </summary>
    /// <param name="faculty">The faculty member with updated information.</param>
    void Update(Faculty faculty);
    
    /// <summary>
    /// Retrieves all faculty members.
    /// </summary>
    /// <returns>A list of all faculty members.</returns>
    List<Faculty> GetAll();
}
