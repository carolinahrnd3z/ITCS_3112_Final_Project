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

