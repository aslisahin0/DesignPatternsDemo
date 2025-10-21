using DesignPatternsDemo.Domain;

namespace DesignPatternsDemo.Discount;

public sealed class PercentageDiscount : IDiscountStrategy
{
    private readonly decimal _rate; // 0.05 = %5
    public PercentageDiscount(decimal rate) => _rate = rate;

    public string Name => $"Percentage Discount ({_rate:P0})";

    public decimal ApplyDiscount(decimal amount)
    {
        var discount = amount * _rate;
        return amount - discount;
    }
}
