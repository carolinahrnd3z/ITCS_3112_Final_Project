using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Repositories;
using ITCS_3112_Final_Project.Strategies;

namespace ITCS_3112_Final_Project.Services;

public class CheckInService : ICheckInService
{
    private readonly IMemberRepository memberRepository;
    private readonly List<Member> checkedInMembers = new();

    /// <summary>
    /// Initializes a new instance of the CheckInService with a member repository.
    /// </summary>
    /// <param name="memberRepository">
    /// The repository used to access and manage member data.
    /// </param>
    public CheckInService(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    /// <summary>
    /// Finds a member using a specified search strategy.
    /// </summary>
    /// <param name="strategy">The strategy used to search.</param>
    /// <param name="value">The search value.</param>
    /// <returns>The matching member, or null if not found.</returns>
    public Member? FindMember(SearchStrategy strategy, string value)
    {
        return strategy.Search(memberRepository, value);
    }

    /// <summary>
    /// Checks a member into the system.
    /// </summary>
    /// <param name="strategy">Search strategy used to find the member.</param>
    /// <param name="value">Search value.</param>
    /// <returns>True if the member was checked in; otherwise false.</returns>
    public bool CheckInMember(SearchStrategy strategy, string value)
    {
        Member? member = FindMember(strategy, value);

        if (member == null)
        {
            return false;
        }

        if (IsCheckedIn(member))
        {
            return false;
        }

        checkedInMembers.Add(member);
        return true;
    }

    /// <summary>
    /// Checks out a member found by the selected search strategy.
    /// </summary>
    /// <param name="strategy">The search strategy used to find the member.</param>
    /// <param name="value">The value used to search for the member.</param>
    /// <returns>True if the member was checked out; otherwise false.</returns>
    public bool CheckOutMember(SearchStrategy strategy, string value)
    {
        Member? member = FindMember(strategy, value);

        if (member == null)
        {
            return false;
        }

        Member? checkedInMember = checkedInMembers.FirstOrDefault(m =>
            m.AccountNumber == member.AccountNumber);

        if (checkedInMember == null)
        {
            return false;
        }

        checkedInMembers.Remove(checkedInMember);
        return true;
    }

    /// <summary>
    /// Determines whether a member is currently checked in.
    /// </summary>
    /// <param name="member">The member to check.</param>
    /// <returns>True if the member is checked in; otherwise false.</returns>
    public bool IsCheckedIn(Member member)
    {
        return checkedInMembers.Any(m =>
            m.AccountNumber == member.AccountNumber);
    }
}