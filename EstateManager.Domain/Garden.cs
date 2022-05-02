using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  public class Garden : EstatePart
  {
    private string _name;     // Zvonin vrt, Ivankin vrt

    private List<GardenPlot> _gardenParts = new List<GardenPlot>();

    public string Name { get => _name; set => _name = value; }
    public List<GardenPlot> GardenParts { get => _gardenParts; set => _gardenParts = value; }

    public Garden()
    { }

    public Garden(string inName)
    {
      Name = inName;
    }
  }
}
