using ITSC_3112_Final_Project.Domain;
using ITSC_3112_Final_Project.Repositories;

namespace ITSC_3112_Final_Project.Strategies;

public class NameSearch : SearchStrategy
{
    public override Member? Search(MemberRepository repository, string value)
    {
        return repository.GetByName(value);
    }
}
