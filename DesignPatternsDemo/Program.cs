using DesignPatternsDemo.Discount;
using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Shipping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder(args);

// === DI KAYITLARI (Keyed Services) ===
// Shipping
host.Services.AddKeyedTransient<IShippingService>(ShippingType.Standard, (_, __) => new StandardShipping());
host.Services.AddKeyedTransient<IShippingService>(ShippingType.Express,  (_, __) => new ExpressShipping());
host.Services.AddKeyedTransient<IShippingService>(ShippingType.International, (_, __) => new InternationalShipping());

// Discount
host.Services.AddKeyedTransient<IDiscountStrategy>(CustomerType.Regular, (_, __) => new NoDiscount());
host.Services.AddKeyedTransient<IDiscountStrategy>(CustomerType.Silver,  (_, __) => new PercentageDiscount(0.05m));
host.Services.AddKeyedTransient<IDiscountStrategy>(CustomerType.Gold,    (_, __) => new PercentageDiscount(0.10m));

// Factories (switch yok; Keyed DI kullanıyorlar)
host.Services.AddTransient<IShippingServiceFactory, ShippingServiceFactory>();
host.Services.AddTransient<IDiscountStrategyFactory, DiscountStrategyFactory>();

var app = host.Build();

// === DEMO ===
var order = new Order(Total: 1000m, Weight: 3.2m);

var shippingType  = ShippingType.Express;  // deneyebilirsin
var customerType  = CustomerType.Silver;   // deneyebilirsin

var shippingFactory = app.Services.GetRequiredService<IShippingServiceFactory>();
var discountFactory = app.Services.GetRequiredService<IDiscountStrategyFactory>();

var shippingService = shippingFactory.Create(shippingType);
var discountStrategy = discountFactory.Create(customerType);

var shippingCost     = shippingService.CalculateShippingCost(order);
var discountedTotal  = discountStrategy.ApplyDiscount(order.Total);
var total            = discountedTotal + shippingCost;

Console.WriteLine("=== ORDER SUMMARY ===");
Console.WriteLine($"Total              : {order.Total:C}");
Console.WriteLine($"Discount Strategy  : {discountStrategy.Name}");
Console.WriteLine($"Discounted Total   : {discountedTotal:C}");
Console.WriteLine($"Shipping Service   : {shippingService.Name}");
Console.WriteLine($"Shipping Cost      : {shippingCost:C}");
Console.WriteLine($"TOTAL              : {total:C}");

// Runtime strateji değişimi (kampanya)
Console.WriteLine();
Console.WriteLine("Kampanya başladı! Stratejiyi Gold (%) olarak değiştiriyoruz...");

var campaignStrategy = discountFactory.Create(CustomerType.Gold);
var discountedAgain  = campaignStrategy.ApplyDiscount(order.Total);
var totalAfterCampaign = discountedAgain + shippingCost;

Console.WriteLine($"New Strategy       : {campaignStrategy.Name}");
Console.WriteLine($"New Total          : {totalAfterCampaign:C}");
