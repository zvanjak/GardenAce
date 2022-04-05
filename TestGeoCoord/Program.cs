using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeoCoord
{
  internal class Program
  {
    static void Main(string[] args)
    {
      double x1 = 45.73779885083265;
      double y1 = 15.936093764979713;

      double x2 = 45.73775302153398;
      double y2 = 15.93626284812708;

      double x3 = 45.735977758275176;
      double y3 = 15.93523577830417;

      double x4 = 45.735962290389196;
      double y4 = 15.935010881339498;

      double lat1 = x1;
      double lon1 = y1;
      double lat2 = x2;
      double lon2 = y2;

      const double R = 6371e3; // metres
      const double phi1 = lat1 * Math.PI / 180; // φ, λ in radians
      const double phi2 = lat2 * Math.PI / 180;
      const double deltaPhi = (lat2 - lat1) * Math.PI / 180;
      const double deltaLat = (lon2 - lon1) * Math.PI / 180;

      const a = Math.sin(Δφ / 2) * Math.sin(Δφ / 2) +
                Math.cos(φ1) * Math.cos(φ2) *
                Math.sin(Δλ / 2) * Math.sin(Δλ / 2);
      const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));

      const d = R * c; // in metres
    }
  }
}
