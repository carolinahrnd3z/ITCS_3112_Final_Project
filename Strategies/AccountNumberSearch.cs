using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Repositories;

namespace ITCS_3112_Final_Project.Strategies;

public class AccountNumberSearch : SearchStrategy
{
    /// <summary>
    /// Searches for a member using this strategy's search field.
    /// </summary>
    /// <param name="repository">The member repository to search.</param>
    /// <param name="value">The value used for the search.</param>
    /// <returns>The matching member, or null if no match is found.</returns>
    public override Member? Search(IMemberRepository repository, string value)
    {
        if (!int.TryParse(value, out int accountNumber))
            return null;

        return repository.GetByAccountNumber(accountNumber);
    }
}
