using System;

public class Matrix
{
    private int[,] data;

    public Matrix(int rows, int cols)
    {
        data = new int[rows, cols];
    }

    public int Rows => data.GetLength(0);
    public int Cols => data.GetLength(1);

    public int this[int row, int col]
    {
        get { return data[row, col]; }
        set { data[row, col] = value; }
    }

    public int FindMaxInColumn(int col)
    {
        int max = int.MinValue;
        for (int i = 0; i < Rows; i++)
        {
            if (data[i, col] > max)
                max = data[i, col];
        }
        return max;
    }
}
