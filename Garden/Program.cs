using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static object locker = new object();

        static void Main(string[] args)
        {

            GardenPlan.Wood();
            var task1 = Task.Factory.StartNew(() =>
            {
                var gardener1 = new Gardener1();
                gardener1.Track();

            });

            var task2 = Task.Factory.StartNew(() =>
            {
                var gardener2 = new Gardener2();
                gardener2.Track();
            });
            Console.ReadKey();

            lock (locker)
            {
                Console.WriteLine("\nПлан отработанного сада");
                GardenPlan.PrintGargen();
                Matr();
            }
            Console.ReadKey();
        }

        static async void Matr() 
        {
            Console.WriteLine("MATRIX");

            var a = Matrix.Matrix.GetMatrixFromConsole("A");
            var b = Matrix.Matrix.GetMatrixFromConsole("B");

            Console.WriteLine("\nMatrix A:");
            await Task.Run(() => Matrix.Matrix.PrintMatrix(a));//вывод матрицы А

            Console.WriteLine("\nMatrix B:");
            await Task.Run(() => Matrix.Matrix.PrintMatrix(b)); //вывод матрицы В

            var result = Matrix.Matrix.MatrixMultiplication(a, b);
            Console.WriteLine("\nMultiplication Matrix:");
            await Task.Run(() => Matrix.Matrix.PrintMatrixResult(result));
        }

    }
}
