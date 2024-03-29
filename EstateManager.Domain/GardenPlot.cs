﻿using MML;
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
    DateTime _dateDestroyed;
    Garden _parentPlot;
    MML.Polygon2D _polygon;
    List<SeededGardenRow> _currentRows;

    public string Name { get => _name; set => _name = value; }
    public Garden ParentPlot { get => _parentPlot; set => _parentPlot = value; }
    public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }
    public DateTime DateDestroyed { get => _dateDestroyed; set => _dateDestroyed = value; }
    public Polygon2D Polygon { get => _polygon; set => _polygon = value; }
    public List<SeededGardenRow> Rows { get => _currentRows; private set => _currentRows = value; }

    public GardenPlot(DateTime inCreated, string inName, Garden inParent)
    {
      Name = inName;
      ParentPlot = inParent;
      DateCreated = inCreated;
      Polygon = new MML.Polygon2D();
      Rows = new List<SeededGardenRow>();
    }

    public GardenPlot(DateTime inCreated, string inName, Garden inParent, Polygon2D polygon)
    {
      Name = inName;
      ParentPlot = inParent;
      DateCreated = inCreated;
      Polygon = polygon;
      Rows = new List<SeededGardenRow>();
    }
  }
}
