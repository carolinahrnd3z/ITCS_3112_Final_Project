namespace ITSC_3112_Final_Project.Domain;

public class Member : Person
{
    public int AccountNumber { get; set; }
    public MembershipEnum MembershipType { get; set; }

    public Member(string name, string email, string phoneNumber, int accountNumber, MembershipEnum membershipType) : base(name, email, phoneNumber)
    {
        AccountNumber = accountNumber;
        MembershipType = membershipType;
    }
}