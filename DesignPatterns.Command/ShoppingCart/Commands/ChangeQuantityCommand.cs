using DesignPatterns.Command.ShoppingCart.Models;
using DesignPatterns.Command.ShoppingCart.Repositories;

namespace DesignPatterns.Command.ShoppingCart.Commands;

public class ChangeQuantityCommand : ICommand
{
    private readonly Operation _operation;
    private readonly Product _product;
    private readonly IProductRepository _productRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ChangeQuantityCommand(Operation operation, IShoppingCartRepository shoppingCartRepository,
        IProductRepository productRepository, Product product)
    {
        _operation = operation;
        _shoppingCartRepository = shoppingCartRepository;
        _productRepository = productRepository;
        _product = product;
    }

    public void Execute()
    {
        switch (_operation)
        {
            case Operation.Decrease:
                _productRepository.IncreaseStockBy(_product.ArticleId, 1);
                _shoppingCartRepository.DecreaseQuantity(_product.ArticleId);
                break;
            case Operation.Increase:
                _productRepository.IncreaseStockBy(_product.ArticleId, 1);
                _shoppingCartRepository.IncreaseQuantity(_product.ArticleId);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public bool CanExecute()
    {
        return _operation switch
        {
            Operation.Decrease => _productRepository.GetStockFor(_product.ArticleId) != 0,
            Operation.Increase => _productRepository.GetStockFor(_product.ArticleId) - 1 > 0,
            _ => false
        };
    }

    public void Undo()
    {
        switch (_operation)
        {
            case Operation.Decrease:
                _productRepository.IncreaseStockBy(_product.ArticleId, 1);
                _shoppingCartRepository.DecreaseQuantity(_product.ArticleId);
                break;
            case Operation.Increase:
                _productRepository.DecreaseStockBy(_product.ArticleId, 1);
                _shoppingCartRepository.IncreaseQuantity(_product.ArticleId);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}