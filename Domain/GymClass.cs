namespace ITCS_3112_Final_Project.Domain;

public abstract class GymClass
{
    public string Name { get; set; }
    public string Schedule { get; set; }
    public int Capacity { get; set; }
    public string Instructor { get; set; }
    private List<Member> enrolledMembers = new List<Member>();

    /// <summary>
    /// Initializes a new gym class with the specified details.
    /// </summary>
    /// <param name="name">The name of the class.</param>
    /// <param name="schedule">The scheduled time for the class.</param>
    /// <param name="capacity">The maximum number of members allowed.</param>
    /// <param name="instructor">The instructor of the class.</param>
    /// <param name="enrolledMembers">The list of enrolled members.</param>
    public GymClass(string name, string schedule, int capacity, string instructor, List<Member> enrolledMembers)
    {
        Name = name;
        Schedule = schedule;
        Capacity = capacity;
        Instructor = instructor;
        this.enrolledMembers = enrolledMembers;
    }

    /// <summary>
    /// Adds a member to the gym class if space is available and rules are met.
    /// </summary>
    /// <param name="member">The member attempting to enroll.</param>
    /// <returns>True if the member was added; otherwise false.</returns>
    public bool AddMember(Member member)
    {
        if (!HasSpace())
        {
            return false;
        }

        if (!ApplyClassRules(member))
        {
            return false;
        }
        else
        {
            enrolledMembers.Add(member);
            return true;
        }
    }

    /// <summary>
    /// Removes a member from the gym class.
    /// </summary>
    /// <param name="member">The member to remove.</param>
    /// <returns>True if the member was removed; otherwise false.</returns>
    public bool RemoveMember(Member member)
    {
        return enrolledMembers.Remove(member);
    }

    /// <summary>
    /// Checks if the class has available capacity.
    /// </summary>
    /// <returns>True if there is space; otherwise false.</returns>
    public bool HasSpace()
    {
        return enrolledMembers.Count < Capacity;
    }
    
    /// <summary>
    /// Gets the current number of enrolled members.
    /// </summary>
    /// <returns>The number of enrolled members.</returns>
    public int GetEnrollmentCount()
    {
        return enrolledMembers.Count;
    }

    /// <summary>
    /// Applies class-specific rules to determine if a member can enroll.
    /// </summary>
    /// <param name="member">The member being evaluated.</param>
    /// <returns>True if the member meets the requirements; otherwise false.</returns>
    protected abstract bool ApplyClassRules(Member member);
}
