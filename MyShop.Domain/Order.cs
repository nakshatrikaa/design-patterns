using System.ComponentModel.DataAnnotations;

namespace MyShop.Domain;

public class Order
{
    public Order()
    {
        OrderId = Guid.NewGuid();
        OrderDate = DateTime.UtcNow;
    }

    [Key]
    public Guid OrderId { get; set; }
    public virtual ICollection<LineItem> LineItems { get; set; } = null!;
    public virtual Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal? OrderTotal => LineItems.Sum(item => item.Product.Price * item.Quantity);
}