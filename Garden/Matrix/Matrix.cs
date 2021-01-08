using System;
using System.Collections.Generic;

namespace Garden
{
    public static class Matrix
    {

        public static ulong[,] GetMatrixFromConsole(string name)
        {
            try
            {
                Console.WriteLine($"Matrix {name}");
                Console.WriteLine($"Количество строк матрицы: {name}");
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine($"Количество столбцов матрицы: {name}");
                var m = int.Parse(Console.ReadLine());
                var matrix = new ulong[n, m];
                var rnd = new Random();
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < m; j++)
                    {
                        matrix[i, j] = Convert.ToUInt64(rnd.Next(0, 10));
                        //Console.Write($"{matrix[i, j]} "); //для вывода каждой матрицы отдельно - раскомментировать это и строку ниже.
                    }
                    //Console.WriteLine(); 
                }
                return matrix;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                GetMatrixFromConsole(name);
                return default;
            }
        }

        public static void PrintMatrixResult(ulong[,] matrix)
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        public static ulong[,] MatrixMultiplication(ulong[,] matrixA, ulong[,] matrixB)
        {
            try
            {
                var matrixC = new ulong[matrixA.RowsCount(), matrixB.ColumnsCount()];

                for (var i = 0; i < matrixA.RowsCount(); i++)
                {
                    for (var j = 0; j < matrixB.ColumnsCount(); j++)
                    {
                        matrixC[i, j] = 0;

                        for (var k = 0; k < matrixA.ColumnsCount(); k++)
                        {
                            matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                        }
                    }
                }
                return matrixC;
            }
            catch (Exception)
            {
                Console.WriteLine("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
                return default;
            }
        }
    }
}