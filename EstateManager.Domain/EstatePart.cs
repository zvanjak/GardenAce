using MML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{
  // osnovno - zauzima dio tlocrta od estate!
  public class EstatePart
  {
    private string _name;
    private string _description;
    private List<MML.Polygon2D> _polygon;

    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public List<Polygon2D> Polygon { get => _polygon; set => _polygon = value; }

    public EstatePart()
    { }

    public EstatePart(string inName, string inDesc) 
    {
      Name = inName;
      Description = inDesc; 
    }


  }
}
