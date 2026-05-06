namespace ITCS_3112_Final_Project.Domain;

public struct Schedule
{
    public string Day { get; set; }
    public string Time { get; set; }
    
    public Schedule(string day, string time)
    {
        Day = day;
        Time = time;
    }

    public override string ToString()
    {
        return $"{Day} at {Time}";
    }
}