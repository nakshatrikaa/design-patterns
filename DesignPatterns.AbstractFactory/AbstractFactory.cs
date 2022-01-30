namespace DesignPatterns.AbstractFactory;

public abstract class AbstractFactory
{
    public abstract Shape? GetShape(string shape);
}

public class ShapeFactory : AbstractFactory
{
    public override Shape? GetShape(string shape)
    {
        return shape switch
        {
            "SQUARE" => new Square(),
            "RECTANGLE" => new Rectangle(),
            _ => null
        };
    }
}

public class RoundedShapeFactory : AbstractFactory
{
    public override Shape? GetShape(string shape)
    {
        return shape switch
        {
            "SQUARE" => new RoundedSquare(),
            "RECTANGLE" => new RoundedRectangle(),
            _ => null
        };
    }
}