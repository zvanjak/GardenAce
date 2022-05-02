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
    public EstateGeoDefinition LegalGeoDefinition { get; set; }

    public List<EstatePart> _estateParts = new List<EstatePart>();

    public Estate()
    {
      LegalGeoDefinition = new EstateGeoDefinition();

      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      LegalGeoDefinition.BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      LegalGeoDefinition._localOrigin = LegalGeoDefinition.BorderPoints[1];
      LegalGeoDefinition._localRotation = 19.9055 * 3.14159 / 180;

      // svi su u DonjiVrt
      // dodati garden plot za krumpire, kapulu, salatu i jagode
    }
    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
