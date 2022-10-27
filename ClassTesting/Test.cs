using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask;

namespace ClassTesting
{
    public static class Test
    {
        public static void testPoint()
        {
            Point point1 = new Point(2, 2);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(2.001, 1.991);

            point1.Draw();
            point2.Draw();
            point1.Intersect(point2);
            Console.WriteLine();
            point1.Draw();
            point3.Draw();
            point1.Intersect(point3);

            Console.WriteLine();
            
            Line line = new Line(new Point[2] { new Point(0,0), new Point(3,3)});
            point1.Draw();
            line.Draw();
            point1.Intersect(line);
            Console.WriteLine();
            point3.Draw();
            line.Draw();
            point3.Intersect(line);

            Console.WriteLine();

            Circle circle = new Circle(new Point(4,2), 2);
            point1.Draw();
            circle.Draw();
            point1.Intersect(circle);
            Console.WriteLine();
            point3.Draw();
            circle.Draw();
            point3.Intersect(circle);

            Console.WriteLine();

            Rect rect = new Rect(new Point[2] { new Point(0, 0), new Point(2, 2) });
            point1.Draw();
            rect.Draw();
            point1.Intersect(rect);
            Console.WriteLine();
            point3.Draw();
            rect.Draw();
            point3.Intersect(rect);

            Console.WriteLine();
        }

        public static void testLine()
        {
            Line line1 = new Line(new Point[2] { new Point(0, 0), new Point(3, 3) });

            Point point1 = new Point(2, 2);
            Point point2 = new Point(2.01, 2);
            point1.Draw();
            line1.Draw();
            line1.Intersect(point1);
            Console.WriteLine();
            point2.Draw();
            line1.Draw();
            line1.Intersect(point2);

            Console.WriteLine();

            Line line2 = new Line(new Point[2] { new Point(3, 0), new Point(0, 3) });
            Line line3 = new Line(new Point[2] { new Point(0, 0), new Point(0, 3) });
            Line line4 = new Line(new Point[2] { new Point(-2, 1), new Point(3, 1) });
            Line line5 = new Line(new Point[2] { new Point(-2, 2), new Point(3, 2) });
            line1.Draw();
            line2.Draw();
            line1.Intersect(line2);
            Console.WriteLine();
            line3.Draw();
            line4.Draw();
            line3.Intersect(line4);
            Console.WriteLine();
            line2.Draw();
            line3.Draw();
            line2.Intersect(line3);
            Console.WriteLine();
            line4.Draw();
            line5.Draw();
            line4.Intersect(line5);

            Console.WriteLine();

            Circle circle = new Circle(new Point(4, 2), 2);
            line1.Draw();
            circle.Draw();
            line1.Intersect(circle);
            Console.WriteLine();
            line2.Draw();
            circle.Draw();
            line2.Intersect(circle);
            Console.WriteLine();
            line3.Draw();
            circle.Draw();
            line3.Intersect(circle);
            Console.WriteLine();
            line4.Draw();
            circle.Draw();
            line4.Intersect(circle);
            Console.WriteLine();
            line5.Draw();
            circle.Draw();
            line5.Intersect(circle);

            Console.WriteLine();

            Rect rect = new Rect(new Point[2] { new Point(0, 0), new Point(2, 2) });
            line1.Draw();
            rect.Draw();
            line1.Intersect(rect);
            Console.WriteLine();
            line2.Draw();
            rect.Draw();
            line2.Intersect(rect);
            Console.WriteLine();
            line3.Draw();
            rect.Draw();
            line3.Intersect(rect);
            Console.WriteLine();
            line4.Draw();
            rect.Draw();
            line4.Intersect(rect);
            Console.WriteLine();
            line5.Draw();
            rect.Draw();
            line5.Intersect(rect);
        }


