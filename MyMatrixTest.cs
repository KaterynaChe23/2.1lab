using System;
using lab2_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyMatrixTest
{
    [TestClass]
    public class MyMatrixTest
    {
        [TestMethod]
        public void Other_MartixCopy()
        {
            double[,] matrix = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix1 = new MyMatrix(matrix);
            MyMatrix matrix2 = new MyMatrix(matrix1);

            Assert.AreEqual(matrix1.Height, matrix2.Height);
            Assert.AreEqual(matrix1.Width, matrix2.Width);
            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix1.Width; j++)
                {
                    Assert.AreEqual(matrix1[i, j], matrix2[i, j]);
                }
            }

        }

        [TestMethod]
        public void Constructor_CopyConstructor_ThrowsArgumentNullException_WhenOtherIsNull()
        {
            MyMatrix nullMatrix = null;
            Assert.ThrowsException<ArgumentNullException>(() => new MyMatrix(nullMatrix));
        }

        [TestMethod]
        public void Constructor_ArrayConstructor_CreatesMatrixCorrectly()
        {
            double[,] array = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(array);

            Assert.AreEqual(array.GetLength(0), matrix.Height);
            Assert.AreEqual(array.GetLength(1), matrix.Width);
            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    Assert.AreEqual(array[i, j], matrix[i, j]);
                }
            }
        }
        [TestMethod]
        public void Constructor_ArrayConstructor_ThrowsArgumentNullException_WhenArrayIsNull()
        {
            double[,] nullArray = null;
            Assert.ThrowsException<ArgumentNullException>(() => new MyMatrix(nullArray));
        }

        public void Constructor_JaggedArrayConstructor_CreatesMatrixCorrectly()
        {
            double[][] jaggedArray = new double[][]
            {
                new double[] {1.0, 2.0},
                new double[] {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(jaggedArray);

            Assert.AreEqual(jaggedArray.Length, matrix.Height);
            Assert.AreEqual(jaggedArray[0].Length, matrix.Width);
            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    Assert.AreEqual(jaggedArray[i][j], matrix[i, j]);
                }
            }

        }

        [TestMethod]
        public void Constructor_JaggedArrayConstructor_ThrowsArgumentException_WhenJaggedArrayIsNotRectangular()
        {
            double[][] jaggedArray = new double[][]
            {
                new double[] {1.0, 2.0},
                new double[] {3.0}
            };
            Assert.ThrowsException<ArgumentException>(() => new MyMatrix(jaggedArray));
        }

       

        [TestMethod]
        public void Constructor_StringArrayConstructor_ThrowsArgumentNullException_WhenLinesIsNull()
        {
            string[] nullLines = null;
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new MyMatrix(nullLines));
            
        }


        [TestMethod]
        public void WhenLinesIsNull()
        { 
        
            string[] nullLines = null;
            Assert.ThrowsException<ArgumentNullException>(() => new MyMatrix(nullLines));
        }

        [TestMethod]
        
        public void Constructor_StringConstructor_CreatesMatrixCorrectly_WithDifferentSeparators()
        {
            string input = "1.0\t2.0\n3.0 4.0";

            MyMatrix matrix = new MyMatrix(input);

            Assert.AreEqual(2, matrix.Height);
            Assert.AreEqual(2, matrix.Width);
            Assert.AreEqual(1.0, matrix[0, 0]);
            Assert.AreEqual(2.0, matrix[0, 1]);
            Assert.AreEqual(3.0, matrix[1, 0]);
            Assert.AreEqual(4.0, matrix[1, 1]);
        }



        [TestMethod]
        public void Constructor_StringConstructor_ThrowsArgumentNullException_WhenInputIsNull()
        {
            string nullInput = null;
            Assert.ThrowsException<ArgumentNullException>(() => new MyMatrix(nullInput));
        }

        [TestMethod]
        public void Properties_HeightAndWidth_ReturnCorrectValues()
        {
            double[,] array = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(array);

            Assert.AreEqual(2, matrix.Height);
            Assert.AreEqual(2, matrix.Width);
        }

        [TestMethod]
        public void Indexer_GetAndSet_WorksCorrectly()
        {
            double[,] array = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(array);

            Assert.AreEqual(1.0, matrix[0, 0]);
            Assert.AreEqual(2.0, matrix[0, 1]);

            matrix[0, 0] = 5.0;
            matrix[0, 1] = 6.0;

            Assert.AreEqual(5.0, matrix[0, 0]);
            Assert.AreEqual(6.0, matrix[0, 1]);
        }

        [TestMethod]
        public void Indexer_ThrowsArgumentOutOfRangeException_WhenIndexIsOutOfRange()
        {
            double[,] array = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(array);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var value = matrix[-1, 0]; });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var value = matrix[0, -1]; });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var value = matrix[2, 0]; });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var value = matrix[0, 2]; });
        }

        [TestMethod]
        public void Method_GetElement_WorksCorrectly()
        {
            double[,] array = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(array);

            Assert.AreEqual(1.0, matrix.getElement(0, 0));
            Assert.AreEqual(2.0, matrix.getElement(0, 1));
        }

        [TestMethod ]
            public void Method_SetElement_WorksCorrectly()
        {
            double[,] array = {
                {1.0, 2.0},
                {3.0, 4.0}
            };
            MyMatrix matrix = new MyMatrix(array);

            matrix.setElement(0, 0, 5.0);
            matrix.setElement(0, 1, 6.0);

            Assert.AreEqual(5.0, matrix[0, 0]);
            Assert.AreEqual(6.0, matrix[0, 1]);
        }


    }

}