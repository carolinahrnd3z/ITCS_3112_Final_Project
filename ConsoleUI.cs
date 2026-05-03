using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Repositories;
using ITCS_3112_Final_Project.Services;
using ITCS_3112_Final_Project.Strategies;

namespace ITCS_3112_Final_Project;

public class ConsoleUI
{
    private readonly IMemberRepository memberRepository;
    private readonly ILoginService loginService;
    private readonly ISignUpService signUpService;
    private readonly ICheckInService checkInService;
    private readonly List<GymClass> gymClasses;

    private Faculty? loggedInFaculty;

    /// <summary>
    /// Initializes the ConsoleUI with required services and data sources.
    /// </summary>
    /// <param name="memberRepository">Repository for managing members.</param>
    /// <param name="loginService">Service used for authentication.</param>
    /// <param name="signUpService">Service used for class enrollment.</param>
    /// <param name="checkInService">Service used for member check-in and check-out.</param>
    /// <param name="gymClasses">The list of available gym classes.</param>
    public ConsoleUI(
        IMemberRepository memberRepository,
        ILoginService loginService,
        ISignUpService signUpService,
        ICheckInService checkInService,
        List<GymClass> gymClasses)
    {
        this.memberRepository = memberRepository;
        this.loginService = loginService;
        this.signUpService = signUpService;
        this.checkInService = checkInService;
        this.gymClasses = gymClasses;
    }

    /// <summary>
    /// Starts the console interface after login.
    /// </summary>
    public void Start()
    {
        if (!Login())
        {
            ShowMessage("Login failed. Exiting system.");
            return;
        }

        DisplayMenu();
    }

    /// <summary>
    /// Prompts the faculty member to log in.
    /// </summary>
    /// <returns>True if login succeeds; otherwise false.</returns>
    private bool Login()
    {
        Console.WriteLine("=== Faculty Login ===");

        Console.Write("Username: ");
        string username = Console.ReadLine() ?? "";

        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";

        loggedInFaculty = loginService.Login(username, password);

        if (loggedInFaculty == null)
        {
            return false;
        }

        ShowMessage($"\nWelcome, {loggedInFaculty.Name}!");
        return true;
    }

