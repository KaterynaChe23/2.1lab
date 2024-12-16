using lab2_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            MyMatrix matrixA, matrixB;

            Console.WriteLine("Виберіть спосіб введення матриць:");
            Console.WriteLine("1. Ввести матриці вручну.");
            Console.WriteLine("2. Створити матриці з випадковими числами.");
            Console.Write("Вибір: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                matrixA = InputMatrix("A");
                matrixB = InputMatrix("B");
            }

            else if (choice == 2)
            {
                matrixA = GenerateRandomMatrix("A");
                matrixB = GenerateRandomMatrix("B");
            }

            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            if (matrixA.Height != matrixB.Height || matrixA.Width != matrixB.Width)
        {
            Console.WriteLine("Матриці мають різні розміри! Операції додавання та множення неможливі.");
            return;
        }
            Console.WriteLine("\nМатриця A:");
            Console.WriteLine(matrixA);

            Console.WriteLine("\nМатриця B:");
            Console.WriteLine(matrixB);

            try
            {
                MyMatrix resultAdd = matrixA + matrixB;
                Console.WriteLine("\nРезультат додавання матриць:");
                Console.WriteLine(resultAdd);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні: {ex.Message}");
            }

            
            try
            {
                MyMatrix resultMultiply = matrixA * matrixB;
                Console.WriteLine("\nРезультат множення матриць:");
                Console.WriteLine(resultMultiply);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при множенні: {ex.Message}");
            }

            
            Console.WriteLine("\nТранспонування матриці A:");
            matrixA.TransponeMe();
            Console.WriteLine(matrixA);

            Console.WriteLine("\nТранспонування матриці B:");
            matrixB.TransponeMe();
            Console.WriteLine(matrixB);
        }

        // Функція для введення матриці вручну
        public static MyMatrix InputMatrix(string name)
        {
            Console.WriteLine($"\nВведіть розміри матриці {name}:");
            Console.Write("Кількість рядків: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Кількість стовпців: ");
            int cols = int.Parse(Console.ReadLine());

            double[,] data = new double[rows, cols];
            Console.WriteLine($"Введіть елементи матриці {name}:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                    data[i, j] = double.Parse(Console.ReadLine());
                }
            }

            return new MyMatrix(data);
        }


        // Функція для генерації матриці з випадковими числами
        public static MyMatrix GenerateRandomMatrix(string name)
        {
            Console.WriteLine($"\nВведіть розміри для випадкової матриці {name}:");
            Console.Write("Кількість рядків: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Кількість стовпців: ");
            int cols = int.Parse(Console.ReadLine());

            Console.Write("Введіть мінімальне значення для елементів: ");
            double minValue = double.Parse(Console.ReadLine());
            Console.Write("Введіть максимальне значення для елементів: ");
            double maxValue = double.Parse(Console.ReadLine());

            Random rand = new Random();
            double[,] data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = rand.NextDouble() * (maxValue - minValue) + minValue; 
                }
            }

            Console.WriteLine($"Випадкова матриця {name} згенерована.");
            return new MyMatrix(data);
        }
    }
}
