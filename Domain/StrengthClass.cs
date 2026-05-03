namespace ITSC_3112_Final_Project.Domain;

public class StrengthClass : GymClass
{
    public StrengthClass(string name, string schedule, int capacity, string instructor) : base(name, schedule, capacity, instructor)
    {}

    public override bool ApplyClassRules(Member member)
    {
        return member.MembershipType == MembershipEnum.PRO || member.MembershipType == MembershipEnum.ELITE;
    }
}