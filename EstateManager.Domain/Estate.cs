using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace EstateManager.Domain
{
  public class Estate
  {
    public EstateLegalGeoDefinition LegalGeoDefinition { get; set; }

    public List<EstatePart> _estateParts = new List<EstatePart>();

    EstatePart getAtLocation(PointF pnt)
    {
      return null;
    }
  }
}
