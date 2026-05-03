using ITCS_3112_Final_Project.Domain;

namespace ITCS_3112_Final_Project.Repositories;

public interface IMemberRepository
{
    /// <summary>
    /// Finds a member by name.
    /// </summary>
    /// <param name="name">The name to search for.</param>
    /// <returns>The matching member, or null if not found.</returns>
    Member? GetByName(string name);
    
    /// <summary>
    /// Finds a member by email.
    /// </summary>
    /// <param name="email">The email to search for.</param>
    /// <returns>The matching member, or null if not found.</returns>
    Member? GetByEmail(string email);
    
    /// <summary>
    /// Finds a member by phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number to search for.</param>
    /// <returns>The matching member, or null if not found.</returns>
    Member? GetByPhone(string phoneNumber);
    
    /// <summary>
    /// Finds a member by account number.
    /// </summary>
    /// <param name="accountNumber">The account number to search for.</param>
    /// <returns>The matching member, or null if not found.</returns>
    Member? GetByAccountNumber(int accountNumber);
    
    /// <summary>
    /// Adds a new member.
    /// </summary>
    /// <param name="member">The member to add.</param>
    void Add(Member member);
    
    /// <summary>
    /// Updates an existing member.
    /// </summary>
    /// <param name="member">The member with updated information.</param>
    void Update(Member member);
    
    /// <summary>
    /// Removes a member by account number.
    /// </summary>
    /// <param name="accountNumber">The account number of the member to remove.</param>
    /// <returns>True if the member was removed; otherwise false.</returns>
    bool Remove(int accountNumber);
}
