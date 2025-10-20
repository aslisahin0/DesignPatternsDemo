using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Shipping;

namespace DesignPatternsDemo.Shipping;

public sealed class ShippingServiceFactory : IShippingServiceFactory
{
    public IShippingService Create(ShippingType type) => type switch
    {
        ShippingType.Standard => new StandardShipping(),
        ShippingType.Express => new ExpressShipping(),
        ShippingType.International => new InternationalShipping(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported shipping type.")
    };
}
