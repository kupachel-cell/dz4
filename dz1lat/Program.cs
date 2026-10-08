using System;
using System.Threading;
using dz1lat.structenums;
namespace dz1lat
{
    internal class Program
    {

        static bool SwapElements(int[] array, int value1, int value2)
        {
            int index1 = Array.IndexOf(array, value1);
            int index2 = Array.IndexOf(array, value2);

            if (index1 == -1 || index2 == -1)
            {
                return false;
            }
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;

            return true; 
        }
        static long CalculateArrayStats(out double avg, ref long prod, params int[] array)
        {
            if (array == null || array.Length == 0)
            {
                avg = 0;
                prod = 0;
                return 0;
            }

            long sum = 0;
            foreach (int number in array)
            {
                sum += number;
                prod *= number;
            }
            avg = (double)sum / array.Length;

            return sum;
        }
        static readonly string[][] DigitPatterns = new string[][]
        {
        new string[] { "###", "# #", "# #", "# #", "###" }, 
        new string[] { "  #", "  #", "  #", "  #", "  #" }, 
        new string[] { "###", "  #", "###", "#  ", "###" }, 
        new string[] { "###", "  #", "###", "  #", "###" }, 
        new string[] { "# #", "# #", "###", "  #", "  #" }, 
        new string[] { "###", "#  ", "###", "  #", "###" }, 
        new string[] { "###", "#  ", "###", "# #", "###" }, 
        new string[] { "###", "  #", "  #", "  #", "  #" }, 
        new string[] { "###", "# #", "###", "# #", "###" }, 
        new string[] { "###", "# #", "###", "  #", "###" }  
        };
        static void DrawDigit(int digit)
        {
            string[] rows = DigitPatterns[digit];
            foreach (string row in rows)
            {
                Console.WriteLine(row);
            }
        }
        static void ShowRedError(string errorMessage)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor originalForeground = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear(); 
            Console.WriteLine("\n" + errorMessage);
            Console.WriteLine("Консоль восстановится через 3 секунды...");
            Thread.Sleep(3000);
            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;
            Console.Clear();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 5.1");
            int[] numbers = new int[20];
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
            }

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine();
            Console.Write("Введите первое число из массива(по умолчанию 0): ");
            bool isfirstNumber = int.TryParse(Console.ReadLine(), out int firstNumber);
            Console.Write("Введите второе число из массива: ");
            bool issecondNumber = int.TryParse(Console.ReadLine(), out int secondNumber);

            bool success = SwapElements(numbers, firstNumber, secondNumber);
            if (success)
            {
                Console.WriteLine("Получившийся массив:");
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("Ошибка: Одно или оба числа не найдены в массиве!");
            }
            Console.ReadKey();

            Console.WriteLine("Задание 5.2\nВведите размер массива(по умолчанию 0): ");
            bool issize = int.TryParse(Console.ReadLine(), out int size);
            int[] userArray = new int[size];

            for (int i = 0; i < userArray.Length; i++)
            {
                Console.Write($"Введите элемент [{i}]: ");
                userArray[i] = int.Parse(Console.ReadLine());
            }
            long product = 1;
            double average;
            long sum = CalculateArrayStats(out average, ref product, userArray);
            Console.WriteLine($"Сумма элементов: {sum}\nПроизведение элементов: {product}\nСреднее арифметическое: {average:F2}");
            Console.ReadKey();

            Console.WriteLine("Задание 5.3");
            while (true)
            {
                Console.Write("Введите ввод (число, exit или закрыть): ");
                string input = Console.ReadLine()?.Trim();
                string lowerInput = input.ToLower();

                if (lowerInput == "exit" || lowerInput == "закрыть")
                {
                    break;
                }

                if (!int.TryParse(input, out int number))
                {
                    throw new FormatException("Критическая ошибка: введённое значение не является целым числом!");
                }

                if (number >= 0 && number <= 9)
                {
                    Console.WriteLine($"\nРисунок цифры {number}:");
                    DrawDigit(number);
                    Console.WriteLine();
                }

                else
                {
                    ShowRedError($"Ошибка: Число {number} вне диапазона от 0 до 9!");
                }

            }
            Console.ReadKey();

            Console.WriteLine("Задание 5.4");
            Grandpa[] grandpas = new Grandpa[5];
            grandpas[0] = new Grandpa("Иваныч", GrumpinessLevel.Низкий, new string[]
                { "Эх, молодежь...", "Раньше было лучше!" }); 
            grandpas[1] = new Grandpa("Петрович", GrumpinessLevel.Средний, new string[]
                { "Цены опять выросли!", "Проститутки у подъезда!", "Гады разворовали страну!" }); 
            grandpas[2] = new Grandpa("Михалыч", GrumpinessLevel.Высокий, new string[]
                { "Понаехали тут!", "Телевизор один бред кажет!", "Гребаная погода!" }); 

            grandpas[3] = new Grandpa("Савельич", GrumpinessLevel.Экстремальный, new string[]
                { "Капиталисты проклятые!", "Ворюги кругом!", "Хватит шуметь!", "Тьфу на вас!", "Дерьмо ходячее!" }); 

            grandpas[4] = new Grandpa("Никитич", GrumpinessLevel.Высокий, new string[]
                { "Что за мода пошла?", "Тьфу!" }); 
            string[] swearList = { "проститутки", "гады", "гребаная", "дерьмо" };
            Grandpa referee = grandpas[0];
            for (int i = 0; i < grandpas.Length; i++)
            {
                int earnedBruises = referee.CheckSwearWords(grandpas[i], swearList);
                grandpas[i].BruisesCount += earnedBruises;
                Console.WriteLine($"Дед: {grandpas[i].Name}\nУровень ворчливости: {grandpas[i].Grumpiness}\nКоличество фраз: {grandpas[i].GrumblePhrases.Length}\nПолучено фингалов от бабки за маты: {earnedBruises}\nВсего синяков теперь: {grandpas[i].BruisesCount}");
                Console.WriteLine(new string('-', 35));
            }

            Console.ReadKey();
        }
    }
}


        
    

        

    
    

