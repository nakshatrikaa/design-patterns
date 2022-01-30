namespace DesignPatterns.Decorator;

public static class Program
{
    public static void Main(string[] args)
    {
        var luxuryCar = new LuxuryCar();
        var sportsAccessories = new SportsAccessories(luxuryCar);
        var basicAccessories = new BasicAccessories(sportsAccessories);
        Console.WriteLine(basicAccessories.GetDescription());
        Console.WriteLine(basicAccessories.GetCost());
    }
}

public interface ICar
{
    string GetDescription();
    double GetCost();
}

public sealed class BasicCar : ICar
{
    public string GetDescription()
    {
        return "basic car";
    }

    public double GetCost()
    {
        return 500000;
    }
}

public sealed class MidRangeCar : ICar
{
    public string GetDescription()
    {
        return "Mid Range Car";
    }

    public double GetCost()
    {
        return 1000000;
    }
}

public sealed class LuxuryCar : ICar
{
    public string GetDescription()
    {
        return "Luxury Car";
    }

    public double GetCost()
    {
        return 2000000;
    }
}

public abstract class CarAccessoriesDecorator : ICar
{
    private readonly ICar _car;

    protected CarAccessoriesDecorator(ICar car)
    {
        _car = car;
    }

    public virtual string GetDescription()
    {
        return _car.GetDescription();
    }

    public virtual double GetCost()
    {
        return _car.GetCost();
    }
}

public class BasicAccessories : CarAccessoriesDecorator
{
    public BasicAccessories(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + " with Basic Accessories Package";
    }

    public override double GetCost()
    {
        return base.GetCost() + 100000;
    }
}

public class AdvancedAccessories : CarAccessoriesDecorator
{
    public AdvancedAccessories(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + " with Advanced Accessories Package";
    }

    public override double GetCost()
    {
        return base.GetCost() + 200000;
    }
}

public class SportsAccessories : CarAccessoriesDecorator
{
    public SportsAccessories(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + " with Sports Accessories Package";
    }

    public override double GetCost()
    {
        return base.GetCost() + 250000;
    }
}