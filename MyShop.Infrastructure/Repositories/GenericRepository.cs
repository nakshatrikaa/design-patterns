using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories;

public abstract class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly ShoppingContext _shoppingContext;

    protected GenericRepository(ShoppingContext context)
    {
        _shoppingContext = context;
    }

    public virtual T Add(T entity)
    {
        return _shoppingContext.Add(entity).Entity;
    }

    public virtual T Delete(T entity)
    {
        return _shoppingContext.Remove(entity).Entity;
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _shoppingContext.Set<T>()
            .AsQueryable()
            .Where(predicate)
            .ToList();
    }

    public virtual T Get(Guid id)
    {
        return _shoppingContext.Find<T>(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _shoppingContext.Set<T>().ToList();
    }

    public virtual void SaveChanges()
    {
        _shoppingContext.SaveChanges();
    }

    public virtual T Update(T entity)
    {
        return _shoppingContext.Update(entity).Entity;
    }
}