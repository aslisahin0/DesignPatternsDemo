using DesignPatternsDemo.Domain;

namespace DesignPatternsDemo.Discount;

public interface IDiscountStrategyFactory
{
    IDiscountStrategy Create(CustomerType type);
}