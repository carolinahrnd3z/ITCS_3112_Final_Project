namespace ITSC_3112_Final_Project.Domain;

public class Faculty : Person
{ 
    public int EmployeeId { get; set; }
    
    public Faculty(string name, string email, string phoneNumber, int employeeId) : base(name, email, phoneNumber)
    {
        EmployeeId = employeeId;
    }

    public Member? SearchMember(string value, List<Member> members)
    {
        return members.FirstOrDefault(m => m.Name.Equals(value, StringComparison.OrdinalIgnoreCase) || m.Email.Equals(value, StringComparison.OrdinalIgnoreCase) || m.AccountNumber.ToString() == value);
    }

    void UpdateMemberInfo(Member member)
    {
            member.Name = member.Name;
            member.Email = member.Email;
            member.PhoneNumber = member.PhoneNumber;
            member.MembershipType = member.MembershipType;
    }
}