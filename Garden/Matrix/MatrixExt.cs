using System;

namespace Garden
{
    public static class MatrixExt
    {
        // получение количества строк матрицы
        public static int RowsCount(this ulong[,] matrix)
        {
            try
            {
                return matrix.GetUpperBound(0) + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
            
        }

        // получение колличества столбцов матрицы
        public static int ColumnsCount(this ulong[,] matrix)
        {
            try
            {
                return matrix.GetUpperBound(1) + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
            
        }
    }
}