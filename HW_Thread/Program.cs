using System;

namespace HW_Thread
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("MATRIX");

            var a = Matrix.GetMatrixFromConsole("A");
            var b = Matrix.GetMatrixFromConsole("B");

            Console.WriteLine("\nMatrix A:");
            Matrix.PrintMatrix(a);

            Console.WriteLine("\nMatrix B:");
            Matrix.PrintMatrix(b);

            var result = Matrix.MatrixMultiplication(a, b);
            Console.WriteLine("Multiplication Matrix:");
            Matrix.PrintMatrixResult(result);

            Console.ReadLine();

        }
    }
}
