using DesignPatternsDemo.Domain;

namespace DesignPatternsDemo.Discount;

public sealed class DiscountContext
{
    public IDiscountStrategy Strategy { get; private set; }

    public DiscountContext(IDiscountStrategy strategy)
    {
        Strategy = strategy;
    }
}
