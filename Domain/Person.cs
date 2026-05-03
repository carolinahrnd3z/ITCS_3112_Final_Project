namespace ITCS_3112_Final_Project.Domain;

public class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Initializes a new instance of the Person class.
    /// </summary>
    /// <param name="name">The person's name.</param>
    /// <param name="email">The person's email address.</param>
    /// <param name="phoneNumber">The person's phone number.</param>
    public Person(string name, string email, string phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}