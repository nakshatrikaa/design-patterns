namespace DesignPatterns.Bridge.MessageExample;

/// <summary>
///     The 'Abstraction' class
/// </summary>
public abstract class Message
{
    public IMessageSender? MessageSender { get; set; }
    public string? Subject { get; init; }
    public string? Body { get; init; }
    public abstract void Send();
}

/// <summary>
///     The 'RefinedAbstraction' class
/// </summary>
public class SystemMessage : Message
{
    public override void Send()
    {
        MessageSender?.SendMessage(Subject, Body);
    }
}

/// <summary>
///     The 'RefinedAbstraction' class
/// </summary>
public class UserMessage : Message
{
    public string? UserComments { get; init; }

    public override void Send()
    {
        var fullBody = $"{Body}\nUser Comments: {UserComments}";
        MessageSender?.SendMessage(Subject, fullBody);
    }
}

/// <summary>
///     The 'Bridge/Implementor' interface
/// </summary>
public interface IMessageSender
{
    void SendMessage(string? subject, string? body);
}

/// <summary>
///     The 'ConcreteImplementor' class
/// </summary>
public class EmailSender : IMessageSender
{
    public void SendMessage(string? subject, string? body)
    {
        Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
    }
}

/// <summary>
///     The 'ConcreteImplementor' class
/// </summary>
public class SmsSender : IMessageSender
{
    public void SendMessage(string? subject, string? body)
    {
        Console.WriteLine("SMS\n{0}\n{1}\n", subject, body);
    }
}

/// <summary>
///     The 'ConcreteImplementor' class
/// </summary>
public class WebServiceSender : IMessageSender
{
    public void SendMessage(string? subject, string? body)
    {
        Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
    }
}