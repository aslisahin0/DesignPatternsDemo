namespace DesignPatternsDemo.Discount;

public interface IDiscountStrategy
{
    string Name { get; }
    decimal ApplyDiscount(decimal amount);
}
