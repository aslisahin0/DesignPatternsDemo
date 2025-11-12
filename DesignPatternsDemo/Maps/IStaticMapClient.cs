using System.Threading;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Maps;

public interface IStaticMapClient
{
    Task<byte[]> GetMapAsync(MapRequest req, CancellationToken ct = default);
}