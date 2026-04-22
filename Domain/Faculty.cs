namespace ITSC_3112_Final_Project.Domain;

public class Faculty : Person
{ 
    public int EmployeeId { get; set; }
    private List<Member> members = new List<Member>();
    
    public Faculty(string name, string email, string phoneNumber, int employeeId) : base(name, email, phoneNumber)
    {
        EmployeeId = employeeId;
    }

    public Member? SearchMember(string value)
    {
        return members.FirstOrDefault(m => m.Name.Equals(value, StringComparison.OrdinalIgnoreCase) || m.Email.Equals(value, StringComparison.OrdinalIgnoreCase) || m.AccountNumber.ToString() == value);
    }

    void UpdateMemberInfo(Member member)
    {
            existing.Name = member.Name;
            existing.Email = member.Email;
            existing.PhoneNumber = member.PhoneNumber;
            existing.MembershipType = member.MembershipType;
        }
    }
}