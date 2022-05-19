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

    private List<GardenPlot> _currentGardenPlots = new List<GardenPlot>();
    private List<GardenPlot> _historicalPlots = new List<GardenPlot>();

    public string Name { get => _name; set => _name = value; }
    public List<GardenPlot> CurrentGardenPlots { get => _currentGardenPlots; set => _currentGardenPlots = value; }
    public List<GardenPlot> HistoricalPlots { get => _historicalPlots; set => _historicalPlots = value; }

    public Garden()
    { }

    public Garden(string inName) : base(inName, "Garden")
    {
    }

    public Garden(string inName, MML.Polygon2D polygon) : base(inName, "Garden", polygon)
    {
    }
  }
}
