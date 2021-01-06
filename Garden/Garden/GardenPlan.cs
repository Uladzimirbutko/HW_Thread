using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Garden
{
    public class GardenPlan
    {
        
        public static int[,] garden = new int[10,10];
        public static void Wood()
        {
            Random rnd = new Random();
            garden[rnd.Next(0,10), rnd.Next(0,10)] = 3; // Wood
        }

        public static void PrintGargen()
        {
            for (var i = 0; i < garden.GetLength(0); i++)
            {
                for (var j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($" {garden[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}