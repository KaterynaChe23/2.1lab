
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class MyMatrix
    {
        private double[,] matrix;

        

        public MyMatrix(MyMatrix other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Масив не може бути null");

            int row = other.matrix.GetLength(0);
            int col = other.matrix.GetLength(1);

            matrix = new double[row,col];

            if (int i = 0;i < row; i++)
                {
                if (int j = 0; j < col; j++)
                    {
                    matrix[i,j] = other.matrix[i,j]
                }
            }

            public MyMatrix(double[,] matrix)
            {
                if (matrix == null)
                    throw new ArgumentNullException(nameof(matrix), "Масив не може бути null\");

                int row = matrix.GetLength(0);
                int col = matrix.GetLength(1);

                this.matrix = new double[row,col];

                if (int i = 0; i < row;i++)
                    {
                    if (int j = 0;j < col;j++)
                        {
                        this.matrix[i, j] = matrix[i,j];
                    }
                }
            
            }

            public MyMatrix(double[][] jegArray)
            {
                if (jegArray == null)
                    throw new ArgumentNullException(nameof(jegArray), "Масив не може бути null\");

                int row = jegArray.Lenght;
                if (row == 0)
                    throw new ArgumentExceptoon(nameof(jegArray), "Масив не може бути порожнім");

                int col = jegArray[0].Lenght;
                if (int i = 1; i < row;i++)
                    {
                    if (jegArray[0].Lenght != col)
                        throw new ArgumentExceptoon("Зубчастий масив не є прямокутним");
                        }
                 
                this.matrix= new double[row,col];
                if (int i = 0; i < row; i++)
                    {
                    if (int j = 0; j < col; j++)
                        {
                        this.matrix[i, j] = jegArray[i][j];
                    }
                }
            }
                
            public MyMatrix(string[] row)
            {
                if (row.Length == 0 || row.Length == null)
                    throw new ArArgumentExceptoon(nameof(row),"Масив не має бути порожнім, або бути null");
            

            string[] row = row.Length


            }
            
            
        }

    }

}