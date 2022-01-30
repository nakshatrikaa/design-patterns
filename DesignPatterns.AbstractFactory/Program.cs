namespace DesignPatterns.AbstractFactory;

public static class Program
{
    public static void Main(string[] args)
    {
        var abstractFactory = FactoryProducer.GetFactory(false);
        var rectangle = abstractFactory.GetShape("RECTANGLE");
        var square = abstractFactory.GetShape("SQUARE");
        rectangle?.Draw();
        square?.Draw();

        abstractFactory = FactoryProducer.GetFactory(true);
        var roundedRectangle = abstractFactory.GetShape("RECTANGLE");
        var roundedSquare = abstractFactory.GetShape("SQUARE");
        roundedRectangle?.Draw();
        roundedSquare?.Draw();
    }
}

public static class FactoryProducer
{
    public static AbstractFactory GetFactory(bool rounded)
    {
        if (rounded)
            return new RoundedShapeFactory();
        return new ShapeFactory();
    }
}