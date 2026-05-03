using ITCS_3112_Final_Project.Domain;

namespace ITCS_3112_Final_Project.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly List<Member> members = new List<Member>();

    /// <summary>
    /// Finds a member by name.
    /// </summary>
    /// <param name="name">The member name to search for.</param>
    /// <returns>The matching member, or null if no match is found.</returns>
    public Member? GetByName(string name)
    {
        return members.FirstOrDefault(m =>
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    /// <summary>
    /// Finds a member by email address.
    /// </summary>
    /// <param name="email">The email address to search for.</param>
    /// <returns>The matching member, or null if no match is found.</returns>
    public Member? GetByEmail(string email)
    {
        return members.FirstOrDefault(m =>
            m.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Finds a member by phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number to search for.</param>
    /// <returns>The matching member, or null if no match is found.</returns>
    public Member? GetByPhone(string phoneNumber)
    {
        return members.FirstOrDefault(m => m.PhoneNumber == phoneNumber);
    }

    /// <summary>
    /// Finds a member by account number.
    /// </summary>
    /// <param name="accountNumber">The account number to search for.</param>
    /// <returns>The matching member, or null if no match is found.</returns>
    public Member? GetByAccountNumber(int accountNumber)
    {
        return members.FirstOrDefault(m => m.AccountNumber == accountNumber);
    }

    /// <summary>
    /// Adds a member to the repository.
    /// </summary>
    /// <param name="member">The member to add.</param>
    public void Add(Member member)
    {
        members.Add(member);
    }

    /// <summary>
    /// Updates an existing member in the repository.
    /// </summary>
    /// <param name="member">The member with updated information.</param>
    public void Update(Member member)
    {
        Member? existing = GetByAccountNumber(member.AccountNumber);

        if (existing == null)
        {
            return;
        }

        existing.Name = member.Name;
        existing.Email = member.Email;
        existing.PhoneNumber = member.PhoneNumber;
        existing.MembershipType = member.MembershipType;
    }

    /// <summary>
    /// Removes a member by account number.
    /// </summary>
    /// <param name="accountNumber">The account number of the member to remove.</param>
    /// <returns>True if the member was removed; otherwise false.</returns>
    public bool Remove(int accountNumber)
    {
        Member? member = GetByAccountNumber(accountNumber);

        if (member == null)
        {
            return false;
        }

        return members.Remove(member);
    }
}
