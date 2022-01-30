namespace DesignPatterns.Command.Switch;

/// <summary>
///     The 'Command' interface
/// </summary>
public interface ICommand
{
    void Execute();
}

/// <summary>
///     The 'Invoker' class
/// </summary>
public class Switch
{
    private readonly List<ICommand> _commands = new();

    public void StoreAndExecute(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}

/// <summary>
///     The 'Receiver' class
/// </summary>
public class Light
{
    public static void TurnOn()
    {
        Console.WriteLine("The light is on");
    }

    public static void TurnOff()
    {
        Console.WriteLine("The light is off");
    }
}

/// <summary>
///     The Command for turning on the light - ConcreteCommand #1
/// </summary>
public class FlipUpCommand : ICommand
{
    private readonly Light _light;

    public FlipUpCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        Light.TurnOn();
    }
}

/// <summary>
///     The Command for turning off the light - ConcreteCommand #2
/// </summary>
public class FlipDownCommand : ICommand
{
    private Light _light;

    public FlipDownCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        Light.TurnOff();
    }
}