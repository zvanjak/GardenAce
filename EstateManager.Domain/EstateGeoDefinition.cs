using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Domain
{

  // ima lokalno definiran koord. sustav!!! u ODNOSU na ishodište
  // sustav je 3D, ali je lokalna ravnina
  // orijentacija je sjever-jug, nema diskusije
  //  U STVARI NE - OĆU LOKALNO LIJEPE KOORDINATE,  dakle, zadajem orijentaciju da mi y bude točno po ogradi!

  // trebati će mi lokalna transformacija!

  public class EstateGeoDefinition
  {
    // ima Geo Polyline za definiciju granice
    private List<GeoCoord> borderPoints = new List<GeoCoord>();

    // point of ishodište - di ćemo u lokalnom staviti 0,0
    public GeoCoord _localOrigin;
    
    // i koliko je zarotiran
    public double _localRotation;

    public List<GeoCoord> BorderPoints { get => borderPoints; set => borderPoints = value; }

    public EstateGeoDefinition()
    {
    }

    public void LocalCoord(GeoCoord pnt, out double x, out double y)
    {
      GeoCoord sameLat = new GeoCoord() { Latitude = _localOrigin.Latitude, Longitude = pnt.Longitude };
      GeoCoord sameLon = new GeoCoord() { Latitude = pnt.Latitude, Longitude = _localOrigin.Longitude };

      x = Transformations.Distance(_localOrigin, sameLat);
      if (pnt.Longitude < _localOrigin.Longitude)
        x *= -1;

      y = Transformations.Distance(_localOrigin, sameLon);
      if (pnt.Latitude < _localOrigin.Latitude)
        y *= -1;

      // još rotacija
      x = x * Math.Cos(_localRotation) - y * Math.Sin(_localRotation);
      y = x * Math.Sin(_localRotation) + y * Math.Cos(_localRotation);
    }
  }
}
