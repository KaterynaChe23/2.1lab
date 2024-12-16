using lab2_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1;
    

 public partial class MyMatrix
{
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.Height != b.Height || a.Width != b.Width)
            throw new InvalidOperationException("Matrices must have the same dimensions for addition.");

        double[,] result = new double[a.Height, a.Width];

        for (int i = 0; i < a.Height; i++)
            for (int j = 0; j < a.Width; j++)
                result[i, j] = a[i, j] + b[i, j];

        return new MyMatrix(result);
    }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.Width != b.Height)
            throw new InvalidOperationException("Number of columns in the first matrix must equal the number of rows in the second matrix.");

        double[,] result = new double[a.Height, b.Width];

        for (int i = 0; i < a.Height; i++)
            for (int j = 0; j < b.Width; j++)
                for (int k = 0; k < a.Width; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return new MyMatrix(result);
    }

    private double[,] GetTransponedArray()
    {
        int rows = Height;
        int cols = Width;
        double[,] transposed = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }

        return transposed;
    }

    public MyMatrix GetTransponedCopy()
    {
        return new MyMatrix(GetTransponedArray());
    }

    public void TransponeMe()
    {
        matrix = GetTransponedArray();
    }
}




