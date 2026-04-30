namespace ITSC_3112_Final_Project.Domain;

public abstract class GymClass
{
    public string Name { get; set; }
    public string Schedule { get; set; }
    public int Capacity { get; set; }
    public string Instructor { get; set; }
    private List<Member> enrolledMembers = new List<Member>();

    public GymClass(string name, string schedule, int capacity, string instructor, List<Member> enrolledMembers)
    {
        Name = name;
        Schedule = schedule;
        Capacity = capacity;
        Instructor = instructor;
        this.enrolledMembers = enrolledMembers;
    }

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

    public bool RemoveMember(Member member)
    {
        return enrolledMembers.Remove(member);
    }

    public bool HasSpace()
    {
        return enrolledMembers.Count < Capacity;
    }

    protected abstract bool ApplyClassRules(Member member);
}
