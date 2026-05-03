namespace ITSC_3112_Final_Project.Domain;

public class ZumbaClass : GymClass
{
    public YogaClass(string name, string schedule, int capacity, string instructor) : base(name, schedule, capacity, instructor){}
    
    protected override bool ApplyClassRules(Member member)
    {
        return member.MembershipType != MembershipEnum.BASIC;
    }
}