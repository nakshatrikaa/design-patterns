using DesignPatterns.Command.Switch;

namespace DesignPatterns.Command;

public static class Program
{
    public static void Main()
    {
        #region ShoppingCart
        //var shoppingCartRepository = new ShoppingCartRepository();
        //var productRepository = new ProductsRepository();
        //
        //var product = productRepository.FindBy("SM7B");
        //
        //var addToCartCommand = new AddToCardCommand(shoppingCartRepository, productRepository, product);
        //
        //var increaseQuantity =
        //    new ChangeQuantityCommand(Operation.Increase, shoppingCartRepository, productRepository, product);
        //var decreaseQuantity =
        //    new ChangeQuantityCommand(Operation.Decrease, shoppingCartRepository, productRepository, product);
        //var removeAll =
        //    new RemoveAllFromCartCommand(shoppingCartRepository, productRepository);
        //var removeProduct =
        //    new RemoveFromCartCommand(shoppingCartRepository, productRepository, product);
        //
        //var manager = new CommandManager();
        //manager.Invoke(addToCartCommand);
        //manager.Invoke(increaseQuantity);
        //manager.Invoke(increaseQuantity);
        //manager.Invoke(increaseQuantity);
        //manager.Invoke(increaseQuantity);
        //
        //PrintCart(shoppingCartRepository);
        //manager.Undo();
        //PrintCart(shoppingCartRepository);
        #endregion

        #region Switch
        Console.WriteLine("Enter Commands (ON/OFF) : ");
        var cmd = Console.ReadLine();

        var lamp = new Light();
        var switchUp = new FlipUpCommand(lamp);
        var switchDown = new FlipDownCommand(lamp);

        var s = new Switch.Switch();

        if (cmd == "ON")
        {
            s.StoreAndExecute(switchUp);
        }
        else if (cmd == "OFF")
        {
            s.StoreAndExecute(switchDown);
        }
        else
        {
            Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
        }
        #endregion
    }

    //private static void PrintCart(ShoppingCartRepository shoppingCartRepository)
    //{
    //    var totalPrice = 0m;
    //    foreach (var (key, (product, quantity)) in shoppingCartRepository.LineItems)
    //    {
    //        var price = product.Price * quantity;

    //        Console.WriteLine($"{key} " +
    //                          $"${product.Price} x {quantity} = ${price}");

    //        totalPrice += price;
    //    }

    //    Console.WriteLine($"Total price:\t${totalPrice}");
    //}
}