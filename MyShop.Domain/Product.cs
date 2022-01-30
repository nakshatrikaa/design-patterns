using System.ComponentModel.DataAnnotations;

namespace MyShop.Domain;

public class Product
{
    public Product()
    {
        ProductId = Guid.NewGuid();
    }

    [Key]
    public Guid ProductId { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }
}