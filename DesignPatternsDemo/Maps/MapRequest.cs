using System.Globalization;

namespace DesignPatternsDemo.Maps;

public sealed class MapRequest
{
    public double Latitude  { get; init; }
    public double Longitude { get; init; }
    public int Zoom         { get; init; } = 16;   // 0-21
    public int Width        { get; init; } = 800;  // px
    public int Height       { get; init; } = 600;  // px
    public int Scale        { get; init; } = 2;    // Retina
    public string MapType   { get; init; } = "roadmap"; // roadmap|satellite|terrain|hybrid
    public string MarkerLabel { get; init; } = "A"; // tek karakter
    public string MarkerColor { get; init; } = "red";

    public string ToCenterParam() =>
        $"{Latitude.ToString(CultureInfo.InvariantCulture)}," +
        $"{Longitude.ToString(CultureInfo.InvariantCulture)}";
}
