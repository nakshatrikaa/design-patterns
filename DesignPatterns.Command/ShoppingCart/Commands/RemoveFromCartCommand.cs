using DesignPatterns.Command.ShoppingCart.Models;
using DesignPatterns.Command.ShoppingCart.Repositories;

namespace DesignPatterns.Command.ShoppingCart.Commands;

public class RemoveFromCartCommand : ICommand
{
    private readonly Product _product;
    private readonly IProductRepository _productRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public RemoveFromCartCommand(IShoppingCartRepository shoppingCartRepository,
        IProductRepository productRepository,
        Product product)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _productRepository = productRepository;
        _product = product;
    }

    public bool CanExecute()
    {
        return _shoppingCartRepository.Get(_product.ArticleId).Quantity > 0;
    }

    public void Execute()
    {
        var lineItem = _shoppingCartRepository.Get(_product.ArticleId);

        _productRepository.IncreaseStockBy(_product.ArticleId, lineItem.Quantity);

        _shoppingCartRepository.RemoveAll(_product.ArticleId);
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}