namespace DefaultNamespace;

public class GymClassFactory
{
    public static GymClass? CreateGymClass(
        string type,
        string name,
        Schedule schedule,
        int capacity,
        string instructor)
    {
        return type switch
        {
            "1" => new YogaClass(name, schedule, capacity, instructor),
            "2" => new StrengthClass(name, schedule, capacity, instructor),
            "3" => new ZumbaClass(name, schedule, capacity, instructor),
            _ => null
        };
    }
}