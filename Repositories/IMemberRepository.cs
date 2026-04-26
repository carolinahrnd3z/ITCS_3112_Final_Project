using ITSC_3112_Final_Project.Domain;

namespace ITSC_3112_Final_Project.Repositories;

public interface IMemberRepository
{
    Member? GetByName(string name);
    Member? GetByEmail(string email);
    Member? GetByPhone(string phoneNumber);
    Member? GetByAccountNumber(int accountNumber);
    void Add(Member member);
    void Update(Member member);
    bool Remove(int accountNumber);
}
