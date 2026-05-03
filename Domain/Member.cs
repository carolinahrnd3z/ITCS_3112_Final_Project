namespace ITCS_3112_Final_Project.Domain;

public class Member : Person
{
    public int AccountNumber { get; set; }
    public MembershipEnum MembershipType { get; set; }

    /// <summary>
    /// Initializes a new instance of the Member class.
    /// </summary>
    /// <param name="name">The member's name.</param>
    /// <param name="email">The member's email address.</param>
    /// <param name="phoneNumber">The member's phone number.</param>
    /// <param name="accountNumber">The unique account number.</param>
    /// <param name="membershipType">The membership level of the member.</param>
    public Member(string name, string email, string phoneNumber, int accountNumber, MembershipEnum membershipType) : base(name, email, phoneNumber)
    {
        AccountNumber = accountNumber;
        MembershipType = membershipType;
    }
}