using System.Text.RegularExpressions;

namespace Task1
{
    public class Task1
    {
/*
 * Задание 1.1. Дана строка. Верните строку, содержащую текст "Длина: NN",
 * где NN — длина заданной строки. Например, если задана строка "hello",
 * то результатом должна быть строка "Длина: 5".
 */
        internal static int StringLength(string s)
        {
            return s.Length;
        }

/*
 * Задание 1.2. Дана непустая строка. Вернуть коды ее первого и последнего символов.
 * Рекомендуется найти специальные функции для вычисления соответствующих символов и их кодов.
 */
        internal static Tuple<int?, int?> FirstLastCodes(string s)
        {
            return new Tuple<int?, int?>(Code(First(s)), Code(Last(s)));
        }
        
        private static char? First(string s) => s[0];
        private static char? Last(string s) => s[s.Length - 1];
        private static int? Code(char? c) => c != null ? (int)c : 0;
       

/*
 * Задание 1.3. Дана строка. Подсчитать количество содержащихся в ней цифр.
 * В решении необходимо воспользоваться циклом for.
 */
        internal static int CountDigits(string s)
        {
            var count = 0;
            foreach (var c in s)
            {
                if ('0' <= c && c <= '9')
                    count += 1;
            }

            return count;
        }

/*
 * Задание 1.4. Дана строка. Подсчитать количество содержащихся в ней цифр.
 * В решении необходимо воспользоваться методом Count:
 * https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.count?view=net-6.0#system-linq-enumerable-count-1(system-collections-generic-ienumerable((-0))-system-func((-0-system-boolean)))
 * и функцией Char.IsDigit:
 * https://docs.microsoft.com/ru-ru/dotnet/api/system.char.isdigit?view=net-6.0
 */
        internal static int CountDigits2(string s)
        {
            return s.Count(char.IsDigit);
        }
        
/*
 * Задание 1.5. Дана строка, изображающая арифметическое выражение вида «<цифра>±<цифра>±…±<цифра>»,
 * где на месте знака операции «±» находится символ «+» или «−» (например, «4+7−2−8»). Вывести значение
 * данного выражения (целое число).
 */
        internal static int CalcDigits(string expr)
        {
            expr = "+" + expr;
            var sum = 0;
            var parts = Regex.Matches(expr, "[+-]\\d");
            foreach (Match match in parts)
            {
                string str = match.ToString();
                var mul = str[0] == '+' ? 1 : -1;
                sum += (str[1] - '0') * mul;
            }

            return sum;
        }

/*
 * Задание 1.6. Даны строки S, S1 и S2. Заменить в строке S первое вхождение строки S1 на строку S2.
 */
        internal static string ReplaceWithString(string s, string s1, string s2)
        {
            var index = s.IndexOf(s1);
            return s.Substring(0, index) + s2 + s.Substring(index + s1.Length);
        }
        

        public static void Main(string[] args)
        {
            StringLength("12345");
            CalcDigits("5+7-1-2+3");
            FirstLastCodes("asdf");
            CountDigits("1o23h4k");
            CountDigits2("1o23h4k");
            ReplaceWithString("qwepoiqw", "qw", "xxx");
        }
    }
}