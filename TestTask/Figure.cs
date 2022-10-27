using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public abstract class Figure
    {
        public abstract void Draw();
        public abstract void Intersect(Figure figure);
    }
}
