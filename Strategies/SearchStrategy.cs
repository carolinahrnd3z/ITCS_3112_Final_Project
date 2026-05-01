using ITSC_3112_Final_Project.Domain;
using ITSC_3112_Final_Project.Repositories;

namespace ITSC_3112_Final_Project.Strategies;

public abstract class SearchStrategy
{
    public abstract Member? Search(MemberRepository repository, string value);
}
