using MyShop.Domain;

namespace MyShop.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>
{
    public CustomerRepository(ShoppingContext context) : base(context)
    {
    }

    public override Customer Update(Customer entity)
    {
        var customer = _shoppingContext
            .Customers
            .Single(c => c.CustomerId == entity.CustomerId);
        customer.Name = entity.Name;
        customer.City = entity.City;
        customer.Country = entity.Country;
        customer.PostalCode = entity.PostalCode;
        customer.ShippingAddress = entity.ShippingAddress;

        return base.Update(customer);
    }
}