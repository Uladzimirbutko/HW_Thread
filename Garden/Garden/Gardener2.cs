using System;
using System.Threading;

namespace Garden
{
    public class Gardener2 : GardenPlan
    {
        public void Track()
        {
            for (int i = 9; i < GardenPlan.garden.GetLength(0) && i >= 0; i--)
            {
                for (int j = 9; j < GardenPlan.garden.GetLength(1)&& j >= 0; j--)
                {
                    if (garden[j, i] == 0)
                    {
                        garden[j, i] = 2;
                        Console.WriteLine($"T2 - {garden[j, i]}. pos - {i},{j}");
                    }
                    else if (garden[j, i] == 3)
                    {
                        Console.Write("T");
                        
                    }
                    else if (garden[j, i] == 1)
                    {
                        Console.Write("#");
                        
                    }
                }

            }
        }
    }
}