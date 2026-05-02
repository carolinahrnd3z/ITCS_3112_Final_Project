using ITSC_3112_Final_Project.Domain;
using ITSC_3112_Final_Project.Repositories;
using ITCS_3112_Final_Project.Strategies;

namespace ITCS_3112_Final_Project;

public class ConsoleUI
{
    private readonly IMemberRepository memberRepository;

    public ConsoleUI(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    public void DisplayMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Gym Membership Management System ===");
            Console.WriteLine("1. Search Member");
            Console.WriteLine("2. Add Member");
            Console.WriteLine("3. Update Member");
            Console.WriteLine("4. Remove Member");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SearchMember();
                    break;
                case "2":
                    AddMember();
                    break;
                case "3":
                    UpdateMember();
                    break;
                case "4":
                    RemoveMember();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    ShowMessage("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void SearchMember()
    {
        Console.WriteLine("\nSearch by:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Email");
        Console.WriteLine("3. Phone Number");
        Console.WriteLine("4. Account Number");
        Console.Write("Choose search type: ");

        string? choice = Console.ReadLine();

        SearchStrategy? strategy = choice switch
        {
            "1" => new NameSearch(),
            "2" => new EmailSearch(),
            "3" => new PhoneSearch(),
            "4" => new AccountNumberSearch(),
            _ => null
        };

        if (strategy == null)
        {
            ShowMessage("Invalid search type.");
            return;
        }

        Console.Write("Enter search value: ");
        string value = Console.ReadLine() ?? "";

        Member? member = strategy.Search(memberRepository, value);

        if (member == null)
        {
            ShowMessage("Member not found.");
            return;
        }

        ShowMemberInfo(member);
    }

    private void AddMember()
    {
        Console.Write("\nEnter name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter membership type (BASIC, PRO, ELITE): ");
        string membershipInput = Console.ReadLine() ?? "BASIC";

        if (!Enum.TryParse(membershipInput, true, out MembershipEnum membershipType))
        {
            membershipType = MembershipEnum.BASIC;
        }

        Member member = new Member(name, email, phoneNumber, accountNumber, membershipType);
        memberRepository.Add(member);

        ShowMessage("Member added successfully.");
    }

    private void UpdateMember()
    {
        Console.Write("\nEnter account number of member to update: ");

        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            ShowMessage("Invalid account number.");
            return;
        }

        Member? existing = memberRepository.GetByAccountNumber(accountNumber);

        if (existing == null)
        {
            ShowMessage("Member not found.");
            return;
        }

        Console.Write("Enter new name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter new email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter new phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        Console.Write("Enter new membership type (BASIC, PRO, ELITE): ");
        string membershipInput = Console.ReadLine() ?? "BASIC";

        if (!Enum.TryParse(membershipInput, true, out MembershipEnum membershipType))
        {
            membershipType = existing.MembershipType;
        }

        Member updatedMember = new Member(name, email, phoneNumber, accountNumber, membershipType);
        memberRepository.Update(updatedMember);

        ShowMessage("Member updated successfully.");
    }

    private void RemoveMember()
    {
        Console.Write("\nEnter account number to remove: ");

        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            ShowMessage("Invalid account number.");
            return;
        }

        bool removed = memberRepository.Remove(accountNumber);

        if (removed)
        {
            ShowMessage("Member removed successfully.");
        }
        else
        {
            ShowMessage("Member not found.");
        }
    }

    public void ShowMemberInfo(Member member)
    {
        Console.WriteLine("\n=== Member Information ===");
        Console.WriteLine($"Name: {member.Name}");
        Console.WriteLine($"Email: {member.Email}");
        Console.WriteLine($"Phone Number: {member.PhoneNumber}");
        Console.WriteLine($"Account Number: {member.AccountNumber}");
        Console.WriteLine($"Membership Type: {member.MembershipType}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}