    /// <summary>
    /// Displays the main menu and handles user choices.
    /// </summary>
    private void DisplayMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Gym Membership Management System ===");
            Console.WriteLine("1. Check In Member");
            Console.WriteLine("2. Check Out Member");
            Console.WriteLine("3. Search Member");
            Console.WriteLine("4. Add Member");
            Console.WriteLine("5. Update Member");
            Console.WriteLine("6. Remove Member");
            Console.WriteLine("7. View Gym Classes");
            Console.WriteLine("8. Sign Member Up For Class");
            Console.WriteLine("9. Remove Member From Class");
            Console.WriteLine("10. Add New Gym Class");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckInMember();
                    break;
                case "2":
                    CheckOutMember();
                    break;
                case "3":
                    SearchMember();
                    break;
                case "4":
                    AddMember();
                    break;
                case "5":
                    UpdateMember();
                    break;
                case "6":
                    RemoveMember();
                    break;
                case "7":
                    ViewGymClasses();
                    break;
                case "8":
                    SignMemberUpForClass();
                    break;
                case "9":
                    RemoveMemberFromClass();
                    break;
                case "10":
                    AddGymClass();
                    break;
                case "0":
                    running = false;
                    ShowMessage("Goodbye!");
                    break;
                default:
                    ShowMessage("Invalid option. Please try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Handles member check-in using a selected search strategy.
    /// </summary>
    private void CheckInMember()
    {
        SearchStrategy? strategy = ChooseSearchStrategy("Check in by:");

        if (strategy == null)
        {
            ShowMessage("Invalid search type.");
            return;
        }

        Console.Write("Enter search value: ");
        string value = Console.ReadLine() ?? "";

        bool success = checkInService.CheckInMember(strategy, value);

        ShowMessage(success
            ? "Member checked in successfully."
            : "Check-in failed. Member may not exist or may already be checked in.");
    }

    /// <summary>
    /// Handles member check-out using a selected search strategy.
    /// </summary>
    private void CheckOutMember()
    {
        SearchStrategy? strategy = ChooseSearchStrategy("Check out by:");

        if (strategy == null)
        {
            ShowMessage("Invalid search type.");
            return;
        }

        Console.Write("Enter search value: ");
        string value = Console.ReadLine() ?? "";

        bool success = checkInService.CheckOutMember(strategy, value);

        ShowMessage(success
            ? "Member checked out successfully."
            : "Check-out failed. Member may not exist or may not be checked in.");
    }

    /// <summary>
    /// Searches for and displays a member.
    /// </summary>
    private void SearchMember()
    {
        SearchStrategy? strategy = ChooseSearchStrategy("Search by:");

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

    /// <summary>
    /// Prompts the user to select a search strategy.
    /// </summary>
    /// <param name="title">The title displayed to the user.</param>
    /// <returns>The selected search strategy or null if invalid.</returns>
    private SearchStrategy? ChooseSearchStrategy(string title)
    {
        Console.WriteLine($"\n{title}");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Email");
        Console.WriteLine("3. Phone Number");
        Console.WriteLine("4. Account Number");
        Console.Write("Choose search type: ");

        string? choice = Console.ReadLine();

        return choice switch
        {
            "1" => new NameSearch(),
            "2" => new EmailSearch(),
            "3" => new PhoneSearch(),
            "4" => new AccountNumberSearch(),
            _ => null
        };
    }

    /// <summary>
    /// Adds a new member using console input.
    /// </summary>
    private void AddMember()
    {
        Console.Write("\nEnter name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        Console.Write("Enter account number: ");

        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            ShowMessage("Invalid account number.");
            return;
        }

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

    /// <summary>
    /// Updates an existing member using console input.
    /// </summary>
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

    /// <summary>
    /// Removes a member by account number.
    /// </summary>
    private void RemoveMember()
    {
        Console.Write("\nEnter account number to remove: ");

        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            ShowMessage("Invalid account number.");
            return;
        }

        bool removed = memberRepository.Remove(accountNumber);

        ShowMessage(removed ? "Member removed successfully." : "Member not found.");
    }

    /// <summary>
    /// Displays all available gym classes.
    /// </summary>
    private void ViewGymClasses()
    {
        Console.WriteLine("\n=== Gym Classes ===");

        if (gymClasses.Count == 0)
        {
            ShowMessage("No gym classes available.");
            return;
        }

        for (int i = 0; i < gymClasses.Count; i++)
        {
            GymClass gymClass = gymClasses[i];

            Console.WriteLine($"{i + 1}. {gymClass.Name}");
            Console.WriteLine($"   Schedule: {gymClass.Schedule}");
            Console.WriteLine($"   Instructor: {gymClass.Instructor}");
            Console.WriteLine($"   Capacity: {gymClass.GetEnrollmentCount()}/{gymClass.Capacity}");
        }
    }

    /// <summary>
    /// Signs a member up for a selected gym class.
    /// </summary>
    private void SignMemberUpForClass()
    {
        Member? member = FindMemberForClassAction();

        if (member == null)
        {
            ShowMessage("Member not found.");
            return;
        }

        GymClass? gymClass = SelectGymClass();

        if (gymClass == null)
        {
            ShowMessage("Invalid class selection.");
            return;
        }

        string message = signUpService.AddMember(member, gymClass);
        ShowMessage(message);
    }

    /// <summary>
    /// Removes a member from a selected gym class.
    /// </summary>
    private void RemoveMemberFromClass()
    {
        Member? member = FindMemberForClassAction();

        if (member == null)
        {
            ShowMessage("Member not found.");
            return;
        }

        GymClass? gymClass = SelectGymClass();

        if (gymClass == null)
        {
            ShowMessage("Invalid class selection.");
            return;
        }

        string message = signUpService.RemoveMember(member, gymClass);
        ShowMessage(message);
    }

    /// <summary>
    /// Adds a new gym class using console input.
    /// </summary>
    private void AddGymClass()
    {
        Console.WriteLine("\n=== Add New Gym Class ===");
        Console.WriteLine("1. Yoga");
        Console.WriteLine("2. Strength");
        Console.WriteLine("3. Zumba");
        Console.Write("Choose class type: ");

        string? typeChoice = Console.ReadLine();

        Console.Write("Enter class name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter schedule: ");
        string schedule = Console.ReadLine() ?? "";

        Console.Write("Enter capacity: ");

        if (!int.TryParse(Console.ReadLine(), out int capacity))
        {
            ShowMessage("Invalid capacity.");
            return;
        }

        Console.Write("Enter instructor name: ");
        string instructor = Console.ReadLine() ?? "";

        GymClass? gymClass = typeChoice switch
        {
            "1" => new YogaClass(name, schedule, capacity, instructor),
            "2" => new StrengthClass(name, schedule, capacity, instructor),
            "3" => new ZumbaClass(name, schedule, capacity, instructor),
            _ => null
        };

        if (gymClass == null)
        {
            ShowMessage("Invalid class type.");
            return;
        }

        gymClasses.Add(gymClass);
        ShowMessage($"{gymClass.Name} class added successfully.");
    }

    /// <summary>
    /// Finds a member for class enrollment or removal.
    /// </summary>
    /// <returns>The matching member, or null if no member is found.</returns>
    private Member? FindMemberForClassAction()
    {
        SearchStrategy? strategy = ChooseSearchStrategy("Find member for class:");

        if (strategy == null)
        {
            return null;
        }

        Console.Write("Enter search value: ");
        string value = Console.ReadLine() ?? "";

        return strategy.Search(memberRepository, value);
    }

    /// <summary>
    /// Prompts the user to select a gym class.
    /// </summary>
    /// <returns>The selected gym class, or null if the choice is invalid.</returns>
    private GymClass? SelectGymClass()
    {
        ViewGymClasses();

        if (gymClasses.Count == 0)
        {
            return null;
        }

        Console.Write("\nChoose class number: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            return null;
        }

        if (choice < 1 || choice > gymClasses.Count)
        {
            return null;
        }

        return gymClasses[choice - 1];
    }

    /// <summary>
    /// Displays member information to the console.
    /// </summary>
    /// <param name="member">The member to display.</param>
    private void ShowMemberInfo(Member member)
    {
        Console.WriteLine("\n=== Member Information ===");
        Console.WriteLine($"Name: {member.Name}");
        Console.WriteLine($"Email: {member.Email}");
        Console.WriteLine($"Phone Number: {member.PhoneNumber}");
        Console.WriteLine($"Account Number: {member.AccountNumber}");
        Console.WriteLine($"Membership Type: {member.MembershipType}");
    }

    /// <summary>
    /// Displays a message to the console.
    /// </summary>
    /// <param name="message">The message to display.</param>
    private void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}