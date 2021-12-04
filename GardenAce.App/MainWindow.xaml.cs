﻿using System;
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

namespace GardenAce.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse myEllipse = new Ellipse();

        public MainWindow()
        {
            InitializeComponent();

            // Create a red Ellipse.

            // Create a SolidColorBrush with a red color to fill the
            // Ellipse with.
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            // Describes the brush's color using RGB values.
            // Each value has a range of 0-255.
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;

            // Set the width and height of the Ellipse.
            myEllipse.Width = 200;
            myEllipse.Height = 100;

            // Add the Ellipse to the StackPanel.
            panelPlot.Children.Add(myEllipse);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Trace.WriteLine("OnRender");

            myEllipse.Height = 300;
            drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 5), new Rect(20, 20, 250, 250));

            base.OnRender(drawingContext);
        }
    }
}
