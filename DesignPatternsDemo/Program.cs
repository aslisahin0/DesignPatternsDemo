using DesignPatternsDemo.Discount;
using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Shipping;

// Basit demo verileri - hesaplama için
var order = new Order
{
    Total = 1000m,
    Weight = 3.2m
};

ShippingType shippingType = ShippingType.Express;   // buraları değiştirerek deneyebiliriz
CustomerType customerType = CustomerType.Silver;    // buraları değiştirerek deneyebiliriz

//Factory kullanımı: hangi kargo servisi?
IShippingServiceFactory factory = new ShippingServiceFactory();
IShippingService shippingService = factory.Create(shippingType);
decimal shippingCost = shippingService.CalculateShippingCost(order);

//Strategy seçimi: müşteri segmentine göre indirim
IDiscountStrategy strategy = customerType switch
{
    CustomerType.Regular => new NoDiscount(),
    CustomerType.Silver => new PercentageDiscount(0.05m),
    CustomerType.Gold => new PercentageDiscount(0.10m),
    _ => new NoDiscount()
};
var discountContext = new DiscountContext(strategy);

//Hesap
var discountedTotal = discountContext.Apply(order.Total);
var total = discountedTotal + shippingCost;

//Çıktı
Console.WriteLine("=== ORDER SUMMARY ===");
Console.WriteLine($"Total              : {order.Total:C}");
Console.WriteLine($"Discount Strategy  : {discountContext.Strategy.Name}");
Console.WriteLine($"Discounted Total : {discountedTotal:C}");
Console.WriteLine($"Shipping Service   : {shippingService.Name}");
Console.WriteLine($"Shipping Cost      : {shippingCost:C}");
Console.WriteLine($"TOTAL              : {total:C}");

//Strategy'nin runtime değişebilmesi:
Console.WriteLine();
Console.WriteLine("Kampanya başladı! Stratejiyi Gold (%) olarak değiştiriyoruz...");
discountContext.SetStrategy(new PercentageDiscount(0.10m));
var discountedAgain = discountContext.Apply(order.Total);
var totalAfterCampaign = discountedAgain + shippingCost;

Console.WriteLine($"New Strategy       : {discountContext.Strategy.Name}");
Console.WriteLine($"New Total          : {totalAfterCampaign:C}");
