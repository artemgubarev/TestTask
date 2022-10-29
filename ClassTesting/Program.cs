using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask;

namespace ClassTesting
{
    class Program
    {
        static List<Figure> init()
        {
            List<Figure> figures = new List<Figure>();

            string path = "..\\..\\TestData.txt";
            String string_line;

            try
            {
                Creator creator;

                StreamReader sr = new StreamReader(path);
                string_line = sr.ReadLine();
                while (string_line != null)
                {
                    string[] lines = string_line.Split();

                    switch (lines[0])
                    {
                        case "point":
                            creator = new PointCreator();
                            Figure point = creator.Create(new double[] { Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]) });
                            figures.Add(point);
                            break;

                        case "line":
                            creator = new LineCreator();
                            Figure line = creator.Create(new double[] { Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]),
                            Convert.ToDouble(lines[3]), Convert.ToDouble(lines[4]) });
                            figures.Add(line);
                            break;

                        case "circle":
                            creator = new CircleCreator();
                            Figure circle = creator.Create(new double[] { Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]), Convert.ToDouble(lines[3]) });
                            figures.Add(circle);
                            break;

                        case "rect":
                            creator = new RectCreator();
                            Figure rect = creator.Create(new double[] { Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]),
                                Convert.ToDouble(lines[3]), Convert.ToDouble(lines[4]) });
                            figures.Add(rect);
                            break;
                    }

                    string_line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return figures;
        }

        static void Main(string[] args)
        {
            List<Figure> figures = init();

            foreach (var figure1 in figures)
                foreach (var figure2 in figures)
                {
                    figure1.Draw();
                    figure2.Draw();
                    figure1.Intersect(figure2);
                    figure2.Intersect(figure1);
                    Console.WriteLine();
                }
        }
    }
}
