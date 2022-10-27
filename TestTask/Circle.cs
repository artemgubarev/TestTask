using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Circle : Figure
    {
        public readonly string FigureName = "circle";
        private static readonly string IncorrectRadiusErrorMessage = "Концы линии не могут совпадать";

        public Point Center { get; set; }
        private double _radius;

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public double Radius
        {
            get { return this._radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(IncorrectRadiusErrorMessage);
                else this._radius = value;
            }
        }

        public override void Draw()
        {
            Console.WriteLine(FigureName + " at ({0},{1}) , radius = {2}", Center.X, Center.Y, this._radius);
        }


        public override void Intersect(Figure figure)
        {
            if (figure.GetType() == typeof(Point))
            {
                Point point = figure as Point;

                bool isIntersect = Math.Pow((point.X - Center.X), 2) + Math.Pow((point.Y - Center.Y), 2) == Math.Pow(Radius, 2);

                if (isIntersect) Console.WriteLine(FigureName + " and " + point.FigureName + " have intersections at ({0}, {1})", point.X, point.Y);
                else Console.WriteLine(FigureName + " and " + point.FigureName + " have not intersections");
            }

            else if (figure.GetType() == typeof(Circle))
            {
                Circle circle = figure as Circle;

                List<Point> points = new List<Point>();

                double x0, y0;//координаты точки пересечения всех линий

                double d;//расстояние между центрами окружностей
                double a;//расстояние от r1 до точки пересечения всех линий
                double h;//расстояние от точки пересеч окружностей до точки пересеч всех линий

                d = Math.Sqrt(Math.Pow(Math.Abs(Center.X - circle.Center.X), 2) + Math.Pow(Math.Abs(Center.Y - circle.Center.Y), 2));
                if (d > Radius + circle.Radius || d <= Math.Abs(Radius - circle.Radius)) //окружности не пересекаются
                {
                    Console.WriteLine(FigureName + " and " + circle.FigureName + " have not intersections");
                    return;
                } 

                a = (Math.Pow(Radius, 2) - Math.Pow(circle.Radius, 2) + d * d) / (2 * d);
                h = Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(a, 2));


                x0 = Center.X + a * (circle.Center.X - Center.X) / d;
                y0 = Center.Y + a * (circle.Center.Y - Center.Y) / d;

                Point first = new Point(x0 + h * (circle.Center.Y - Center.Y) / d, y0 - h * (circle.Center.X - Center.X) / d);

                if (a == Radius)  //окружности соприкасаются
                {
                    Console.WriteLine(FigureName + " and " + circle.FigureName + " have intersections at ({0}, {1})",
                    first.X, first.Y);
                    return;
                }

                //окружности пересекаются

                Point second = new Point(x0 - h * (circle.Center.Y - Center.Y) / d, y0 + h * (circle.Center.X - Center.X) / d);

                Console.WriteLine(FigureName + " and " + circle.FigureName + " have intersections at ({0}, {1}) and ({2}, {3})",
                   first.X, first.Y, second.X, second.Y);
            }

            else if (figure.GetType() == typeof(Line))
            {
                Line line = figure as Line;

                List<Point> intersects = IntersectWithLine(line);

                if(intersects.Count == 0)
                    Console.WriteLine(FigureName + " and " + line.FigureName + " have not intersections");
                else if(intersects.Count == 1) Console.WriteLine(FigureName + " and " + line.FigureName + " have intersections at ({0}, {1})",
                   intersects[0].X, intersects[0].Y);
                else Console.WriteLine(FigureName + " and " + line.FigureName + " have intersections at ({0}, {1}) and ({2}, {3})",
                   intersects[0].X, intersects[0].Y, intersects[1].X, intersects[1].Y);
            }
            else if (figure.GetType() == typeof(Rect))
            {
                Rect rect = figure as Rect;
                rect.Intersect(this);
            }
        }

        // точки пересечения с отрезком
        public List<Point> IntersectWithLine(Line line)
        {
            List<Point> points = new List<Point>();

            double xc = Center.X;
            double yc = Center.Y;

            double x1 = line[0].X;
            double x2 = line[1].X;
            double y1 = line[0].Y;
            double y2 = line[1].Y;

            double k = (y1 - y2) / (x1 - x2);

            double b, A, B, C;

            // приравниваем уравнение прямой и окружности

            if (!double.IsInfinity(k))
            {
                b = y1 - (k * x1);

                A = 1 + Math.Pow(k, 2);
                B = (-2 * xc) + (2 * k * b) - (2 * yc * k);
                C = Math.Pow(xc, 2) + Math.Pow(b - yc, 2) - Math.Pow(Radius, 2);

                double d = Math.Pow(B, 2) - (4 * A * C);

                if (d > 0)
                {
                    double _x1 = (-B + Math.Sqrt(d)) / (2 * A);
                    double _x2 = (-B - Math.Sqrt(d)) / (2 * A);

                    Point p1 = new Point(_x1, k * _x1 + b);
                    Point p2 = new Point(_x2, k * _x2 + b);

                    if (line.IsOnSegment(p1)) points.Add(p1);
                    if (line.IsOnSegment(p2)) points.Add(p2);
                }
                else if (d == 0)
                {
                    double x = -B / (2 * A);

                    Point p = new Point(x, k * x + b);
                    if (line.IsOnSegment(p)) points.Add(p);
                }
            }
            else // в случае если коэффициент k у отрезка равен бесконечности
            {
                double x = x1;

                A = 1;
                B = -2 * yc;
                C = Math.Pow(yc,2) - Math.Pow(Radius, 2) + Math.Pow(x - xc, 2);

                double d = Math.Pow(B, 2) - (4 * A * C);

                if(d > 0)
                {
                    double _y1 = (-B + Math.Sqrt(d)) / (2 * A);
                    double _y2 = (-B - Math.Sqrt(d)) / (2 * A);

                    Point p1 = new Point(x, _y1);
                    Point p2 = new Point(x, _y2);

                    if (line.IsOnSegment(p1)) points.Add(p1);
                    if (line.IsOnSegment(p2)) points.Add(p2);
                }
                else if (d == 0)
                {
                    double _y = -B / (2 * A);

                    Point p = new Point(x, _y);
                    if (line.IsOnSegment(p)) points.Add(p);
                }
            }

            return points;
        }



    }
}
