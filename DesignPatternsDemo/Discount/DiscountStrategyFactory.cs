using DesignPatternsDemo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsDemo.Discount;

public sealed class DiscountStrategyFactory : IDiscountStrategyFactory
{
    private readonly IServiceProvider _sp;
    
    public DiscountStrategyFactory (IServiceProvider sp) => _sp = sp;
    
    public IDiscountStrategy Create(CustomerType type)
        => _sp.GetRequiredKeyedService<IDiscountStrategy>(type);}