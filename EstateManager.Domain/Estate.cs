using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace EstateManager.Domain
{
  public class Estate
  {
    private string _name;   // Dupci, Sukošan, Silba
    private EstateGeoDefinition _geoDefinition;
    private List<EstatePart> _estateParts = new List<EstatePart>();

    public string Name { get => _name; set => _name = value; }
    public EstateGeoDefinition GeoDefinition { get => _geoDefinition; set => _geoDefinition = value; }
    public List<EstatePart> EstateParts { get => _estateParts; private set => _estateParts = value; }

    public Estate()
    {
      // default je Dupci estate
      GeoDefinition = new EstateGeoDefinition();

      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      GeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      GeoDefinition._localOrigin = GeoDefinition.BorderPoints[1];
      GeoDefinition._localRotation = 19.9055 * 3.14159 / 180;
    }

    public Estate(EstateGeoDefinition inGeoDef)
    {
      GeoDefinition = inGeoDef;
    }

    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
