using System;
using System.IO;

using EstateManager.Domain;

namespace EstateManager.ConsoleApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      EstateGeoDefinition LegalGeoDefinition = new EstateGeoDefinition();

      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      LegalGeoDefinition._localOrigin = LegalGeoDefinition.BorderPoints[1];
      LegalGeoDefinition._localRotation = 19.9055 * 3.14159 / 180;

      GeoCoord origin = LegalGeoDefinition.BorderPoints[1];

      for( int i= 0; i < 4; i++ )
      {
        int j = (i + 1) % 4;
        double dist = Transformations.Distance(LegalGeoDefinition.BorderPoints[i], LegalGeoDefinition.BorderPoints[j]);
        Console.WriteLine("Dist {0}-{1} = {2}", i, j, dist);

        GeoCoord pnt = LegalGeoDefinition.BorderPoints[i];

        double x, y;
        Transformations.LocalCoord(origin, pnt, out x, out y);

        Console.WriteLine("Coord [{0}] = {1}, {2}", i, x, y);
      }
    }
  }
}
