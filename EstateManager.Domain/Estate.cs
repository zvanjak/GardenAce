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

    public Estate(EstateGeoDefinition inGeoDef)
    {
      _geoDefinition = inGeoDef;
      // svi su u DonjiVrt
      // dodati garden plot za krumpire, kapulu, salatu i jagode
    }
    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
