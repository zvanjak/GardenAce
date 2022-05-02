using MML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  public class GardenPlot
  {
    string _name;
    DateTime _dateCreated;
    Garden _parentPlot;
    List<MML.Polygon2D> _polygon;

    public string Name { get => _name; set => _name = value; }
    public Garden ParentPlot { get => _parentPlot; set => _parentPlot = value; }
    public List<Polygon2D> Polygon { get => _polygon; private set => _polygon = value; }
    public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }

    public GardenPlot(DateTime inCreated, string inName, Garden inParent)
    {
      Name = inName;
      ParentPlot = inParent;
      DateCreated = inCreated;
      Polygon = new List<MML.Polygon2D>();
    }


  }
}
