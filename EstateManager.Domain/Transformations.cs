using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  public class Transformations
  {
    public static double Distance(GeoCoord g1, GeoCoord g2)
    {
      double lat1 = g1.Latitude;
      double lon1 = g1.Longitude;
      double lat2 = g2.Latitude;
      double lon2 = g2.Longitude;

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

      return d;
    }

    public static void LocalCoord(GeoCoord origin, GeoCoord pnt, out double x, out double y)
    {
      GeoCoord sameLat = new GeoCoord() { Latitude = origin.Latitude, Longitude = pnt.Longitude };
      GeoCoord sameLon = new GeoCoord() { Latitude = pnt.Latitude, Longitude = origin.Longitude };

      x = Distance(origin, sameLat);
      if (pnt.Longitude < origin.Longitude)
        x *= -1;

      y = Distance(origin, sameLon);
      if (pnt.Latitude < origin.Latitude)
        y *= -1;

      // još rotacija
      double phi = 19.9055 * 3.14159 / 180;
      x = x * Math.Cos(phi) - y * Math.Sin(phi);
      y = x * Math.Sin(phi) + y * Math.Cos(phi);
    }
  }
}
