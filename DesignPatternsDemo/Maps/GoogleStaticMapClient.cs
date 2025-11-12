using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Options;

namespace DesignPatternsDemo.Maps;

public sealed class GoogleStaticMapClient(HttpClient http, IOptions<GoogleMapsOptions> opt) : IStaticMapClient
{
    private readonly HttpClient _http = http;
    private readonly string _apiKey = opt.Value.StaticMapsApiKey;

    public async Task<byte[]> GetMapAsync(MapRequest r, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(_apiKey))
            throw new InvalidOperationException("Google Static Maps API key is missing (Google:StaticMapsApiKey).");

        var baseUrl = "https://maps.googleapis.com/maps/api/staticmap";
        var markers = $"color:{r.MarkerColor}|label:{Uri.EscapeDataString(r.MarkerLabel)}|{r.ToCenterParam()}";

        var sb = new StringBuilder();
        sb.Append($"{baseUrl}?");
        sb.Append($"center={Uri.EscapeDataString(r.ToCenterParam())}");
        sb.Append($"&zoom={r.Zoom}");
        sb.Append($"&size={r.Width}x{r.Height}");
        sb.Append($"&scale={r.Scale}");
        sb.Append($"&maptype={Uri.EscapeDataString(r.MapType)}");
        sb.Append($"&markers={Uri.EscapeDataString(markers)}");
        sb.Append($"&key={_apiKey}");

        return await _http.GetByteArrayAsync(sb.ToString(), ct);
    }
}