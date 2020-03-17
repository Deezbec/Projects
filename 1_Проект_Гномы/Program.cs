using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Проект_Гномы
{
    class Program
    {
        static void ToTwo(int a, int p)
        {
            int b = 1;
            for (int i = 0; i <= (p - 1); i++)
            {
                if (((b << i) & a) == (b << i))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("1");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("0");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        static sbyte Input()
        {
            Console.WriteLine("Введите количество гномов <16 или 32>");
            sbyte num = Convert.ToSByte(Console.ReadLine());
            while (num != 16 && num != 32)
            {
                Console.WriteLine("Ошибка: введенное число должно быть равно 16 или 32. Повторите ввод:");
                num = Convert.ToSByte(Console.ReadLine());
            }
            return num;
        }
        static int Kolone(int x, int p)
        {
            int t = 0, l = 1;
            for (int i = 0; i <= (p - 1); i++)
                if (((l << i) & x) == (l << i)) t++;
            return t;
        }
        static int Ghat(int count, int c, int i)
        {
            Console.WriteLine($"{i}-й гном сказал: \"Я в зеленой шапке.\" ");
            if (((1 << (i - 1)) & count) != (1 << (i - 1)))
                Console.WriteLine($"{i}-й гном угадал и получил монету. Общий счет гномов {++c}");
            else Console.WriteLine($"{i}-й гном ошибся и не получил ни одной монеты. Общий счет гномов {c}");
            return c;
        }
        static int Rhat(int count, int c, int i)
        {
            Console.WriteLine($"{i}-й гном сказал: \"Я в красной шапке.\" ");
            if (((1 << (i - 1)) & count) == (1 << (i - 1)))
                Console.WriteLine($"{i}-й гном угадал и получил монету. Общий счет гномов {++c}");
            else Console.WriteLine($"{i}-й гном ошибся и не получил ни одной монеты. Общий счет гномов {c}");
            return c;
        }
        static void Nfirst(int num, int count)
        {
            int s = int.MaxValue << 1, c = 0;
            bool r = false;
            if ((Kolone((s & count), num) & 1) == 0)
            {
                c = Ghat(count, c, 1);
                r = true;
            }
            else c = Rhat(count, c, 1);
            s <<= 1;
            for (int i = 2; i <= num; i++)
            {
                bool h = (Kolone((s & count), num) & 1) == 0;
                if (r == h) c = Ghat(count, c, i);
                else c = Rhat(count, c, i);
                r = h;
                s <<= 1;
            }
        }
        static void Main(string[] args)
        {
            sbyte num = Input();
            Console.WriteLine("Введите число, двоичный код которого представляет гномов:");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Гномы: ");
            ToTwo(count, num);
            Nfirst(num, count);
            Console.ReadKey();
        }
    }
}
