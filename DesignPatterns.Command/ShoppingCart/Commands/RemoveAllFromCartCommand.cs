using DesignPatterns.Command.ShoppingCart.Repositories;

namespace DesignPatterns.Command.ShoppingCart.Commands;

public class RemoveAllFromCartCommand : ICommand
{
    private readonly IProductRepository _productRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public RemoveAllFromCartCommand(IShoppingCartRepository shoppingCartRepository,
        IProductRepository productRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _productRepository = productRepository;
    }

    public bool CanExecute()
    {
        return _shoppingCartRepository.All().Any();
    }

    public void Execute()
    {
        var items = _shoppingCartRepository.All().ToArray(); // Make a local copy

        foreach (var (product, quantity) in items)
        {
            _productRepository.IncreaseStockBy(product.ArticleId, quantity);

            _shoppingCartRepository.RemoveAll(product.ArticleId);
        }
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}