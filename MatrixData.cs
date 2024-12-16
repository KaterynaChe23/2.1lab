
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
   public partial class MyMatrix
    {
        private double[,] matrix;
        private int rows;
        private int cols;

       
        public MyMatrix(MyMatrix other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Масив не може бути null");

             rows = other.matrix.GetLength(0);
             cols = other.matrix.GetLength(1);

            this.matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = other.matrix[i, j];
                }
            }

        }




        public MyMatrix(double[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "Масив не може бути null");


             rows = matrix.GetLength(0);
             cols = matrix.GetLength(1);

            this.matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }

        public MyMatrix(double[][] jaggedArray)
        {
            rows = jaggedArray.Length;
            if (jaggedArray == null || rows == 0)
                throw new ArgumentNullException(nameof(jaggedArray), "Масив не може бути null та бути порожнім");


             cols = jaggedArray[0].Length;
            for (int i = 1; i < rows; i++)
            {
                if (jaggedArray[i].Length != cols)
                    throw new ArgumentException("Зубчастий масив не є прямокутним");
            }

            this.matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = jaggedArray[i][j];
                }
            }
        }


        public MyMatrix(string[] lines)
        {
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            List<double[]> list = new List<double[]>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                double[] row = Array.ConvertAll(parts, double.Parse);
                list.Add(row);

            }

            rows = list.Count;
            cols = list[0].Length;
            for (int i = 0; i < rows; i++)
            {
                if (list[i].Length != cols)
                    throw new ArgumentException("Рядки повнні містии однакову к-ть чисел");
            }
            this.matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = list[i][j];
                }
            }

        }
        public MyMatrix(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            string[] lines = input.Split(new[] {'\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<double[]> list = new List<double[]>();
            for (int i = 0; i < input.Length; i++)
            {
                string line = lines[i];
                string[] parts = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                double[] row = Array.ConvertAll(parts, double.Parse);
                list.Add(row);
            }

            rows = list.Count;
            cols = list[0].Length;
            for (int i = 0; i < rows; i++)
            {
                if (list[i].Length != cols)
                    throw new ArgumentException("Рядки повнні містии однакову к-ть чисел");
            }
            this.matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = list[i][j];
                }
            }
        }

        public int Height { get { return rows; } }
        public int Width { get { return cols; } }

        public int getHeight()
        {
            return rows;
        }

        public int getWidth()
        {
            return cols;
        }

        public double this[int rows, int cols]
        {
            get
            {
                if (rows < 0 || rows >= matrix.GetLength(0) || cols < 0 || cols >= matrix.GetLength(1))
                    throw new ArgumentOutOfRangeException("index");
                return matrix[rows, cols];
            }
            set
            {
                if (rows < 0 || rows >= matrix.GetLength(0) || cols < 0 || cols >= matrix.GetLength(1))
                    throw new ArgumentOutOfRangeException("index");
                matrix[rows, cols] = value;

            }

        }

        public double getElement(int rows,int cols)
        {
            return this[rows,cols];
        }
        public void setElement(int rows, int cols, double value)
        {
            this[rows, cols]= value;
        }
        public override string ToString()
        {
            if (matrix == null || matrix.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++) 
                {
                    sb.Append(matrix[i, j].ToString("F2")); 
                    if (j < matrix.GetLength(1) - 1)
                        sb.Append("\t"); 
                }
                sb.AppendLine(); 
            }

            return sb.ToString();
        }


    }
}




