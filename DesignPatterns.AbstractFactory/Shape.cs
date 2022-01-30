namespace DesignPatterns.AbstractFactory;
public abstract class Shape
{
    public abstract void Draw();
}

public class Square : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Draw Square");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Draw Rectangle");
    }
}

public class RoundedSquare : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Draw Rounded Square");
    }
}

public class RoundedRectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Draw Rounded Rectangle");
    }
}