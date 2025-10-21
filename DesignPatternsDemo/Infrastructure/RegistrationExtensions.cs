// /Infrastructure/RegistrationExtensions.cs
using DesignPatternsDemo.Discount;
using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Shipping;
using Microsoft.Extensions.DependencyInjection;
using IDiscountStrategy = DesignPatternsDemo.Domain.IDiscountStrategy;
using IShippingService = DesignPatternsDemo.Domain.IShippingService;

namespace DesignPatternsDemo.Infrastructure;

public static class RegistrationExtensions
{
    public static IServiceCollection AddPricingDemo(this IServiceCollection services)
    {
        // Keyed registrations — Shipping
        services.AddKeyedTransient<IShippingService>(ShippingType.Standard,       (_, __) => new StandardShipping());
        services.AddKeyedTransient<IShippingService>(ShippingType.Express,        (_, __) => new ExpressShipping());
        services.AddKeyedTransient<IShippingService>(ShippingType.International,  (_, __) => new InternationalShipping());

        // Keyed registrations — Discount
        services.AddKeyedTransient<IDiscountStrategy>(CustomerType.Regular, (_, __) => new NoDiscount());
        services.AddKeyedTransient<IDiscountStrategy>(CustomerType.Silver,  (_, __) => new PercentageDiscount(0.05m));
        services.AddKeyedTransient<IDiscountStrategy>(CustomerType.Gold,    (_, __) => new PercentageDiscount(0.10m));

        // Generic factories (tek sınıf, iki arayüz)
        services.AddTransient<IKeyedFactory<IShippingService,  ShippingType>,  GenericKeyedFactory<IShippingService,  ShippingType>>();
        services.AddTransient<IKeyedFactory<IDiscountStrategy, CustomerType>,  GenericKeyedFactory<IDiscountStrategy, CustomerType>>();

        // Pricing service
        services.AddTransient<Pricing.OrderPricingService>();

        return services;
    }
}