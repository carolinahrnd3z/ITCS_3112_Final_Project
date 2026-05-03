namespace ITSC_3112_Final_Project.Domain;

public interface ISignUpService
{
    bool AddMember(Member member, GymClass gymClass);
    bool RemoveMember(Member member, GymClass gymClass);
    bool IsFull(GymClass gymClass);
}