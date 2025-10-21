using DesignPatternsDemo.Discount;
using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Infrastructure;
using DesignPatternsDemo.Pricing;
using DesignPatternsDemo.Shipping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddPricingDemo();

var app = builder.Build();

var order = new Order(Total: 1000m, Weight: 3.2m);
var shippingType = ShippingType.Express;
var customerType = CustomerType.Silver;

var pricer = app.Services.GetRequiredService<OrderPricingService>();
var result = pricer.Calculate(order, shippingType, customerType);


Console.WriteLine("=== ORDER SUMMARY ===");
Console.WriteLine($"Total              : {result.Subtotal:C}");
Console.WriteLine($"Discount Strategy  : {result.DiscountName}");
Console.WriteLine($"Discounted Total   : {result.DiscountedTotal:C}");
Console.WriteLine($"Shipping Service   : {result.ShippingName}");
Console.WriteLine($"Shipping Cost      : {result.ShippingCost:C}");
Console.WriteLine($"TOTAL              : {result.GrandTotal:C}");

// Runtime strateji değişimi (kampanya)
Console.WriteLine();
Console.WriteLine("Kampanya başladı! Stratejiyi Gold (%) olarak değiştiriyoruz...");

var result2 = pricer.Calculate(order, shippingType, CustomerType.Gold);

Console.WriteLine($"New Strategy       : {result2.DiscountName}");
Console.WriteLine($"New Total          : {result2.DiscountedTotal:C}");
