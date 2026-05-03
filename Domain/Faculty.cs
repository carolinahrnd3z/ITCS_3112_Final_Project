namespace ITCS_3112_Final_Project.Domain;

public class Faculty : Person
{ 
    public int EmployeeId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the Faculty class with login credentials.
    /// </summary>
    /// <param name="name">The faculty member's name.</param>
    /// <param name="email">The faculty member's email.</param>
    /// <param name="phoneNumber">The faculty member's phone number.</param>
    /// <param name="employeeId">The unique employee ID.</param>
    /// <param name="username">The login username.</param>
    /// <param name="password">The login password.</param>
    public Faculty(string name, string email, string phoneNumber, int employeeId,string username, string password) : base(name, email, phoneNumber)
    {
        EmployeeId = employeeId;
        Username = username;
        Password = password; 
    }

    /// <summary>
    /// Searches for a member in the provided list using a given value.
    /// </summary>
    /// <param name="value">The value used to search (e.g., name).</param>
    /// <param name="members">The list of members to search through.</param>
    /// <returns>
    /// The first matching member if found; otherwise null.
    /// </returns>
    public Member? SearchMember(string value, List<Member> members)
    {
        return members.FirstOrDefault(m => m.Name.Equals(value, StringComparison.OrdinalIgnoreCase) || m.Email.Equals(value, StringComparison.OrdinalIgnoreCase) || m.AccountNumber.ToString() == value);
    }

    /// <summary>
    /// Updates the information of a given member.
    /// </summary>
    /// <param name="member">The member whose information is being updated.</param>
    void UpdateMemberInfo(Member member)
    {
            member.Name = member.Name;
            member.Email = member.Email;
            member.PhoneNumber = member.PhoneNumber;
            member.MembershipType = member.MembershipType;
    }
}