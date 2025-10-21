namespace DesignPatternsDemo.Pricing;

public sealed record OrderPriceBreakdown(
    decimal Subtotal,
    string DiscountName,
    decimal DiscountedTotal,
    string ShippingName,
    decimal ShippingCost,
    decimal GrandTotal
);
