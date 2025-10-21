using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Infrastructure;
using IShippingService = DesignPatternsDemo.Domain.IShippingService;

namespace DesignPatternsDemo.Pricing;

public sealed class OrderPricingService
{
    private readonly IKeyedFactory<IShippingService, ShippingType> _shippingFactory;
    private readonly IKeyedFactory<IDiscountStrategy, CustomerType> _discountFactory;

    public OrderPricingService(IKeyedFactory<IShippingService, ShippingType> shippingFactory,
        IKeyedFactory<IDiscountStrategy, CustomerType> discountFactory)
    {
        _shippingFactory = shippingFactory;
        _discountFactory = discountFactory;
    }

    public OrderPriceBreakdown Calculate(Order order, ShippingType shippingType, CustomerType customerType)
    {
        var shipping = _shippingFactory.Create(shippingType);
        var strategy = _discountFactory.Create(customerType);

        var shippingCost = shipping.CalculateShippingCost(order);
        var discountedTotal = strategy.ApplyDiscount(order.Total);
        var grandTotal = discountedTotal + shippingCost;

        return new OrderPriceBreakdown(
            Subtotal: order.Total,
            DiscountName: strategy.Name,
            DiscountedTotal: discountedTotal,
            ShippingName: shipping.Name,
            ShippingCost: shippingCost,
            GrandTotal: grandTotal
        );
    }
}