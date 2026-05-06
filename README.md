# Gym Management System

## 1. Project Overview
This project is a console based gym management system that is designed to manage members, faculty, gym classes, and check in operations. Its intent is to assist staff in efficiently handling check in, scheduling, and class enrollment. 
Core features include:
* Member and faculty management
* Gym class scheduling
* Class enrollment with capacity constraints
* Check-in system for members
* Flexible search using multiple strategies

## 2. Build & Run Instructions

### Tools and Technologies Used
- Language: C#
- Framework: .NET
- IDE: JetBrains Rider
- Project Type: Console Application

### Steps to Build and Run
1. Open the project in JetBrains Rider.
2. Restore any required .NET dependencies if prompted.
3. Build the solution.
4. Run the project using the IDE run button or by running the project through the terminal.
5. Log in using one of the seeded faculty accounts.

### Faculty Login Credentials
| Username | Password |
|-----------|-----------|
| jillian | password123 |
| sarah | pass123 |
| mike | pass123 |

### Notes
- The system comes preloaded with members, faculty accounts, and gym classes.
- Some gym classes already contain enrolled members.
- At least one class is intentionally filled to demonstrate class capacity restrictions.
- Members can be searched using:
  - Name
  - Email
  - Phone Number
  - Account Number

## 3. Required OOP Features
| OOP Feature | File Name                                                                                | Line Numbers | Reasoning / Purpose                                              |
|------------|------------------------------------------------------------------------------------------|--------------|------------------------------------------------------------------|
| Console Input/Output | ConsoleUI.cs                                                                             | All          | Handles user interaction through console input and output     |
| Inheritance (1st) | Person.cs, Faculty.cs, Member.cs                                                         | All          | Faculty and Member inherit from Person to reuse shared attributes |
| Inheritance (2nd) | GymClass.cs, YogaClass.cs, StrengthClass.cs, ZumbaClass.cs                               | All          | Specialized gym classes inherit from GymClass                    |
| Interface Implementation (1st) | IMemberRepository.cs, MemberRepository.cs                                                | All          | Handles storing and retrieving members                           |
| Interface Implementation (2nd) | IFacultyRepository.cs, FacultyRepository.cs                                              | All          | Handles storing and retrieving faculty                           |
| Interface Implementation (3rd) | ICheckInService.cs, CheckInService.cs                                                    | All          | Manages member check-in logic                                    |
| Polymorphism (1st) | YogaClass.cs, StrengthClass.cs, ZumbaClass.cs                                            | 22           | Each class has own rules for enrollment                          |
| Polymorphism (2nd) | SearchStrategy.cs, NameSearch.cs, EmailSearch.cs, PhoneSearch.cs, AccountNumberSearch.cs | All          | Different search strategies used interchangeably                 |
| Enum | MembershipEnum.cs                                                                        | All          | Stores fixed membership types                                    |
| Data Structure | MemberRepository.cs, FacultyRepository.cs                                                | 7            | Stores lists of members and faculty                              |
| Struct | Schedule.cs                                                                              | All          | Stores day and time together used to represent class scheduling  |

## 4. Design Patterns
| Pattern | Category | File Name                                                  | Line Numbers | Rationale                                                                            |
|----------|----------|------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------|
| Strategy Pattern | Behavioral | SearchStrategy.cs, NameSearch.cs, EmailSearch.cs, PhoneSearch.cs, AccountNumberSearch.cs                          | All          | Allows the program to switch search types easily                                     |
| Template Method Pattern | Behavioral | GymClass.cs, YogaClass.cs, StrengthClass.cs, ZumbaClass.cs | All          | GymClass defines structure while allowing subclass customization via ApplyClassRules |
| Factory Method Pattern | Creational | GymClassFactory.cs                                         | All          | Creates different gym class objects                                                  |

## 5. Design Decisions
This project was designed using object-oriented programming principles to separate responsibilities between classes and improve maintainability. The system separates data management, business logic, and user interaction into repositories, services, domain classes, and the console interface.

Repositories were used to manage member and faculty storage separately from application logic. Services were used to handle operations such as login authentication, member check-in, and gym class enrollment. This follows the Single Responsibility Principle by ensuring each class focuses on one primary purpose.

Inheritance was used to reduce duplicated code and support specialization. Member and Faculty inherit from Person to reuse shared contact information. GymClass acts as an abstract base class that allows specialized class types such as YogaClass, StrengthClass, and ZumbaClass to implement their own enrollment rules.

The Strategy Pattern was implemented to support multiple search methods without modifying the check-in system. Search types such as NameSearch, EmailSearch, PhoneSearch, and AccountNumberSearch can be swapped dynamically during runtime.

The Template Method Pattern was used in GymClass through the ApplyClassRules method. GymClass defines the overall enrollment process while subclasses customize specific membership restrictions.

A Factory Method was used to centralize the creation of gym class objects and reduce repeated object creation logic within the program.

Lists were used as the primary data structure to store members, faculty, checked-in members, and enrolled class members. This allowed flexible management of dynamic collections throughout the system.

The console interface was intentionally kept separate from repositories and services so that ConsoleUI primarily handles user interaction and menu flow while business logic remains inside service classes.
