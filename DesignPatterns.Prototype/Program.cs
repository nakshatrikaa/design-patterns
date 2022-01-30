namespace DesignPatterns.Prototype;


public static class Program
{
    public static void Main(string[] args)
    {
        var dev = new Developer
        {
            Name = "Rahul",
            Role = "Team Leader",
            PreferredLanguage = "C#"
        };

        var devCopy = (Developer)dev.Clone();
        devCopy.Name = "Arif"; 

        Console.WriteLine(dev.GetDetails());
        Console.WriteLine(devCopy.GetDetails());

        var typist = new Typist
        {
            Name = "Monu",
            Role = "Typist",
            WordsPerMinute = 120
        };

        var typistCopy = (Typist)typist.Clone();
        typistCopy.Name = "Sahil";
        typistCopy.WordsPerMinute = 115; 

        Console.WriteLine(typist.GetDetails());
        Console.WriteLine(typistCopy.GetDetails());
    }
}