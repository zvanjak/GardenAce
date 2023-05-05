using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using MML;

namespace EstateManager.Domain
{
  public class Estate
  {
    private string _name;   // Dupci, Sukošan, Silba
    private EstateGeoDefinition _geoDefinition = new EstateGeoDefinition();
    private List<EstatePart> _estateParts = new List<EstatePart>();
    private Polygon2D _localPolygon = new Polygon2D();

    public string Name { get => _name; set => _name = value; }
    public EstateGeoDefinition GeoDefinition { get => _geoDefinition; set => _geoDefinition = value; }
    public List<EstatePart> EstateParts { get => _estateParts; private set => _estateParts = value; }
    public Polygon2D LocalPolygon { get => _localPolygon; set => _localPolygon = value; }

    public Estate()
    {
      // default je Dupci estate
      // 45.737774310840095, 15.9361033817858

      // 45.73772428456304, 15.936276087548153
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73772428456304, Longitude = 15.936276087548153 });


      // 45.73774176015075, 15.93628690225894
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73774176015075, Longitude = 15.93628690225894 });
      // 45.73768836450996, 15.936436862147854
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73768836450996, Longitude = 15.936436862147854 });
      // 45.73602642882802,  15.935445141650932
      // 45.736014194747696, 15.93546059193996
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.736014194747696, Longitude = 15.93546059193996 });

      // 45.735969384390636, 15.935230800764753
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735969384390636, Longitude = 15.935230800764753 });
      // 45.7359427208678, 15.934999526309937
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.7359427208678, Longitude = 15.934999526309937 });

      // 45.735969384390636, 15.935230800764753
      //GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      //// 45.7359427208678, 15.934999526309937
      //GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      // 45.73777202134561, 15.936115155016035
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73777202134561, Longitude = 15.936115155016035 });

      GeoDefinition._localOrigin = GeoDefinition.BorderPoints[0];
      GeoDefinition._localRotation = 22.9055 * 3.14159 / 180;

      GeoCoord origin = GeoDefinition.BorderPoints[0];

      for (int i = 0; i < GeoDefinition.BorderPoints.Count; i++)
      {
        GeoCoord pnt = GeoDefinition.BorderPoints[i];

        double x, y;
        Transformations.LocalCoord(origin, pnt, out x, out y);
        // dodati točku u Polygon

        LocalPolygon.ListPoints.Add(new Point2Cartesian(x, y));
      }

      //EstatePart part1 = new AuxiliaryBuilding("Skladište", "skladište");
      
      MML.Polygon2D zvVrt = new Polygon2D();
      var partZVrt = new Garden("Zvonin vrt", new Polygon2D( new List<MML.Point2Cartesian> { new MML.Point2Cartesian(12, -60), 
                                                                                     new MML.Point2Cartesian(12, -80), 
                                                                                     new MML.Point2Cartesian(-4, -80), 
                                                                                     new MML.Point2Cartesian(-4, -60) }));

      MML.Polygon2D ivVrt = new Polygon2D();
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(12, -40));
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(12, -50));
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(-1.5, -50));
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(-1.5, -40)); 
      var partIVrt = new Garden("Ivankin vrt", ivVrt);

      //EstateParts.Add(part1);
      EstateParts.Add(partZVrt);
      EstateParts.Add(partIVrt);

      MML.Polygon2D ivVrt2 = new Polygon2D();
      ivVrt2.ListPoints.Add(new MML.Point2Cartesian(-0.1, 20));
      ivVrt2.ListPoints.Add(new MML.Point2Cartesian(0.1, 20));
      ivVrt2.ListPoints.Add(new MML.Point2Cartesian(0.1, -200));
      ivVrt2.ListPoints.Add(new MML.Point2Cartesian(-0.1, -200));
      var partIVrt2 = new Garden("Ivankin vrt 2", ivVrt2);

      EstateParts.Add(partIVrt2);

      MML.Polygon2D ivVrt3 = new Polygon2D();
      ivVrt3.ListPoints.Add(new MML.Point2Cartesian(-14, -180));
      ivVrt3.ListPoints.Add(new MML.Point2Cartesian(14, -180));
      ivVrt3.ListPoints.Add(new MML.Point2Cartesian(14, -190));
      ivVrt3.ListPoints.Add(new MML.Point2Cartesian(-14, -190));
      var partIVrt3 = new Garden("Ivankin vrt 2", ivVrt3);

      EstateParts.Add(partIVrt3);

      GardenPlot zvKrumpiri = new GardenPlot(new DateTime(2022, 2, 1), "Krumpiri", partZVrt, new Polygon2D(new List<MML.Point2Cartesian> { new MML.Point2Cartesian(14, -62),
                                                                                     new MML.Point2Cartesian(14, -80),
                                                                                     new MML.Point2Cartesian(0, -80),
                                                                                     new MML.Point2Cartesian(0, -62) }));
      // 6 redova krumpira
      partZVrt.CurrentGardenPlots.Add(zvKrumpiri);

    }

    public Estate(EstateGeoDefinition inGeoDef)
    {
      GeoDefinition = inGeoDef;
    }

    // TODO 
   

    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
