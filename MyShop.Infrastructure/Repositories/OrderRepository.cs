using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain;

namespace MyShop.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>
{
    public OrderRepository(ShoppingContext context) : base(context)
    {
    }

    public override Order Update(Order entity)
    {
        var order = _shoppingContext
            .Orders
            .Include(o=>o.LineItems)
            .ThenInclude(o=>o.Product)
            .Single(o => o.OrderId == entity.OrderId);

        order.OrderDate = entity.OrderDate;
        order.LineItems = entity.LineItems;
        return base.Update(order);
    }

    public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
    {
        return _shoppingContext.Orders
            .Include(x=>x.LineItems)
            .ThenInclude(x=>x.Product)
            .Where(predicate)
            .ToList();
    }
}