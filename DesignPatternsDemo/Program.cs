using System.IO;
using DesignPatternsDemo.Discount;
using DesignPatternsDemo.Domain;
using DesignPatternsDemo.Infrastructure;
using DesignPatternsDemo.Maps;                 
using DesignPatternsDemo.Pricing;
using DesignPatternsDemo.Shipping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Google.Apis.Auth.OAuth2;

var builder = Host.CreateApplicationBuilder(args);

const string ProjectId = "ekiptakip-e24b2"; //firebase proje idsi
const string ServiceAccountFilePath = @"C:\Users\asli.sahin\Desktop\ekiptakip-e24b2-firebase-adminsdk-fbsvc-79e8b6f7ef.json"; //firebaseden indirdiğimiz json dosyası yolu
const string DeviceToken = "eDHEh2obT9WWE2WHEYO4vo:APA91bF0t09WY8ykE9QQUXjQ4Ayfd3K8OFmxBfmI2kq80Ula8_MECUvqK4WhqM0g2gd11h5EveEc2yqPXhpyvTeSuaEOo2IUWrbQ3nIgfHrzHQr-gg6YFyY"; //mobile device token

// Senkron yöntem - kullanmak istersek ama performanslı değil
// var cred = GoogleCredential.FromFile(ServiceAccountFilePath);

// Async yöntem - CancellationToken ekleyerek kullanıyoruz
var cred = await GoogleCredential.FromFileAsync(ServiceAccountFilePath, CancellationToken.None);

var scoped = cred.CreateScoped("https://www.googleapis.com/auth/firebase.messaging");
var accessToken = await scoped.UnderlyingCredential.GetAccessTokenForRequestAsync(null, CancellationToken.None);

var url = $"https://fcm.googleapis.com/v1/projects/ekiptakip-e24b2/messages:send";

using var http = new HttpClient();
http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

//mesaj detayları
var body = new
{
    message = new
    {
        token = DeviceToken,
        notification = new { title = "Merhaba", body = "Ekip Takip FCM testi" },
        data = new Dictionary<string, string> { ["messageId"] = Guid.NewGuid().ToString() }
    },
    validate_only = false
};

var resp = await http.PostAsJsonAsync(url, body, CancellationToken.None);
var text = await resp.Content.ReadAsStringAsync(CancellationToken.None);

Console.WriteLine($"HTTP {(int)resp.StatusCode}");
Console.WriteLine(text);

if (!resp.IsSuccessStatusCode)
    Environment.Exit(1);

/*
// --- Mevcut fiyatlandırma demosu ---
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

Console.WriteLine();
Console.WriteLine("Kampanya başladı! Stratejiyi Gold (%) olarak değiştiriyoruz...");

var result2 = pricer.Calculate(order, shippingType, CustomerType.Gold);

Console.WriteLine($"New Strategy       : {result2.DiscountName}");
Console.WriteLine($"New Total          : {result2.DiscountedTotal:C}");

*/

/*
// --- Static Maps DEMO (çıktı: map.png) ---
var maps = app.Services.GetRequiredService<IStaticMapClient>();

// Örnel lat ve lng
var req = new MapRequest
{
    Latitude    = 39.912886688482786,
    Longitude   = 32.807309680207894,
    Zoom        = 16,
    Width       = 800,
    Height      = 600,
    Scale       = 2,
    MapType     = "roadmap",
    MarkerColor = "red",
    MarkerLabel = "T"
};

var bytes = await maps.GetMapAsync(req);
await File.WriteAllBytesAsync("map1.png", bytes);
Console.WriteLine("✔ Harita indirildi: map.png");

*/
