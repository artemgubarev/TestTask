using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Line : Figure
    {
        public readonly string FigureName = "line";
        private static readonly int PointNumber = 2;
        private static readonly string IncorrectVerticesErrorMessage = "Концы линии не могут совпадать!";

        private Point[] _points;

        public Line(Point[] points)
        {
            if (points.Length != PointNumber)
                throw new ArgumentException($"Количество точек должно быть равно {PointNumber}!");
            if (points[0] == points[1])
                throw new ArgumentException(IncorrectVerticesErrorMessage);

            _points = points;
        }

        public Point this[int index]
        {
            get => _points[index];
            set
            {
                for (int i = 0; i < 2; i++)
                    if (i != index && _points[i] == value)
                        throw new ArgumentException(IncorrectVerticesErrorMessage);
                _points[index] = value;
            }
        }

        public override void Draw()
        {
            Console.WriteLine(FigureName + " at [({0}, {1}) , ({2}, {3})]", _points[0].X, _points[0].Y, _points[1].X, _points[1].Y);
        }

        public override void Intersect(Figure figure)
        {
            if (figure.GetType() == typeof(Point))
            {
                Point point = figure as Point;

                if (IsOnSegment(point)) Console.WriteLine(FigureName + " and " + point.FigureName + " have intersections at ({0}, {1})",
                    point.X, point.Y);
                else Console.WriteLine(FigureName + " and " + point.FigureName + " have not intersections");
            }
            else if (figure.GetType() == typeof(Line))
            {
                Line line = figure as Line;

                Point intersect = LinesIntersect(line);

                if (!(intersect is null))
                    Console.WriteLine(FigureName + " and " + line.FigureName + " have intersections at ({0}, {1})",
                    intersect.X, intersect.Y);
                else Console.WriteLine(FigureName + " and " + line.FigureName + " have not intersections");
            }
            else if (figure.GetType() == typeof(Circle))
            {
                Circle circle = figure as Circle;

                List<Point> intersects = circle.IntersectWithLine(this);

                if (intersects.Count == 0)
                    Console.WriteLine(FigureName + " and " + circle.FigureName + " have not intersections");
                else if (intersects.Count == 1) Console.WriteLine(FigureName + " and " + circle.FigureName + " have intersections at ({0}, {1})",
                    intersects[0].X, intersects[0].Y);
                else Console.WriteLine(FigureName + " and " + circle.FigureName + " have intersections at ({0}, {1}) and ({2}, {3})",
                   intersects[0].X, intersects[0].Y, intersects[1].X, intersects[1].Y);
            }
            else if (figure.GetType() == typeof(Rect))
            {
                Rect rect = figure as Rect;
                rect.Intersect(this);
            }
        }

        // принадлежи  ли точка отрезку
        public bool IsOnSegment(Point point)
        {
            bool c = Math.Abs(Math.Sqrt(Math.Pow(_points[0].X - point.X, 2) + Math.Pow(_points[0].Y - point.Y, 2)) +
                Math.Sqrt(Math.Pow(_points[1].X - point.X, 2) + Math.Pow(_points[1].Y - point.Y, 2)) -
                 Math.Sqrt(Math.Pow(_points[1].X - _points[0].X, 2) + Math.Pow(_points[1].Y - _points[0].Y, 2))) < 0.00001;

            return c;
        }


        public Point LinesIntersect(Line line)
        {
            Point intersect = null;

            double x1, x2, x3, x4, y1, y2, y3, y4;
            double k1, k2;
            double b1, b2;
            double x, y;

            x3 = line[0].X;
            y3 = line[0].Y;
            x4 = line[1].X;
            y4 = line[1].Y;

            x1 = _points[0].X;
            x2 = _points[1].X;
            y1 = _points[0].Y;
            y2 = _points[1].Y;

            if (x1 >= x2)
            {
                Swap<double>(ref x1, ref x2);
                Swap<double>(ref y1, ref y2);
            }

            if (x3 >= x4)
            {
                Swap<double>(ref x3, ref x4);
                Swap<double>(ref y3, ref y4);
            }

            if (y2 == y1) k1 = 0;
            else k1 = (y2 - y1) / (x2 - x1);

            if (y4 == y3) k2 = 0;
            else k2 = (y4 - y3) / (x4 - x3);

            if (k1 == k2 || (double.IsInfinity(k1) && double.IsInfinity(k2)))
                return intersect;
            else
            {
                b1 = y1 - k1 * x1;
                b2 = y3 - k2 * x3;

                // в случае если коэффициент k у одного из отрезков равен бесконечности
                if (double.IsInfinity(k1))
                {
                    x = x2;
                    y = k2*x + b2;
                }
                else if (double.IsInfinity(k2))
                {
                    x = x4;
                    y = k1*x + b1;
                }
                else // в общем случае
                {
                    x = (b2 - b1) / (k1 - k2);
                    y = k1 * x + b1;
                }
                Point p = new Point(x, y);
                if (IsOnSegment(p) && line.IsOnSegment(p)) intersect = p;
            }

            return intersect;
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

    }
}
