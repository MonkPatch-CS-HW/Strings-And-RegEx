using System.Text;
using Microsoft.VisualBasic;

namespace Task2
{
    public class Task2
    {

/*
 * В этих заданиях * рекомендуется всюду использовать класс StringBuilder.
 * Документация: https://docs.microsoft.com/ru-ru/dotnet/api/system.text.stringbuilder?view=net-6.0
 */

/*
 * Задание 2.1. Дана непустая строка S и целое число N (> 0). Вернуть строку, содержащую символы
 * строки S, между которыми вставлено по N символов «*» (звездочка).
 */
        internal static string FillWithAsterisks(string s, int n)
        {
            var sb = new StringBuilder(s[0].ToString());
            var part = new string('*', n);
            for (var i = 1; i < s.Length; i++)
            {
                sb.Append(part);
                sb.Append(s[i]);
            }

            return sb.ToString();
        }

/*
 * Задание 2.2. Сформировать таблицу квадратов чисел от 1 до заданного числа N.
 * Например, для N=4 должна получиться следующая строка:

1  1
2  4
3  9
4 16

 * Обратите внимание на выравнивание: числа в первом столбце выравниваются по левому краю,
 * а числа во втором -- по правому, причём между числами должен оставаться как минимум один
 * пробел. В решении можно использовать функции Pad*.
 */
        internal static string TabulateSquares(int n)
        {
            var lineLen = n.ToString().Length + 1 + (n * n).ToString().Length;
            var sb = new StringBuilder();
            for (var i = 1; i <= n; i++)
            {
                sb.Append(i.ToString() + (i * i).ToString().PadLeft(lineLen - i.ToString().Length) + "\n");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(FillWithAsterisks("abc", 2));
            Console.WriteLine(TabulateSquares(4));
        }
    }
}