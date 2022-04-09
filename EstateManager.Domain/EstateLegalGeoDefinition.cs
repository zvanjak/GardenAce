using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  public class EstateLegalGeoDefinition
  {
    // ima Geo Polyline za definiciju granice
    private List<GeoCoord> borderPoints = new List<GeoCoord>();

    public List<GeoCoord> BorderPoints { get => borderPoints; set => borderPoints = value; }

    public EstateLegalGeoDefinition()
    {
      BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });
    }
  }
}
