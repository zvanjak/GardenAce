using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace EstateManager.Domain
{
  public class Estate
  {
    string _name;   // Dupci, Sukošan, Silba
    public EstateGeoDefinition _geoDefinition { get; set; }

    public List<EstatePart> _estateParts = new List<EstatePart>();

    public Estate()
    {
      // default je Dupci estate
      _geoDefinition = new EstateGeoDefinition();

      _geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      _geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      _geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      _geoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      _geoDefinition._localOrigin = _geoDefinition.BorderPoints[1];
      _geoDefinition._localRotation = 19.9055 * 3.14159 / 180;
    }

    public Estate(EstateGeoDefinition inGeoDef)
    {
      _geoDefinition = inGeoDef;
    }
    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
