namespace DesignPatternsDemo.Domain;

//temel tipleri tek bir dosyada topladık
public enum ShippingType {Standard, Express, International}
public enum CustomerType {Regular, Silver, Gold}

public sealed record Order(decimal Total, decimal Weight)
{
    public decimal Total {get; init;} = Total >= 0 ? Total : throw new ArgumentOutOfRangeException(nameof(Total));
    public decimal Weight {get; init;} = Weight >= 0 ? Weight : throw new ArgumentOutOfRangeException(nameof(Weight));
}

public interface IShippingService
{ 
    string Name { get; }
    decimal CalculateShippingCost(Order order);
}

public interface IDiscountStrategy
{
    string Name { get; }
    decimal ApplyDiscount(decimal amount);
}