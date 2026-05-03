using ITCS_3112_Final_Project;
using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Repositories;
using ITCS_3112_Final_Project.Services;
using ITSC_3112_Final_Project.Services;

namespace ITCS_3112_Final_Project;

class Program
{
    static void Main(string[] args)
    {
        IMemberRepository memberRepository = new MemberRepository();
        IFacultyRepository facultyRepository = new FacultyRepository();

        // Services
        ILoginService loginService = new LoginService(facultyRepository);
        ISignUpService signUpService = new SignUpService();
        ICheckInService checkInService = new CheckInService(memberRepository);

        // Starting Faculty (login)
        facultyRepository.Add(new Faculty("Jillian Keel", "jkeel@email.com", "7041234567", 1, "jillian", "password123"));
        facultyRepository.Add(new Faculty(name: "Sarah Johnson", email: "sarah@email.com", phoneNumber: "7049876543", employeeId: 2, username: "sarah", password: "pass123"));
        facultyRepository.Add(new Faculty(name: "Michael Davis", email: "michael@email.com", phoneNumber: "7045558888", employeeId: 3, username: "mike", password: "pass123"));

        // Starting Members
        memberRepository.Add(new Member("Alice Green", "alice@email.com", "7041000001", 2001, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Brian White", "brian@email.com", "7041000002", 2002, MembershipEnum.PRO));
        memberRepository.Add(new Member("Cathy Black", "cathy@email.com", "7041000003", 2003, MembershipEnum.ELITE));
        memberRepository.Add(new Member("David King", "david@email.com", "7041000004", 2004, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Ella Scott", "ella@email.com", "7041000005", 2005, MembershipEnum.PRO));
        memberRepository.Add(new Member("Frank Adams", "frank@email.com", "7041000006", 2006, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Grace Lee", "grace@email.com", "7041000007", 2007, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Henry Young", "henry@email.com", "7041000008", 2008, MembershipEnum.PRO));
        memberRepository.Add(new Member("Isla Clark", "isla@email.com", "7041000009", 2009, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Jack Lewis", "jack@email.com", "7041000010", 2010, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Kara Hall", "kara@email.com", "7041000011", 2011, MembershipEnum.PRO));
        memberRepository.Add(new Member("Liam Allen", "liam@email.com", "7041000012", 2012, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Mia Walker", "mia@email.com", "7041000013", 2013, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Noah Wright", "noah@email.com", "7041000014", 2014, MembershipEnum.PRO));
        memberRepository.Add(new Member("Olivia Hill", "olivia@email.com", "7041000015", 2015, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Paul Baker", "paul@email.com", "7041000016", 2016, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Quinn Turner", "quinn@email.com", "7041000017", 2017, MembershipEnum.PRO));
        memberRepository.Add(new Member("Ryan Collins", "ryan@email.com", "7041000018", 2018, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Sophia Evans", "sophia@email.com", "7041000019", 2019, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Tyler Murphy", "tyler@email.com", "7041000020", 2020, MembershipEnum.PRO));
        memberRepository.Add(new Member("Uma Cooper", "uma@email.com", "7041000021", 2021, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Victor Reed", "victor@email.com", "7041000022", 2022, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Wendy Bailey", "wendy@email.com", "7041000023", 2023, MembershipEnum.PRO));
        memberRepository.Add(new Member("Xavier Brooks", "xavier@email.com", "7041000024", 2024, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Yara Foster", "yara@email.com", "7041000025", 2025, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Zane Gray", "zane@email.com", "7041000026", 2026, MembershipEnum.PRO));
        memberRepository.Add(new Member("Aaron Price", "aaron@email.com", "7041000027", 2027, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Bella Ward", "bella@email.com", "7041000028", 2028, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Caleb Cox", "caleb@email.com", "7041000029", 2029, MembershipEnum.PRO));
        memberRepository.Add(new Member("Diana Diaz", "diana@email.com", "7041000030", 2030, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Ethan Rivera", "ethan@email.com", "7041000031", 2031, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Fiona Perez", "fiona@email.com", "7041000032", 2032, MembershipEnum.PRO));
        memberRepository.Add(new Member("George Howard", "george@email.com", "7041000033", 2033, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Hannah Torres", "hannah@email.com", "7041000034", 2034, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Ian Peterson", "ian@email.com", "7041000035", 2035, MembershipEnum.PRO));
        memberRepository.Add(new Member("Jordan Miles", "jordan@email.com", "7042000001", 3001, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Ava Simmons", "ava@email.com", "7042000002", 3002, MembershipEnum.PRO));
        memberRepository.Add(new Member("Logan Carter", "logan@email.com", "7042000003", 3003, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Maya Bennett", "maya@email.com", "7042000004", 3004, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Cole Jenkins", "cole@email.com", "7042000005", 3005, MembershipEnum.PRO));
        memberRepository.Add(new Member("Nora Hughes", "nora@email.com", "7042000006", 3006, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Eli Sanders", "eli@email.com", "7042000007", 3007, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Ruby Flores", "ruby@email.com", "7042000008", 3008, MembershipEnum.PRO));
        memberRepository.Add(new Member("Owen Bryant", "owen@email.com", "7042000009", 3009, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Leah Morgan", "leah@email.com", "7042000010", 3010, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Isaac Powell", "isaac@email.com", "7042000011", 3011, MembershipEnum.PRO));
        memberRepository.Add(new Member("Chloe Russell", "chloe@email.com", "7042000012", 3012, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Miles Griffin", "miles@email.com", "7042000013", 3013, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Sofia Hayes", "sofia@email.com", "7042000014", 3014, MembershipEnum.PRO));
        memberRepository.Add(new Member("Nathan Perry", "nathan@email.com", "7042000015", 3015, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Lily Coleman", "lily@email.com", "7042000016", 3016, MembershipEnum.BASIC));
        memberRepository.Add(new Member("Connor Bell", "connor@email.com", "7042000017", 3017, MembershipEnum.PRO));
        memberRepository.Add(new Member("Emma Ward", "emma@email.com", "7042000018", 3018, MembershipEnum.ELITE));
        memberRepository.Add(new Member("Jason Brooks", "jason@email.com", "7042000019", 3019, MembershipEnum.PRO));
        memberRepository.Add(new Member("Natalie Cruz", "natalie@email.com", "7042000020", 3020, MembershipEnum.ELITE));
       
        // Create Gym Classes
        List<GymClass> gymClasses = new()
        {
            new YogaClass("Yoga", "Monday 6PM", 10, "Sarah"),
            new StrengthClass("Strength Training", "Tuesday 5PM", 8, "Mike"),
            new ZumbaClass("Zumba", "Wednesday 7PM", 12, "Maria")
        };
        
        //Pre enroll members
        int[] yogaAccounts =
        {
            1001, 2001, 2004, 2007, 2010,
            2013, 2016, 2019, 2022, 2025
        };

        foreach (int accountNumber in yogaAccounts)
        {
            Member? member = memberRepository.GetByAccountNumber(accountNumber);

            if (member != null)
            {
                gymClasses[0].AddMember(member);
            }
        }
        
        int[] strengthAccounts =
        {
            1002, 1003, 2002, 2003, 2005, 2006
        };

        foreach (int accountNumber in strengthAccounts)
        {
            Member? member = memberRepository.GetByAccountNumber(accountNumber);

            if (member != null)
            {
                gymClasses[1].AddMember(member);
            }
        }

        int[] zumbaAccounts =
        {
            3002, 3003, 3005, 3006, 3008, 3009,
            3011, 3012, 3014, 3015, 3017, 3018
        };

        foreach (int accountNumber in zumbaAccounts)
        {
            Member? member = memberRepository.GetByAccountNumber(accountNumber);

            if (member != null)
            {
                gymClasses[2].AddMember(member);
            }
        }

        // Start UI
        ConsoleUI ui = new ConsoleUI(
            memberRepository,
            loginService,
            signUpService,
            checkInService,
            gymClasses
        );

        ui.Start();
    }
}