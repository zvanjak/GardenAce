using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace GardenAce.App
{
  public class Calc3D
  {
    public static Vector3D getFrom2Points(Point3D pnt1, Point3D pnt2)
    {
      Vector3D ret = new Vector3D(pnt2.X-pnt1.X, pnt2.Y-pnt1.Y, pnt2.Z-pnt1.Z);

      ret.Normalize();
      return ret;
    }

    public static Point3D rotate_point(double cx, double cy, double angle, Point3D p)
    {
      double s = Math.Sin(angle);
      double c = Math.Cos(angle);

      // translate point back to origin:
      p.X -= cx;
      p.Y -= cy;

      // rotate point
      double xnew = p.X * c - p.Y * s;
      double ynew = p.X * s + p.Y * c;

      // translate point back:
      p.X = xnew + cx;
      p.Y = ynew + cy;
      
      return p;
    }

    public static void SphericalToCartesian(double radius, double polar, double elevation, out Point3D outCart)
    {
      double a = radius * Math.Cos(elevation);
      outCart.X = radius * Math.Sin(elevation) * Math.Cos(polar);
      outCart.Y = radius * Math.Sin(elevation) * Math.Sin(polar);
      outCart.Z = radius * Math.Cos(elevation);
    }

    public static void CartesianToSpherical(Point3D cartCoords, out double outRadius, out double outPolar, out double outElevation)
    {
      if (cartCoords.X == 0)
        cartCoords.X = 1e-10;
      outRadius = Math.Sqrt((cartCoords.X * cartCoords.X)
                      + (cartCoords.Y * cartCoords.Y)
                      + (cartCoords.Z * cartCoords.Z));
      outPolar = Math.Atan(cartCoords.Y / cartCoords.X);
      if (cartCoords.X < 0)
        outPolar += Math.PI;
      outElevation = Math.Acos(cartCoords.Z / outRadius);
    }
  }
}
