namespace DesignPatternsDemo.Discount;

public sealed class DiscountContext
{
    public IDiscountStrategy Strategy { get; private set; }

    public DiscountContext(IDiscountStrategy strategy)
    {
        Strategy = strategy;
    }

    public void SetStrategy(IDiscountStrategy strategy) => Strategy = strategy;

    public decimal Apply(decimal amount) => Strategy.ApplyDiscount(amount);
}
