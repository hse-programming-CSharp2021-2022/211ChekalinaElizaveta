using System;

namespace Figures
{
    internal class Program
    {
        private static Random random = new Random(119);
        private static Point GeneratePoint()
        {
            double x1 = random.NextDouble() - 0.5;
            double y1 = random.NextDouble() - 0.5;
            double x = x1 * 50;
            double y = y1 * 50;
            return new Point(x, y);
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit;
            do
            {
                int n;
                do
                {
                    Console.WriteLine("Введите кол-во фигур");
                    int.TryParse(Console.ReadLine(), out n);
                } while (n <= 0);
                Figure[] figs = new Figure[n];
                for (int i = 0; i < figs.Length; i++)
                {
                    bool success = false;
                    while (!success)
                    {
                        int coin2 = random.Next(2);
                        double rndLen = (random.NextDouble() - 0.5) * 25;
                        if (coin2 == 0)
                        {
                            try
                            {
                                var triangle = new EqTriangle(GeneratePoint(), rndLen);
                                success = true;
                                figs[i] = triangle;
                            }
                            catch (ArgumentException e)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                var sq = new Square(GeneratePoint(), rndLen);
                                success = true;
                                figs[i] = sq;
                            }
                            catch (ArgumentException e)
                            {
                            }
                        }
                    }
                    Console.WriteLine($"{i} : {figs[i]}");
                }
                // генерируем ещё одну фигуру.
                Console.WriteLine("Генерируем ещё 1 фигуру.");
                int coin = random.Next(2);
                Figure newFig = null;
                if (coin == 0)
                {
                    bool success = false;
                    while (!success)
                    {
                        double rndLen = (random.NextDouble() - 0.5) * 25;
                        try
                        {
                            var triangle = new EqTriangle(GeneratePoint(), rndLen);
                            success = true;
                            newFig = triangle;
                        }
                        catch (ArgumentException e)
                        {

                        }
                    }

                }
                else
                {
                    bool success = false;
                    while (!success)
                    {
                        double rndLen = (random.NextDouble() - 0.5) * 25;
                        try
                        {
                            var sq = new Square(GeneratePoint(), rndLen);
                            success = true;
                            newFig = sq;
                        }
                        catch (ArgumentException e)
                        {

                        }
                    }
                }
                Console.WriteLine($"New figure: {newFig}");
                double meanAreaOfTriangles = 0;
                int amntTriangles = 0;
                double minArea = -1;
                Square smolSquare = null;
                for (int k = 0; k < figs.Length; k++)
                {
                    if (figs[k].ClosenessZoneIntersects(newFig))
                    {
                        Console.WriteLine($"Figure cl. z. intersects {k}: {figs[k]}");
                    }
                    if (figs[k] is EqTriangle)
                    {
                        meanAreaOfTriangles += figs[k].Area;
                        amntTriangles++;
                    }
                    if (figs[k] is Square && (minArea > figs[k].Area || minArea == -1))
                    {
                        minArea = figs[k].Area;
                        smolSquare = figs[k] as Square;

                    }

                }
                if (amntTriangles > 0)
                {
                    meanAreaOfTriangles /= amntTriangles;
                } else {
                    meanAreaOfTriangles = 0;
                }
                Console.WriteLine($"Mean triangle area: {meanAreaOfTriangles:F3}");
                if (smolSquare != null)
                {
                    Console.WriteLine($"Min square area: {minArea:F3}, square info: {smolSquare}");
                }
                else
                {
                    Console.WriteLine($"Min square area: {0:F3}, square info: no squares found :( ");
                }



                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}
