using System;

namespace EstateManager.Domain
{
  public class Estate
  {
    public EstateLegalGeoDefinition LegalGeoDefinition { get; set; }

    // point of ishodište - di ćemo u lokalnom staviti 0,0
    // i definira smjer x i y osi

    // ima lokalno definiran koord. sustav!!! u ODNOSU na ishodište
    // sustav je 3D, ali je lokalna ravnina
    // orijentacija je sjever-jug, nema diskusije
    //  U STVARI NE - OĆU LOKALNO LIJEPE KOORDINATE,  dakle, zadajem orijentaciju da mi y bude točno po ogradi!

    // trebati će mi lokalna transformacija!
  }
}
