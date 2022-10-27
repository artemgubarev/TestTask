using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Point : Figure
    {
        public  readonly string FigureName = "point";

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double _x, double _y)
        {
            this.X = _x;
            this.Y = _y;
        }

        public override void Draw()
        {
            Console.WriteLine(FigureName + " at ({0},{1})", this.X, this.Y);
        }

        public override void Intersect(Figure figure)
        {
            if (figure.GetType() == typeof(Point))
            {
                Point point = figure as Point;

                if(point == this)
                    Console.WriteLine(FigureName + " and " + point.FigureName + " have intersections at ({0}, {1})",
                    point.X, point.Y);
                else Console.WriteLine(FigureName + " and " + point.FigureName + " have not intersections");
            }
            else if (figure.GetType() == typeof(Line))
            {
                Line line = figure as Line;

                line.Intersect(this);
            }
            else if (figure.GetType() == typeof(Circle))
            {
                Circle circle = figure as Circle;

                bool isIntersect = Math.Pow((X - circle.Center.X), 2) + Math.Pow((Y - circle.Center.Y), 2) == Math.Pow(circle.Radius, 2);

                if (isIntersect) Console.WriteLine(FigureName + " and " + circle.FigureName + " have intersections at ({0}, {1})", X, Y);
                else Console.WriteLine(FigureName + " and " + circle.FigureName + " have not intersections");
            }
            else if (figure.GetType() == typeof(Rect))
            {
                Rect rect = figure as Rect;

                rect.Intersect(this);
            }
        }

        public static bool operator ==(Point point1, Point second)
        {
            if (point1.X == second.X && point1.Y == second.Y) return true;
            else return false;
        }

        public static bool operator !=(Point point1, Point second)
        {
            if (point1.X == second.X && point1.Y == second.Y) return false;
            else return true;
        }

    }
}
