using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  public class SeededGardenRow
  {
    string _cultureName;
    GardenPlot _parent;
    DateTime _dateSeeded;

    public string CultureName { get => _cultureName; set => _cultureName = value; }
    public DateTime DateSeeded { get => _dateSeeded; set => _dateSeeded = value; }
    public GardenPlot Parent { get => _parent; set => _parent = value; }

    // koliko?

    // EVENTS?

    public SeededGardenRow(string inName, DateTime inDateSeeded, GardenPlot inParent)
    {
      _cultureName = inName;
      _dateSeeded = inDateSeeded;
      _parent = inParent;
    }
  }
}
