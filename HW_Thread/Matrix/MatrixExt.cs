namespace HW_Thread
{
    public static class MatrixExt
    {
        
            // получение количества строк матрицы
            public static int RowsCount(this ulong[,] matrix)
            {
                return matrix.GetUpperBound(0) + 1;
            }

            // получение количества столбцов матрицы
            public static int ColumnsCount(this ulong[,] matrix)
            {
                return matrix.GetUpperBound(1) + 1;
            }
        
    }
}