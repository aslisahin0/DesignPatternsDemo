using DesignPatternsDemo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsDemo.Shipping;

public sealed class ShippingServiceFactory : IShippingServiceFactory
{
    private readonly IServiceProvider _sp;
    public ShippingServiceFactory(IServiceProvider sp) => _sp = sp;

    public IShippingService Create(ShippingType type) => _sp.GetRequiredKeyedService<IShippingService>(type);
}