        public static void testCircle()
        {
            Circle circle1 = new Circle(new Point(2, 2), 2);

            Point point1 = new Point(2, 2);
            Point point2 = new Point(4, 2);
            Point point3 = new Point(4.5, 3.1);
            point1.Draw();
            circle1.Draw();
            circle1.Intersect(point1);
            Console.WriteLine();
            point2.Draw();
            circle1.Draw();
            circle1.Intersect(point2);
            Console.WriteLine();
            point3.Draw();
            circle1.Draw();
            circle1.Intersect(point3);

            Console.WriteLine();

            Line line1 = new Line(new Point[2] { new Point(4, 0), new Point(0, 4) });
            Line line2 = new Line(new Point[2] { new Point(0, 0), new Point(4,4) });
            Line line3 = new Line(new Point[2] { new Point(3, 1), new Point(1, 3) });
            line1.Draw();
            circle1.Draw();
            circle1.Intersect(line1);
            Console.WriteLine();
            line2.Draw();
            circle1.Draw();
            circle1.Intersect(line2);
            Console.WriteLine();
            line3.Draw();
            circle1.Draw();
            circle1.Intersect(line3);

            Console.WriteLine();

            Circle circle2 = new Circle(new Point(0, 0), 2);
            Circle circle3 = new Circle(new Point(2, 2), 1);
            Circle circle4 = new Circle(new Point(6, 2), 2);
            circle2.Draw();
            circle1.Draw();
            circle1.Intersect(circle2);
            Console.WriteLine();
            circle3.Draw();
            circle1.Draw();
            circle1.Intersect(circle3);
            Console.WriteLine();
            circle4.Draw();
            circle1.Draw();
            circle1.Intersect(circle4);

            Console.WriteLine();

            Rect rect1 = new Rect(new Point[2] { new Point(1, 1), new Point(2, 2) });
            Rect rect2 = new Rect(new Point[2] { new Point(1, 1), new Point(5, 5) });
            rect1.Draw();
            circle1.Draw();
            circle1.Intersect(rect1);
            Console.WriteLine();
            rect2.Draw();
            circle1.Draw();
            circle1.Intersect(rect2);
        }

        public static void testRect()
        {
            Rect rect1 = new Rect(new Point[2] { new Point(1, 1), new Point(5, 6) });

            Point point1 = new Point(2, 1);
            Point point2 = new Point(3, 6);
            Point point3 = new Point(4.5, 3.1);
            point1.Draw();
            rect1.Draw();
            rect1.Intersect(point1);
            Console.WriteLine();
            point2.Draw();
            rect1.Draw();
            rect1.Intersect(point2);
            Console.WriteLine();
            point3.Draw();
            rect1.Draw();
            rect1.Intersect(point3);

            Console.WriteLine();

            Line line1 = new Line(new Point[2] { new Point(4, 0), new Point(0, 4) });
            Line line2 = new Line(new Point[2] { new Point(2, -1), new Point(2, 7) });
            Line line3 = new Line(new Point[2] { new Point(0, 0), new Point(8, 8) });
            line1.Draw();
            rect1.Draw();
            rect1.Intersect(line1);
            Console.WriteLine();
            line2.Draw();
            rect1.Draw();
            rect1.Intersect(line2);
            Console.WriteLine();
            line3.Draw();
            rect1.Draw();
            rect1.Intersect(line3);

            Console.WriteLine();

            Circle circle2 = new Circle(new Point(3, 3), 1);
            Circle circle3 = new Circle(new Point(2, 2), 3);
            Circle circle4 = new Circle(new Point(0.5, 0.5), 0.8);
            circle2.Draw();
            rect1.Draw();
            rect1.Intersect(circle2);
            Console.WriteLine();
            circle3.Draw();
            rect1.Draw();
            rect1.Intersect(circle3);
            Console.WriteLine();
            circle4.Draw();
            rect1.Draw();
            rect1.Intersect(circle4);

            Console.WriteLine();

            Rect rect2 = new Rect(new Point[2] { new Point(2, 3), new Point(4, 5) });
            Rect rect3 = new Rect(new Point[2] { new Point(3, 0), new Point(6, 2) });
            rect2.Draw();
            rect1.Draw();
            rect1.Intersect(rect2);
            Console.WriteLine();
            rect3.Draw();
            rect1.Draw();
            rect1.Intersect(rect3);
        }

        

    }
}
