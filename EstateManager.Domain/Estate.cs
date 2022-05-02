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
      // svi su u DonjiVrt
      // dodati garden plot za krumpire, kapulu, salatu i jagode
    }
    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
