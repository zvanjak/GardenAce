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

      double lat1 = x2;
      double lon1 = y2;
      double lat2 = x3;
      double lon2 = y3;

      double R = 6371e3; // metres
      double phi1 = lat1 * Math.PI / 180; // φ, λ in radians
      double phi2 = lat2 * Math.PI / 180;
      double deltaPhi = (lat2 - lat1) * Math.PI / 180;
      double deltaLat = (lon2 - lon1) * Math.PI / 180;

      double a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                Math.Cos(phi1) * Math.Cos(phi2) *
                Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2);
      double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

      double d = R * c; // in metres
    }
  }
}
