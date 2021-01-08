using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var a =  await PrintMatrixAsync("A"); // ждем

            var b =  await PrintMatrixAsync("B");//ждем
            //
            Console.WriteLine("Matrix multiplication can take some time. It is recommended to take a look at the gardeners' work for now.");
            Console.WriteLine($"Press \"Y \" if you want to immediately see the result of the matrix reduction or any key to see the gardeners work first.");

            var str = Console.ReadLine().ToUpper();

            var task = MatrixMultiplicationAsync(a, b); //не ждем. умножается паралельно.

            if (str == "Y")
            {
                Console.WriteLine("Matrices are multiplied. Wait for completion.");
                ulong[,] resultY = await task; //ждем завершения 
                Console.WriteLine("The matrices are multiplied. Press any key to start output. After the end of the output, press any key and the gardeners will start.\n");
                Console.ReadKey();
                PrintMatrixMultiplicationAsync(resultY); // вывод
                Console.ReadKey();
            }

            GardenPlan.Wood(); //созд. дерево
            //два потока запускают двух садовников одновременно.
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
            task1.Wait(); // ждем завершения первого
            task2.Wait(); // второго

            Console.WriteLine("\nGarden plan.");
            GardenPlan.PrintGargen();

            if (str != "Y") // если ранее не ждали то вот.
            {
                Console.WriteLine("Matrices are multiplied. Wait for completion.");
                ulong[,] result = await task; // дожидаемся завершения умножения и приводим Task<ulong[,]> к ulong[,]
                Console.WriteLine("The matrices are multiplied. Press any key to start output.\n");
                Console.ReadKey();
                PrintMatrixMultiplicationAsync(result);
            }
            Console.ReadKey();
        }

        static async Task<ulong[,]> PrintMatrixAsync(string name) 
        {
            return await Task.Run(() => Matrix.GetMatrixFromConsole(name));
        }

        static async ValueTask<ulong[,]> MatrixMultiplicationAsync(ulong[,] a, ulong[,] b)
        {
            return await Task.Run(() => Matrix.MatrixMultiplication(a, b));
        }

        static async void PrintMatrixMultiplicationAsync(ulong[,] result)
        {
            await Task.Run(() => Matrix.PrintMatrixResult(result));
        }

    }
}
