using ITSC_3112_Final_Project.Domain;

namespace ITSC_3112_Final_Project.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly List<Member> members = new List<Member>();

    public Member? GetByName(string name)
    {
        return members.FirstOrDefault(m =>
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Member? GetByEmail(string email)
    {
        return members.FirstOrDefault(m =>
            m.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public Member? GetByPhone(string phoneNumber)
    {
        return members.FirstOrDefault(m => m.PhoneNumber == phoneNumber);
    }

    public Member? GetByAccountNumber(int accountNumber)
    {
        return members.FirstOrDefault(m => m.AccountNumber == accountNumber);
    }

    public void Add(Member member)
    {
        members.Add(member);
    }

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
