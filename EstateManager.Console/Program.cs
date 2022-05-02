using System;
using System.IO;

using EstateManager.Domain;

namespace EstateManager.ConsoleApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      EstateGeoDefinition geoDefinition = new EstateGeoDefinition();

      geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      geoDefinition._localOrigin = geoDefinition.BorderPoints[1];
      geoDefinition._localRotation = 19.9055 * 3.14159 / 180;

      Estate vanjak = new Estate(geoDefinition);

      EstatePart part1 = new EstatePart("Skladište", "skladište");
      EstatePart partZVrt = new Garden("Zvonin vrt");
      EstatePart partIVrt = new Garden("Ivankin vrt");


      vanjak.EstateParts.Add(part1);
      vanjak.EstateParts.Add(partZVrt);
      vanjak.EstateParts.Add(partIVrt);

      TestDistances(geoDefinition);
    }

    static void TestDistances(EstateGeoDefinition geoDefinition)
    {
      GeoCoord origin = geoDefinition.BorderPoints[1];

      for (int i = 0; i < 4; i++)
      {
        int j = (i + 1) % 4;
        double dist = Transformations.Distance(geoDefinition.BorderPoints[i], geoDefinition.BorderPoints[j]);
        Console.WriteLine("Dist {0}-{1} = {2}", i, j, dist);

        GeoCoord pnt = geoDefinition.BorderPoints[i];

        double x, y;
        Transformations.LocalCoord(origin, pnt, out x, out y);

        Console.WriteLine("Coord [{0}] = {1}, {2}", i, x, y);
      }
    }
  }
}
