using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsDemo.Infrastructure;

// TService: çözülecek arayüz, TKey: anahtar (ShippingType/CustomerType)
public interface IKeyedFactory<out TService, in TKey>
{
    TService Create (TKey key);
}

public sealed class GenericKeyedFactory<TService, TKey> : IKeyedFactory<TService, TKey>
{
    private readonly IServiceProvider _sp;
    public GenericKeyedFactory(IServiceProvider sp) => _sp = sp;

    public TService Create(TKey key) => _sp.GetRequiredKeyedService<TService>(key);
}