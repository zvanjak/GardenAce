using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GardenAce.App
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    PerspectiveCamera myPCamera = new PerspectiveCamera();

    Point3D _cameraPos = new Point3D(45, 20, 80);
    Point3D _lookToPos = new Point3D(15, 20, 0);

    Point3D _startCameraPosRButtonClick;

    private bool _bLButtonDown = false;
    private bool _bRightButtonDown = false;

    private Point _lastMousePos;
    private Point _startMouseRButtonClick;

    public MainWindow()
    {
      InitializeComponent();

      // Declare scene objects.
      Model3DGroup myModel3DGroup = new Model3DGroup();
      GeometryModel3D myGeometryModel = new GeometryModel3D();
      ModelVisual3D myModelVisual3D = new ModelVisual3D();

      // Defines the camera used to view the 3D object. In order to view the 3D object,
      // the camera must be positioned and pointed such that the object is within view
      // of the camera.
      myPCamera.Position = _cameraPos;
      myPCamera.LookDirection = Calc3D.getFrom2Points(_cameraPos, _lookToPos);
      myPCamera.UpDirection = new Vector3D(0, 0, 1);
      myPCamera.FieldOfView = 60;
      myViewport3D.Camera = myPCamera;

      // Define the lights cast in the scene. Without light, the 3D object cannot
      // be seen. Note: to illuminate an object from additional directions, create
      // additional lights.
      DirectionalLight myDirectionalLight = new DirectionalLight();
      myDirectionalLight.Color = Colors.White;
      myDirectionalLight.Direction = new Vector3D(-0.61, -0.5, -0.61);
      myModel3DGroup.Children.Add(myDirectionalLight);


      myGeometryModel = CreateInitial();
      myModel3DGroup.Children.Add(myGeometryModel);

      MeshGeometry3D myCubeMesh3D = CreateCube(new Point3D(17, 20, 5), 10.0);
      var myCubeMaterial = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(255, 250, 245)));
      GeometryModel3D myCube = new GeometryModel3D(myCubeMesh3D, myCubeMaterial);
      myModel3DGroup.Children.Add(myCube);

      MeshGeometry3D myPlot1Mesh3D = CreateParallelepiped(new Point3D(10, 50, 0.2), 10.0, 20.0, 0.5);
      var myPlot1Material = new DiffuseMaterial(new SolidColorBrush(Colors.Brown));
      GeometryModel3D myPlot1 = new GeometryModel3D(myPlot1Mesh3D, myPlot1Material);
      myModel3DGroup.Children.Add(myPlot1);

      // Add the group of models to the ModelVisual3d.
      myModelVisual3D.Content = myModel3DGroup;

      myViewport3D.Children.Add(myModelVisual3D);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
      base.OnRender(drawingContext);
    }

    public static GeometryModel3D CreateInitial()
    {
      Model3DGroup myModel3DGroup = new Model3DGroup();
      GeometryModel3D myGeometryModel = new GeometryModel3D();
      ModelVisual3D myModelVisual3D = new ModelVisual3D();

      // The geometry specifes the shape of the 3D plane. In this sample, a flat sheet
      // is created.
      MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

      // Create a collection of normal vectors for the MeshGeometry3D.
      Vector3DCollection myNormalCollection = new Vector3DCollection();
      myNormalCollection.Add(new Vector3D(0, 0, 1));
      myNormalCollection.Add(new Vector3D(0, 0, 1));
      myNormalCollection.Add(new Vector3D(0, 0, 1));
      myNormalCollection.Add(new Vector3D(0, 0, 1));
      myNormalCollection.Add(new Vector3D(0, 0, 1));
      myNormalCollection.Add(new Vector3D(0, 0, 1));
      myMeshGeometry3D.Normals = myNormalCollection;

      // Create a collection of vertex positions for the MeshGeometry3D.
      Point3DCollection myPositionCollection = new Point3DCollection();
      myPositionCollection.Add(new Point3D(0, 0, 0));
      myPositionCollection.Add(new Point3D(30, 0, 0));
      myPositionCollection.Add(new Point3D(30, 200, 0));
      myPositionCollection.Add(new Point3D(30, 200, 0));
      myPositionCollection.Add(new Point3D(0, 200, 0));
      myPositionCollection.Add(new Point3D(0, 0, 0));
      myMeshGeometry3D.Positions = myPositionCollection;

      // Create a collection of texture coordinates for the MeshGeometry3D.
      PointCollection myTextureCoordinatesCollection = new PointCollection();
      myTextureCoordinatesCollection.Add(new Point(0, 0));
      myTextureCoordinatesCollection.Add(new Point(1, 0));
      myTextureCoordinatesCollection.Add(new Point(1, 1));
      myTextureCoordinatesCollection.Add(new Point(1, 1));
      myTextureCoordinatesCollection.Add(new Point(0, 1));
      myTextureCoordinatesCollection.Add(new Point(0, 0));
      myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

      // Create a collection of triangle indices for the MeshGeometry3D.
      Int32Collection myTriangleIndicesCollection = new Int32Collection();
      myTriangleIndicesCollection.Add(0);
      myTriangleIndicesCollection.Add(1);
      myTriangleIndicesCollection.Add(2);
      myTriangleIndicesCollection.Add(3);
      myTriangleIndicesCollection.Add(4);
      myTriangleIndicesCollection.Add(5);
      myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

      // Apply the mesh to the geometry model.
      myGeometryModel.Geometry = myMeshGeometry3D;

      // The material specifies the material applied to the 3D object. In this sample a
      // linear gradient covers the surface of the 3D object.

      // Create a horizontal linear gradient with four stops.
      LinearGradientBrush myHorizontalGradient = new LinearGradientBrush();
      SolidColorBrush mySolidColorBrush1 = new SolidColorBrush(Colors.Green);
      myHorizontalGradient.StartPoint = new Point(0, 0.5);
      myHorizontalGradient.EndPoint = new Point(1, 0.5);
      myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
      myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
      myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
      myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));

      // Define material and apply to the mesh geometries.
      //DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
      DiffuseMaterial myMaterial = new DiffuseMaterial(mySolidColorBrush1);
      myGeometryModel.Material = myMaterial;

      //// Apply a transform to the object. In this sample, a rotation transform is applied,
      //// rendering the 3D object rotated.
      //RotateTransform3D myRotateTransform3D = new RotateTransform3D();
      //AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
      //myAxisAngleRotation3d.Axis = new Vector3D(0, 3, 0);
      //myAxisAngleRotation3d.Angle = 40;
      //myRotateTransform3D.Rotation = myAxisAngleRotation3d;
      //myGeometryModel.Transform = myRotateTransform3D;

      return myGeometryModel;
    }
    public static MeshGeometry3D CreateCube(Point3D inCenter, double length)
    {
      MeshGeometry3D mesh = new MeshGeometry3D();

      Point3D p1 = new Point3D(inCenter.X - length / 2, inCenter.Y + length / 2, inCenter.Z + length / 2);
      Point3D p2 = new Point3D(inCenter.X + length / 2, inCenter.Y + length / 2, inCenter.Z + length / 2);
      Point3D p3 = new Point3D(inCenter.X + length / 2, inCenter.Y + length / 2, inCenter.Z - length / 2);
      Point3D p4 = new Point3D(inCenter.X - length / 2, inCenter.Y + length / 2, inCenter.Z - length / 2);
      Point3D p5 = new Point3D(inCenter.X - length / 2, inCenter.Y - length / 2, inCenter.Z + length / 2);
      Point3D p6 = new Point3D(inCenter.X + length / 2, inCenter.Y - length / 2, inCenter.Z + length / 2);
      Point3D p7 = new Point3D(inCenter.X + length / 2, inCenter.Y - length / 2, inCenter.Z - length / 2);
      Point3D p8 = new Point3D(inCenter.X - length / 2, inCenter.Y - length / 2, inCenter.Z - length / 2);

      mesh.Positions.Add(p1);
      mesh.Positions.Add(p2);
      mesh.Positions.Add(p3);
      mesh.Positions.Add(p4);
      mesh.Positions.Add(p5);
      mesh.Positions.Add(p6);
      mesh.Positions.Add(p7);
      mesh.Positions.Add(p8);

      // gornja ploha
      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(2);

      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(2);
      mesh.TriangleIndices.Add(3);

      // donja ploha
      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(6);
      mesh.TriangleIndices.Add(5);

      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(7);
      mesh.TriangleIndices.Add(6);

      // srednja 1 ploha
      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(5);
      mesh.TriangleIndices.Add(1);

      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(5);

      // srednja 2 ploha
      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(5);
      mesh.TriangleIndices.Add(6);

      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(6);
      mesh.TriangleIndices.Add(2);

      // srednja 3 ploha
      mesh.TriangleIndices.Add(2);
      mesh.TriangleIndices.Add(6);
      mesh.TriangleIndices.Add(7);

      mesh.TriangleIndices.Add(2);
      mesh.TriangleIndices.Add(7);
      mesh.TriangleIndices.Add(3);

      // srednja 4 ploha
      mesh.TriangleIndices.Add(3);
      mesh.TriangleIndices.Add(7);
      mesh.TriangleIndices.Add(4);

      mesh.TriangleIndices.Add(3);
      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(0);

      return mesh;
    }

    public static MeshGeometry3D CreateParallelepiped(Point3D inCenter, double lengthX, double lengthY, double lengthZ)
    {
      MeshGeometry3D mesh = new MeshGeometry3D();

      Point3D p1 = new Point3D(inCenter.X - lengthX / 2, inCenter.Y + lengthY / 2, inCenter.Z + lengthZ / 2);
      Point3D p2 = new Point3D(inCenter.X + lengthX / 2, inCenter.Y + lengthY / 2, inCenter.Z + lengthZ / 2);
      Point3D p3 = new Point3D(inCenter.X + lengthX / 2, inCenter.Y + lengthY / 2, inCenter.Z - lengthZ / 2);
      Point3D p4 = new Point3D(inCenter.X - lengthX / 2, inCenter.Y + lengthY / 2, inCenter.Z - lengthZ / 2);
      Point3D p5 = new Point3D(inCenter.X - lengthX / 2, inCenter.Y - lengthY / 2, inCenter.Z + lengthZ / 2);
      Point3D p6 = new Point3D(inCenter.X + lengthX / 2, inCenter.Y - lengthY / 2, inCenter.Z + lengthZ / 2);
      Point3D p7 = new Point3D(inCenter.X + lengthX / 2, inCenter.Y - lengthY / 2, inCenter.Z - lengthZ / 2);
      Point3D p8 = new Point3D(inCenter.X - lengthX / 2, inCenter.Y - lengthY / 2, inCenter.Z - lengthZ / 2);

      mesh.Positions.Add(p1);
      mesh.Positions.Add(p2);
      mesh.Positions.Add(p3);
      mesh.Positions.Add(p4);
      mesh.Positions.Add(p5);
      mesh.Positions.Add(p6);
      mesh.Positions.Add(p7);
      mesh.Positions.Add(p8);

      // gornja ploha
      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(2);

      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(2);
      mesh.TriangleIndices.Add(3);

      // donja ploha
      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(6);
      mesh.TriangleIndices.Add(5);

      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(7);
      mesh.TriangleIndices.Add(6);

      // srednja 1 ploha
      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(5);
      mesh.TriangleIndices.Add(1);

      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(5);

      // srednja 2 ploha
      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(5);
      mesh.TriangleIndices.Add(6);

      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(6);
      mesh.TriangleIndices.Add(2);

      // srednja 3 ploha
      mesh.TriangleIndices.Add(2);
      mesh.TriangleIndices.Add(6);
      mesh.TriangleIndices.Add(7);

      mesh.TriangleIndices.Add(2);
      mesh.TriangleIndices.Add(7);
      mesh.TriangleIndices.Add(3);

      // srednja 4 ploha
      mesh.TriangleIndices.Add(3);
      mesh.TriangleIndices.Add(7);
      mesh.TriangleIndices.Add(4);

      mesh.TriangleIndices.Add(3);
      mesh.TriangleIndices.Add(4);
      mesh.TriangleIndices.Add(0);

      return mesh;
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      _bLButtonDown = true;
      _lastMousePos = e.GetPosition(this);
    }

    private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      _bLButtonDown = false;
    }

    private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
      _bRightButtonDown = true;
      _startMouseRButtonClick = e.GetPosition(this);

      _startCameraPosRButtonClick = _cameraPos;
    }

    private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      _bRightButtonDown = false;
    }

    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
      if( _bLButtonDown )
      {
        // morati ćemo uzeti u obzir i smjer gledanja na kraju!
        var newPos = e.GetPosition(this);
        var diffX = (newPos.X - _lastMousePos.X) / 100.0;
        var diffY = (newPos.Y - _lastMousePos.Y) / 100.0;

        _cameraPos = new Point3D(_cameraPos.X + diffX, _cameraPos.Y - diffY, _cameraPos.Z);
        _lookToPos = new Point3D(_lookToPos.X + diffX, _lookToPos.Y - diffY, _lookToPos.Z);

        myPCamera.Position = _cameraPos;

        myViewport3D.InvalidateVisual();
      }

      if( _bRightButtonDown )
      {
        // za početak, samo ćemo se micati lijevo desno
        double diffX = e.GetPosition(this).X - _startMouseRButtonClick.X;

        // znači, moramo zarotirati točku kamere, OKO točke gledanja
        double angle = diffX / 3.0 * Math.PI/180.0;

        Debug.WriteLine("Angle {0}", angle);

        Point3D newPos = Calc3D.rotate_point(_lookToPos.X, _lookToPos.Y, angle, _startCameraPosRButtonClick);

        _cameraPos.X = newPos.X;
        _cameraPos.Y = newPos.Y;

        myPCamera.Position = _cameraPos;

        // treba ažurirati i LookDirection!!!
        myPCamera.LookDirection = Calc3D.getFrom2Points(_cameraPos, _lookToPos);

        myViewport3D.InvalidateVisual();
      }
    }

    private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      // mijenjamo poziciju kamere da se ili približi ili udalji od točke u koju gledamo
      Vector3D dir = Calc3D.getFrom2Points(_cameraPos, _lookToPos);

      _cameraPos = _cameraPos + (e.Delta / 10.0) * dir;

      myPCamera.Position = _cameraPos;

      myViewport3D.InvalidateVisual();
    }

    private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      // idemo zarotirati za kut od 45 stupnjeva
      double angle = 45 * Math.PI / 180.0;

      Debug.WriteLine("Angle {0}", angle);

      Point3D newPos = Calc3D.rotate_point(_lookToPos.X, _lookToPos.Y, angle, _startCameraPosRButtonClick);

      _cameraPos.X = newPos.X;
      _cameraPos.Y = newPos.Y;

      myPCamera.Position = _cameraPos;

      // treba ažurirati i LookDirection!!!
      myPCamera.LookDirection = Calc3D.getFrom2Points(_cameraPos, _lookToPos);

      myViewport3D.InvalidateVisual();
    }
  }
}
