namespace ITSC_3112_Final_Project.Domain;

public class SignUpService : ISignUpService
{
    bool AddMember(Member member, GymClass gymClass)
    {
        return gymClass.AddMember(member);
    }

    bool RemoveMember(Member member, GymClass gymClass)
    {
        return gymClass.RemoveMember(member);
    }

    bool IsFull(GymClass gymClass)
    {
        return !gymClass.HasSpace();
    }
}