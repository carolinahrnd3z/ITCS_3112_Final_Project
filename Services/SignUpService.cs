using ITCS_3112_Final_Project.Domain;

namespace ITSC_3112_Final_Project.Services;

public class SignUpService : ISignUpService
{
    
    /// <summary>
    /// Attempts to add a member to a gym class and returns a descriptive result.
    /// </summary>
    /// <param name="member">The member to add.</param>
    /// <param name="gymClass">The class to enroll in.</param>
    /// <returns>A message describing the result of the operation.</returns>
    public string AddMember(Member member, GymClass gymClass)
    {
        bool added = gymClass.AddMember(member);

        if (added)
        {
            return $"{member.Name} was signed up for {gymClass.Name}.";
        }

        if (!gymClass.HasSpace())
        {
            return $"{member.Name} could not be signed up because {gymClass.Name} is full.";
        }

        return $"{member.Name} could not be signed up because their membership type does not meet the class requirements or they are already enrolled.";
    }

    /// <summary>
    /// Removes a member from a gym class.
    /// </summary>
    /// <param name="member">The member to remove.</param>
    /// <param name="gymClass">The class to remove from.</param>
    /// <returns>A message describing the result.</returns>
    public string RemoveMember(Member member, GymClass gymClass)
    {
        bool removed = gymClass.RemoveMember(member);

        return removed
            ? $"{member.Name} was removed from {gymClass.Name}."
            : $"{member.Name} was not enrolled in {gymClass.Name}.";
    }

    /// <summary>
    /// Determines whether a gym class has reached its maximum capacity.
    /// </summary>
    /// <param name="gymClass">The gym class to evaluate.</param>
    /// <returns>True if the class is full; otherwise false.</returns>
    public bool IsFull(GymClass gymClass)
    {
        return !gymClass.HasSpace();
    }
}