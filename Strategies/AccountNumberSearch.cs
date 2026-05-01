using ITSC_3112_Final_Project.Domain;
using ITSC_3112_Final_Project.Repositories;

namespace ITSC_3112_Final_Project.Strategies;

public class AccountNumberSearch : SearchStrategy
{
    public override Member? Search(MemberRepository repository, string value)
    {
        if (!int.TryParse(value, out int accountNumber))
            return null;

        return repository.GetByAccountNumber(accountNumber);
    }
}
