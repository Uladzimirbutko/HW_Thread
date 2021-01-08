using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static readonly object locker = new object();

        static async Task Main(string[] args)
        {

            var a =  await PrintMatrixAsync("A"); // ждем

            var b =  await PrintMatrixAsync("B");//ждем

            Console.WriteLine("Перемножение матрицы может занять некоторое время. Рекомендуется пока посмотреть на работу садовников.");
            Console.WriteLine($"Нажмите \"Y\", если хотите сразу посмотреть результат уможения матрицы или любую клавишу, что бы посмотреть сначала работу садовников");

            var str = Console.ReadLine().ToUpper();

            var task = MatrixMultiplicationAsync(a, b); //не ждем. умножается паралельно.

            if (str == "Y")
            {
                Console.WriteLine("Матрицы умножаются. Подождите завершения.");
                ulong[,] resultY = await task; //ждем завершения 
                Console.WriteLine("Матрицы умножены. Нажмите любую клавишу для начала вывода. После окончания вывода нажмите любую клавишу и запустятся садовники.\n");
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

            Console.WriteLine("\nПлан отработанного сада");
            GardenPlan.PrintGargen();

            if (str != "Y") // если ранее не ждали то вот.
            {
                Console.WriteLine("Матрицы всё еще умножаются. Подождите завершения.");
                ulong[,] result = await task; // дожидаемся завершения умножения и приводим Task<ulong[,]> к ulong[,]
                Console.WriteLine("Матрицы умножены. Нажмите любую клавишу для начала вывода.\n");
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
