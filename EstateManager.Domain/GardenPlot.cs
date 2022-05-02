using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  public class GardenPlot : EstatePart
  {
    // ooga će biti dva - gornji i donji vrt
    string _name;     // Zvonin vrt, Ivankin vrt

    // sastoji se od GardenPart
    List<GardenPart> _gardenParts = new List<GardenPart>();

    // svaki od njih onda ima Rows
  }
}
