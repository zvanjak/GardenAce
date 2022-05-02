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

      EstatePart part1 = new AuxiliaryBuilding("Skladište", "skladište");
      var partZVrt = new Garden("Zvonin vrt");
      var partIVrt = new Garden("Ivankin vrt");

      vanjak.EstateParts.Add(part1);
      vanjak.EstateParts.Add(partZVrt);
      vanjak.EstateParts.Add(partIVrt);

      GardenPlot zvLuk = new GardenPlot(new DateTime(2022, 2, 1), "Luk", partZVrt);
      partZVrt.CurrentGardenPlots.Add(zvLuk);

      GardenPlot zvSalata = new GardenPlot(new DateTime(2022, 2, 1), "Salata", partZVrt);
      partZVrt.CurrentGardenPlots.Add(zvSalata);

      GardenPlot zvJagode = new GardenPlot(new DateTime(2022, 2, 1), "Jagode", partZVrt);
      partZVrt.CurrentGardenPlots.Add(zvJagode);

      GardenPlot zvKrumpiri = new GardenPlot(new DateTime(2022, 2, 1), "Krumpiri", partZVrt);
      // 6 redova krumpira
      partZVrt.CurrentGardenPlots.Add(zvKrumpiri);

      GardenPlot zvPomidori = new GardenPlot(new DateTime(2022, 4, 1), "Pomidori", partZVrt);
      GardenPlot zvPaprike = new GardenPlot(new DateTime(2022, 4, 1), "Paprike", partZVrt);
      // posađene 10.4.
      // smrzle 17.4.
      // uništene 5.5.
      partZVrt.HistoricalPlots.Add(zvPaprike);
      partZVrt.HistoricalPlots.Add(zvPomidori);

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
