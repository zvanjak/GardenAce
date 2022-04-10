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

  public class EstateLegalGeoDefinition
  {
    // ima Geo Polyline za definiciju granice
    private List<GeoCoord> borderPoints = new List<GeoCoord>();

    // point of ishodište - di ćemo u lokalnom staviti 0,0
    GeoCoord _localOrigin;
    
    // i koliko je zarotiran
    double _localRotation;

    public List<GeoCoord> BorderPoints { get => borderPoints; set => borderPoints = value; }

    public EstateLegalGeoDefinition()
    {
      BorderPoints.Add(new GeoCoord() { Latitude = 45.73779885083265, Longitude = 15.936093764979713 });
      BorderPoints.Add(new GeoCoord() { Latitude = 45.73775302153398, Longitude = 15.93626284812708 });
      BorderPoints.Add(new GeoCoord() { Latitude = 45.735977758275176, Longitude = 15.93523577830417 });
      BorderPoints.Add(new GeoCoord() { Latitude = 45.735962290389196, Longitude = 15.935010881339498 });

      _localOrigin = BorderPoints[1];
      _localRotation = 19.9055 * 3.14159 / 180;
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
