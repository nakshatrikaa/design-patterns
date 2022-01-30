using System.Collections;

namespace DesignPatterns.Composite;

/// <summary>
///     The 'Component' Treenode
/// </summary>
public interface IEmployed
{
    int EmpId { get; }
    string? Name { get; }
}

/// <summary>
///     The 'Composite' class
/// </summary>
public class Employee : IEmployed, IEnumerable<IEmployed>
{
    private readonly List<IEmployed> _subordinates = new();

    public int EmpId { get; init; }
    public string? Name { get; init; }

    public IEnumerator<IEmployed> GetEnumerator()
    {
        foreach (var subordinate in _subordinates) 
            yield return subordinate;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddSubordinate(IEmployed subordinate)
    {
        _subordinates.Add(subordinate);
    }
}

/// <summary>
///     The 'Leaf' class
/// </summary>
public class Contractor : IEmployed
{
    public int EmpId { get; init; }
    public string? Name { get; init; }
}

public static class Program
{
    private static void Main(string[] args)
    {
        var rahul = new Employee { EmpId = 1, Name = "Rahul" };

        var amit = new Employee { EmpId = 2, Name = "Amit" };
        var mohan = new Employee { EmpId = 3, Name = "Mohan" };

        rahul.AddSubordinate(amit);
        rahul.AddSubordinate(mohan);

        var rita = new Employee { EmpId = 4, Name = "Rita" };
        var hari = new Employee { EmpId = 5, Name = "Hari" };

        amit.AddSubordinate(rita);
        amit.AddSubordinate(hari);

        var kamal = new Employee { EmpId = 6, Name = "Kamal" };
        var raj = new Employee { EmpId = 7, Name = "Raj" };

        var sam = new Contractor { EmpId = 8, Name = "Sam" };
        var tim = new Contractor { EmpId = 9, Name = "Tim" };

        mohan.AddSubordinate(kamal);
        mohan.AddSubordinate(raj);
        mohan.AddSubordinate(sam);
        mohan.AddSubordinate(tim);

        Console.WriteLine("EmpID={0}, Name={1}", rahul.EmpId, rahul.Name);

        foreach (var employed in rahul)
        {
            var manager = (Employee)employed;
            Console.WriteLine("\n EmpID={0}, Name={1}", manager.EmpId, manager.Name);

            foreach (var employee in manager)
                Console.WriteLine(" \t EmpID={0}, Name={1}", employee.EmpId, employee.Name);
        }

        Console.ReadKey();
    }
}