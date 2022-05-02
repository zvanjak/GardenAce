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
    DateTime _dateSeeded;

    public string CultureName { get => _cultureName; set => _cultureName = value; }
    public DateTime DateSeeded { get => _dateSeeded; set => _dateSeeded = value; }
    // koliko?

    // EVENTS?

    public SeededGardenRow(string inName, DateTime inDateSeeded)
    {
      _cultureName = inName;
      _dateSeeded = inDateSeeded;
    }
  }
}
