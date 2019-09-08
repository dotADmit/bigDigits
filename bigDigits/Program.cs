using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число(можно гигантское): ");
            string number = Console.ReadLine();

            int multiplier = -1;

            do
            {
                Console.Write("Введите множитель(от 0 до 9): ");
                multiplier = Convert.ToInt32(Console.ReadLine());
            } while (multiplier < 0 || multiplier > 9);

            int[] digitsArray = convertToIntArr(number);

            string result = multiplication(digitsArray, multiplier);

            string line = new string('-', result.Length + 13);

            Console.WriteLine($"{line}\n Результат: {result} \n{line}");

            Console.ReadLine();
        }
        static int[] convertToIntArr(string number)
        {
            int[] digitsArray = new int[number.Length];
            for (int i = 0; i < digitsArray.Length; i++)
            {
                digitsArray[i] = Convert.ToInt32(Convert.ToString(number[i]));
            }
            return digitsArray;
        }
        static string multiplication(int[] digits, int multiplier)
        {
            if (multiplier == 0)
            {
                return "0";
            }

            string result = "";
            int tens = 0;

            for (int i = digits.Length - 1; i > -1; i--)
            {
                int temp = digits[i] * multiplier;
                string sDigit = Convert.ToString((temp + tens) % 10);
                result = result.Insert(0, sDigit);
                tens = (temp + tens) / 10;
            }

            if (tens != 0)
            {
                result = result.Insert(0, Convert.ToString(tens));
            }

            return result;
        }
    }
}
