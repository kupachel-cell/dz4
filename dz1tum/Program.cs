using System;

namespace dz1tum
{
    internal class Program
    {
        static int Maxnum(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }
        static void Swap(ref string firstvar, ref string secondvar)
        {
            string buffer = firstvar;
            firstvar = secondvar;
            secondvar = buffer;
        }
        static bool TryCalculateFactorial(int number, out long result)
        {
            result = 1;
            if (number < 0)
            {
                result = 0;
                return false;
            }

            try
            {
                checked
                {
                    for (int i = 2; i <= number; i++)
                    {
                        result *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                result = 0;
                return false;
            }
        }
        static long CalculateFactorialRecursive(int n)
        {

            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * CalculateFactorialRecursive(n - 1);
        }
            static void Main(string[] args)
        {
            //Console.WriteLine("Упражнение 5.1\nВведите первое число (по умолчанию 0)");
            //int number1, number2;
            //bool isnumber1 = int.TryParse(Console.ReadLine(), out number1);
            //Console.WriteLine("Введите второе число (по умолчанию 0)");
            //bool isnumber2 = int.TryParse(Console.ReadLine(), out number2);
            //Console.WriteLine($"Число {Maxnum(number1, number2)} наибольшее");
            //Console.ReadKey();

            //Console.WriteLine("Упражнение 5.2\nВведите первое значение");
            //string firstvariable = Console.ReadLine();
            //Console.WriteLine("Введите второе значение");
            //string secondvariable = Console.ReadLine();
            //Swap(ref secondvariable, ref firstvariable);
            //Console.WriteLine($"Теперь первое значение равно {firstvariable}, а второе {secondvariable} ");
            //Console.ReadKey();

            //Console.WriteLine("Упражнение 5.3\nВведите число, факториал которого будет браться");
            //int factnum;
            //if (!int.TryParse(Console.ReadLine(),out factnum)){
            //    Console.WriteLine("Это не число");
            //}

            //if (TryCalculateFactorial(factnum, out long result1))
            //{
            //    Console.WriteLine($"Факториал {factnum} равен: {result1}");
            //}
            //else
            //{
            //    Console.WriteLine($"Ошибка: при вычислении факториала {factnum} произошло переполнение!");
            //}
            //Console.ReadKey();

            Console.WriteLine("Упражнение 5.4\nвведите число для вычисления факториала");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num < 0)
                {
                    Console.WriteLine("Ошибка: факториал отрицательного числа не определен.");
                }
                else
                {
                    try
                    {
                        long result = checked(CalculateFactorialRecursive(num));
                        Console.WriteLine($"Факториал {num} равен: {result}");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"Ошибка: при вычислении факториала {num} произошло переполнение!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введено не число.");
            }


        }   
    }
}
