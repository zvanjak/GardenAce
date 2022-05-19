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

        LocalPolygon.ListPoints.Add(new Point2D(x, y));
      }

      //EstatePart part1 = new AuxiliaryBuilding("Skladište", "skladište");
      
      MML.Polygon2D zvVrt = new Polygon2D();
      zvVrt.ListPoints.Add(new MML.Point2D(14, -60));
      zvVrt.ListPoints.Add(new MML.Point2D(14, -80));
      zvVrt.ListPoints.Add(new MML.Point2D(-4, -80));
      zvVrt.ListPoints.Add(new MML.Point2D(-4, -60));

      var partZVrt = new Garden("Zvonin vrt", zvVrt);
      var partIVrt = new Garden("Ivankin vrt");

      //MeshGeometry3D myPlot1Mesh3D = CreateParallelepiped(new Point3D(-5.5, 46.5 + 6, 0.05), 14.0, 9.0, 0.1);
      //var myPlot1Material = new DiffuseMaterial(new SolidColorBrush(Colors.Brown));
      //GeometryModel3D myPlot1 = new GeometryModel3D(myPlot1Mesh3D, myPlot1Material);
      //myModel3DGroup.Children.Add(myPlot1);

      //MeshGeometry3D myPlot2Mesh3D = CreateParallelepiped(new Point3D(-5.5, 69, 0.05), 14.0, 20.0, 0.1);
      //var myPlot2Material = new DiffuseMaterial(new SolidColorBrush(Colors.Brown));
      //GeometryModel3D myPlot2 = new GeometryModel3D(myPlot2Mesh3D, myPlot2Material);
      //myModel3DGroup.Children.Add(myPlot2);


      //EstateParts.Add(part1);
      EstateParts.Add(partZVrt);
      //EstateParts.Add(partIVrt);
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
