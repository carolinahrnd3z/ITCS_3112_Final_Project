namespace ITCS_3112_Final_Project.Domain;

public class YogaClass : GymClass
{
    /// <summary>
    /// Initializes a new instance of the YogaClass.
    /// </summary>
    /// <param name="name">The name of the class.</param>
    /// <param name="schedule">The class schedule.</param>
    /// <param name="capacity">The maximum capacity.</param>
    /// <param name="instructor">The instructor's name.</param>
    public YogaClass(string name, string schedule, int capacity, string instructor)
        : base(name, schedule, capacity, instructor, new List<Member>())
    {
    }

    /// <summary>
    /// Applies the enrollment rules for this specific class type.
    /// </summary>
    /// <param name="member">The member being evaluated.</param>
    /// <returns>True if the member can enroll; otherwise false.</returns>
    protected override bool ApplyClassRules(Member member)
    {
        return true;
    }
}