namespace DesignPatterns.Prototype;

public interface IEmployee
{
    IEmployee Clone();
    string GetDetails();
}


public class Developer : IEmployee
{
    public string? Name { get; set; }
    public string? Role { get; init; }
    public string? PreferredLanguage { get; init; }

    public IEmployee Clone()
    {
        return (IEmployee)MemberwiseClone();
    }

    public string GetDetails()
    {
        return $"{Name} - {Role} - {PreferredLanguage}";
    }
}

public class Typist : IEmployee
{
    public int WordsPerMinute { get; set; }
    public string? Name { get; set; }
    public string? Role { get; init; }

    public IEmployee Clone()
    {
        return (IEmployee)MemberwiseClone();
    }

    public string GetDetails()
    {
        return $"{Name} - {Role} - {WordsPerMinute}wpm";
    }
}
