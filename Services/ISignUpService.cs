using ITCS_3112_Final_Project.Domain;

public interface ISignUpService
{
    /// <summary>
    /// Attempts to add a member to a gym class.
    /// </summary>
    /// <param name="member">The member to add.</param>
    /// <param name="gymClass">The class to enroll in.</param>
    /// <returns>A message describing the result.</returns>
    string AddMember(Member member, GymClass gymClass);
    
    /// <summary>
    /// Attempts to remove a member from a gym class.
    /// </summary>
    /// <param name="member">The member to remove.</param>
    /// <param name="gymClass">The gym class the member is being removed from.</param>
    /// <returns>
    /// A message describing whether the operation was successful or the reason it failed.
    /// </returns>
    string RemoveMember(Member member, GymClass gymClass);
    
    /// <summary>
    /// Determines whether a gym class has reached its maximum capacity.
    /// </summary>
    /// <param name="gymClass">The gym class to evaluate.</param>
    /// <returns>
    /// True if the class is full; otherwise false.
    /// </returns>
    bool IsFull(GymClass gymClass);
}