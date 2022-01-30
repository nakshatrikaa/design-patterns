using DesignPatterns.Command.ShoppingCart.Models;
using DesignPatterns.Command.ShoppingCart.Repositories;

namespace DesignPatterns.Command.ShoppingCart.Commands;

public class AddToCardCommand : ICommand
{
    private readonly Product _product;
    private readonly IProductRepository _productRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public AddToCardCommand(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository,
        Product product)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _productRepository = productRepository;
        _product = product;
    }

    public bool CanExecute()
    {
        return _productRepository.GetStockFor(_product.ArticleId) > 0;
    }

    public void Execute()
    {
        _productRepository.DecreaseStockBy(_product.ArticleId, 1);
        _shoppingCartRepository.Add(_product);
    }

    public void Undo()
    {
        var lineItem = _shoppingCartRepository.Get(_product.ArticleId);
        _productRepository.IncreaseStockBy(_product.ArticleId, lineItem.Quantity);
        _shoppingCartRepository.RemoveAll(_product.ArticleId);
    }
}