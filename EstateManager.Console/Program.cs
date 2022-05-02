using System;
using System.IO;

using EstateManager.Domain;

namespace EstateManager.ConsoleApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      EstateGeoDefinition def = new EstateGeoDefinition();

      GeoCoord origin = def.BorderPoints[1];

      for( int i= 0; i < 4; i++ )
      {
        int j = (i + 1) % 4;
        double dist = Transformations.Distance(def.BorderPoints[i], def.BorderPoints[j]);
        Console.WriteLine("Dist {0}-{1} = {2}", i, j, dist);

        GeoCoord pnt = def.BorderPoints[i];

        double x, y;
        Transformations.LocalCoord(origin, pnt, out x, out y);

        Console.WriteLine("Coord [{0}] = {1}, {2}", i, x, y);
      }
    }
  }
}
