using DesignPatterns.Bridge.MessageExample;
using DesignPatterns.Bridge.MovieExample;

namespace DesignPatterns.Bridge;

public static class Program
{
    public static void Main()
    {
        //#region MovieExample
        //var now = DateTime.Now;
        //
        //var license1 = new MovieLicense("Secret Life of Pets", now, Discount.Military, LicenseType.LifeLong);
        //var license2 = new MovieLicense("Matrix", now, Discount.None, LicenseType.TwoDay);
        //
        //Helper.PrintLicenseDetails(license1);
        //Helper.PrintLicenseDetails(license2);
        //#endregion


        #region MessageExample
        var email = new EmailSender();
        var queue = new SmsSender();
        var web = new WebServiceSender();

        var message = new SystemMessage
        {
            Subject = "Test Message",
            Body = "Hi, This is a Test Message",
            MessageSender = email
        };

        message.Send();

        message.MessageSender = queue;
        message.Send();

        message.MessageSender = web;
        message.Send();

        var userMessage = new UserMessage
        {
            Subject = "Test Message",
            Body = "Hi, This is a Test Message",
            UserComments = "I hope you are well",

            MessageSender = email
        };
        userMessage.Send(); 
        #endregion
    }
}