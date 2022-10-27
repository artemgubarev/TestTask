using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Rect : Figure
    {
        public readonly string FigureName = "rect";
        private static readonly int PointNumber = 2;

        private static readonly string IncorrectVerticesErrorMessage = 
            "Вершины прямоугольника по диагонали не могут совпадать, или находиться на одной оси!";
        
        private  Point[] _points;
        public List<Line> Sides;

        public Rect(Point[] points)
        {
            if (points.Length != PointNumber)
                throw new ArgumentException($"Количество точек должно быть равно {PointNumber}!");

            if (points[0] == points[1] || points[0].X == points[1].X || points[0].Y == points[1].Y)
                throw new ArgumentException(IncorrectVerticesErrorMessage);
                
            _points = points;

            Sides = new List<Line>() { new Line(new Point[2]
            { new Point(_points[0].X, _points[0].Y), new Point(_points[0].X, _points[1].Y) } ) ,
            new Line(new Point[2] { new Point(_points[0].X, _points[1].Y), new Point(_points[1].X, _points[1].Y) } ),
            new Line(new Point[2] { new Point(_points[1].X, _points[1].Y), new Point(_points[1].X, _points[0].Y) } ),
            new Line(new Point[2] { new Point(_points[1].X, _points[0].Y), new Point(_points[0].X, _points[0].Y) } )};
        }

        public Point this[int index]
        {
            get => _points[index];
            set
            {
                for (int i = 0; i < 2; i++)
                    if (i != index && (_points[i] == value || _points[i].X == value.X || _points[i].Y == value.Y))
                        throw new ArgumentException(IncorrectVerticesErrorMessage);
                _points[index] = value;
            }
        }

        public override void Draw()
        {
            Console.WriteLine(FigureName + " at ({0}, {1}), ({2}, {3})", _points[0].X, _points[0].Y, _points[1].X, _points[1].Y);
        }

        public override void Intersect(Figure figure)
        {
            if(figure.GetType() == typeof(Point))
            {
                Point point = figure as Point;
                bool isIntersect = false;

                foreach (var line in Sides)
                    if (line.IsOnSegment(point)) isIntersect = true;

                if (isIntersect) Console.WriteLine(FigureName + " and " + point.FigureName + " have intersections at ({0}, {1})",
                   point.X, point.Y);
                else Console.WriteLine(FigureName + " and " + point.FigureName + " have not intersections");
            }

            else if(figure.GetType() == typeof(Line))
            {
                Line line = figure as Line;

                List<Point> points = new List<Point>();

                foreach (var _line in Sides)
                {
                    Point intersect = line.LinesIntersect(_line);
                    if (intersect is null) continue;
                    else points.Add(intersect);
                }

                if(points.Count == 0) Console.WriteLine(FigureName + " and " + line.FigureName + " have not intersections");
                else if(points.Count == 1)
                {
                    Console.WriteLine(FigureName + " and " + line.FigureName + " have intersections at ({0}, {1})",
                   points[0].X, points[0].Y);
                }
                else
                {
                    Console.WriteLine(FigureName + " and " + line.FigureName + " have intersections at ({0}, {1}) and ({2}, {3})",
                   points[0].X, points[0].Y, points[1].X, points[1].Y);
                }
            }

            else if (figure.GetType() == typeof(Circle))
            {
                Circle circle = figure as Circle;

                List<Point> points = new List<Point>();

                foreach (var _line in Sides)
                {
                    List<Point> intersect = circle.IntersectWithLine(_line);

                    if (intersect.Count != 0)
                    {
                        foreach (var point in intersect)
                            if(!points.Exists(p => p == point)) points.Add(point);
                    }
                }

                if(points.Count == 0) Console.WriteLine(FigureName + " and " + circle.FigureName + " have not intersections");
                else if(points.Count == 1) Console.WriteLine(FigureName + " and " + circle.FigureName + " have intersections at ({0}, {1})",
                   points[0].X, points[0].Y);
                else
                {
                    string str = FigureName + " and " + circle.FigureName + " have intersections at";

                    foreach (var point in points)
                        str += $" ({point.X}, {point.Y})  and ";

                    str = str.Remove(str.Length - 4);
                    Console.WriteLine( str);
                }

            }
            else if (figure.GetType() == typeof(Rect))
            {
                Rect rect = figure as Rect;

                List<Point> intersects = new List<Point>();

                List<Line> rectSides = rect.Sides;

                foreach (var line in Sides)
                {
                    foreach (var rect_line in rectSides)
                    {
                        Point point = line.LinesIntersect(rect_line);
                        if (point is null) continue;
                        else if(rect_line.IsOnSegment(point) && !intersects.Exists(p => p == point)) intersects.Add(point);
                    }
                }

               if(intersects.Count == 0) Console.WriteLine(FigureName + " and " + rect.FigureName + " have not intersections");
               else
                {
                    string str = FigureName + " and " + rect.FigureName + " have intersections at";

                    foreach (var point in intersects)
                        str += $" ({point.X}, {point.Y})  and ";

                    str = str.Remove(str.Length - 4);
                    Console.WriteLine(str);
                }
            }
               

        }

    }
}
