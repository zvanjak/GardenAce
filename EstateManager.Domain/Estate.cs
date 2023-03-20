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
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      GeoDefinition._localOrigin = GeoDefinition.BorderPoints[1];
      GeoDefinition._localRotation = 19.9055 * 3.14159 / 180;

      GeoCoord origin = GeoDefinition.BorderPoints[1];

      for (int i = 0; i < 4; i++)
      {
        GeoCoord pnt = GeoDefinition.BorderPoints[i];

        double x, y;
        Transformations.LocalCoord(origin, pnt, out x, out y);
        // dodati točku u Polygon

        LocalPolygon.ListPoints.Add(new Point2Cartesian(x, y));
      }

      //EstatePart part1 = new AuxiliaryBuilding("Skladište", "skladište");
      
      MML.Polygon2D zvVrt = new Polygon2D();
      var partZVrt = new Garden("Zvonin vrt", new Polygon2D( new List<MML.Point2Cartesian> { new MML.Point2Cartesian(14, -60), 
                                                                                     new MML.Point2Cartesian(14, -80), 
                                                                                     new MML.Point2Cartesian(-4, -80), 
                                                                                     new MML.Point2Cartesian(-4, -60) }));

      MML.Polygon2D ivVrt = new Polygon2D();
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(14, -40));
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(14, -50));
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(-1.5, -50));
      ivVrt.ListPoints.Add(new MML.Point2Cartesian(-1.5, -40)); 
      var partIVrt = new Garden("Ivankin vrt", ivVrt);

      //EstateParts.Add(part1);
      EstateParts.Add(partZVrt);
      EstateParts.Add(partIVrt);

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
