using System;
using System.Threading;

namespace Garden
{
    public class Gardener1 : GardenPlan
    {
        public void Track()
        {
            for (int i = 0; i < GardenPlan.garden.GetLength(0); i++)
            {
                for (int j = 0; j < GardenPlan.garden.GetLength(1); j++)
                {
                    if (garden[i,j] == 0)
                    {
                        garden[i, j] = 1;
                        Console.WriteLine($"T1 - {garden[i, j]}. pos - {i},{j} ");
                    }
                    else if (garden[i,j] == 3)
                    {
                        Console.Write("T");
                        
                    }
                    else if (garden[i, j] == 2)
                    {
                        Console.Write("#");
                        
                    }
                }
            }
        }
    }
}