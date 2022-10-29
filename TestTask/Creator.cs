using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public interface Creator
    {
        Figure Create(double[] args);
    }

    public class PointCreator: Creator
    {
        public Figure Create(double[] args)
        {
            return new Point(args[0], args[1]);
        }
    }

    public class LineCreator : Creator
    {
        public Figure Create(double[] args)
        {
            return new Line(new Point[2] { new Point(args[0], args[1]), new Point(args[2], args[3])});
        }
    }

    public class CircleCreator : Creator
    {
        public Figure Create(double[] args)
        {
            return new Circle(new Point(args[0], args[1]), args[2]);
        }
    }

    public class RectCreator : Creator
    {
        public Figure Create(double[] args)
        {
            return new Rect(new Point[2] { new Point(args[0], args[1]), new Point(args[2], args[3]) });
        }
    }

}
