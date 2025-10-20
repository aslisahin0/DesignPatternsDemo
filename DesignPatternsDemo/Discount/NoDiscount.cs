namespace DesignPatternsDemo.Discount;

public sealed class NoDiscount : IDiscountStrategy
{
    public string Name => "No Discount";
    public decimal ApplyDiscount(decimal amount) => amount;
}
