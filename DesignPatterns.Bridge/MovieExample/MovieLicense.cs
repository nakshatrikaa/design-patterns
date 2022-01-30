namespace DesignPatterns.Bridge.MovieExample;

public class MovieLicense
{
    private readonly Discount _discount;
    private readonly LicenseType _licenseType;

    public MovieLicense(string movie, DateTime purchaseDate, Discount discount, LicenseType licenseType)
    {
        Movie = movie;
        PurchaseDate = purchaseDate;
        _discount = discount;
        _licenseType = licenseType;
    }

    public string Movie { get; }
    private DateTime PurchaseDate { get; }

    private decimal GetBasePrice()
    {
        return _licenseType switch
        {
            LicenseType.TwoDay => 4,
            LicenseType.LifeLong => 40,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public DateTime? GetExpirationDate()
    {
        return _licenseType switch
        {
            LicenseType.TwoDay => PurchaseDate.AddDays(2),
            LicenseType.LifeLong => null,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public decimal GetPrice()
    {
        var discount = GetDiscount();
        var multiplier = 1 - discount / 100m;
        return GetBasePrice() * multiplier;
    }

    private int GetDiscount()
    {
        return _discount switch
        {
            Discount.None => 0,
            Discount.Military => 10,
            Discount.Senior => 20,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}