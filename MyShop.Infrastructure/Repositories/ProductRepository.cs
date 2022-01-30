using MyShop.Domain;

namespace MyShop.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(ShoppingContext context) : base(context)
    {
    }

    public override Product Update(Product entity)
    {
        var product = _shoppingContext.Products
            .Single(p => p.ProductId == entity.ProductId);
        product.Name = entity.Name;
        product.Price = entity.Price;

        return base.Update(product);
    }
}