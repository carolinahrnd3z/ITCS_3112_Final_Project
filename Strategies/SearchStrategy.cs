using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Repositories;

namespace ITCS_3112_Final_Project.Strategies;

public abstract class SearchStrategy
{
    /// <summary>
    /// Searches for a member using a specific search approach.
    /// </summary>
    /// <param name="repository">The member repository to search.</param>
    /// <param name="value">The value used for the search.</param>
    /// <returns>The matching member, or null if no match is found.</returns>
    public abstract Member? Search(IMemberRepository repository, string value);
}
