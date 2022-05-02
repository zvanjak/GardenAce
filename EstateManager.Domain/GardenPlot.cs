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
    private string _name;     // Zvonin vrt, Ivankin vrt

    // sastoji se od GardenPart
    private List<GardenPart> _gardenParts = new List<GardenPart>();

    public string Name1 { get => _name; set => _name = value; }
    public List<GardenPart> GardenParts { get => _gardenParts; set => _gardenParts = value; }

    // svaki od njih onda ima Rows

    public GardenPlot()
    { }

    public GardenPlot(string inName)
    {
      Name = inName;
    }
  }
}
