namespace DesignPattern.FlyWeight;

/// <summary>
///     The 'Flyweight' interface
/// </summary>
public interface IShape
{
    void Print();
}

/// <summary>
///     A 'ConcreteFlyweight' class
/// </summary>
public class Rectangle : IShape
{
    public void Print()
    {
        Console.WriteLine("Printing Rectangle");
    }
}

/// <summary>
///     A 'ConcreteFlyweight' class
/// </summary>
public class Circle : IShape
{
    public void Print()
    {
        Console.WriteLine("Printing Circle");
    }
}

/// <summary>
///     The 'FlyweightFactory' class
/// </summary>
internal class ShapeObjectFactory
{
    private readonly Dictionary<string, IShape?> _shapes = new();

    public int TotalObjectsCreated => _shapes.Count;

    public IShape? GetShape(string shapeName)
    {
        IShape? shape = null;
        if (_shapes.ContainsKey(shapeName))
            shape = _shapes[shapeName];
        else
            switch (shapeName)
            {
                case "Rectangle":
                    shape = new Rectangle();
                    _shapes.Add("Rectangle", shape);
                    break;
                case "Circle":
                    shape = new Circle();
                    _shapes.Add("Circle", shape);
                    break;
                default:
                    throw new Exception("Factory cannot create the object specified");
            }

        return shape;
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        var sof = new ShapeObjectFactory();

        var shape = sof.GetShape("Rectangle");
        shape?.Print();
        shape = sof.GetShape("Rectangle");
        shape?.Print();
        shape = sof.GetShape("Rectangle");
        shape?.Print();
             
        shape = sof.GetShape("Circle");
        shape?.Print();
        shape = sof.GetShape("Circle");
        shape?.Print();
        shape = sof.GetShape("Circle");
        shape?.Print();

        var numberOfObjects = sof.TotalObjectsCreated;
        Console.WriteLine("\nTotal No of Objects created = {0}", numberOfObjects);
        Console.ReadKey();
    }
}