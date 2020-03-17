using System;

namespace Морской_бой_NEW
{
    class Checking
    {
        public static bool CheckingMain(int[,] field, int x, int y)
        {
            if (Checker(field, x, y, 0, 0))
            {
                FinderForPainter(field, x, y, 0, 0);
                return true;
            }
            return false;
        }
        static bool FinderForPainter(int[,] field, int x, int y, int x1, int y1)
        {
            bool f = false;
            //Покраска
            //field[x, y] = 4;
            if (field[x + 1, y + 1] == 0) field[x + 1, y + 1] = 2;
            if (field[x + 1, y] == 0) field[x + 1, y] = 2;
            if (field[x, y + 1] == 0) field[x, y + 1] = 2;
            if (field[x - 1, y + 1] == 0) field[x - 1, y + 1] = 2;
            if (field[x - 1, y] == 0) field[x - 1, y] = 2;
            if (field[x + 1, y - 1] == 0) field[x + 1, y - 1] = 2;
            if (field[x, y - 1] == 0) field[x, y - 1] = 2;
            if (field[x - 1, y - 1] == 0) field[x - 1, y - 1] = 2;
            //Конец покраски
            if ((field[x + 1, y] == 3) && x + 1 != x1) if (FinderForPainter(field, x + 1, y, x, y)) f = true; else f = false;
            if ((field[x - 1, y] == 3) && x - 1 != x1) if (FinderForPainter(field, x - 1, y, x, y)) f = true; else f = false;
            if ((field[x, y + 1] == 3) && y + 1 != y1) if (FinderForPainter(field, x, y + 1, x, y)) f = true; else f = false;
            if ((field[x, y - 1] == 3) && y - 1 != y1) if (FinderForPainter(field, x, y - 1, x, y)) f = true; else f = false;
            return f;
        }
        static bool Checker(int[,] field, int x, int y, int x1, int y1)
        {
            bool f = false;
            if ((field[x + 1, y] == 0 || field[x + 1, y] == 2) && (field[x, y + 1] == 0 || field[x, y + 1] == 2) &&
                (field[x - 1, y] == 0 || field[x - 1, y] == 2) && (field[x, y - 1] == 0 || field[x, y - 1] == 2)) return true;
            else
            {
                if (field[x + 1, y] == 1 || field[x - 1, y] == 1 || field[x, y + 1] == 1 || field[x, y - 1] == 1) return false;
                if (field[x + 1, y] == 0 || field[x, y + 1] == 0 || field[x - 1, y] == 0 || field[x, y - 1] == 0) f = true;
                if ((field[x + 1, y] == 3) && x + 1 != x1) if (Checker(field, x + 1, y, x, y)) f = true; else f = false;
                if ((field[x - 1, y] == 3) && x - 1 != x1) if (Checker(field, x - 1, y, x, y)) f = true; else f = false;
                if ((field[x, y + 1] == 3) && y + 1 != y1) if (Checker(field, x, y + 1, x, y)) f = true; else f = false;
                if ((field[x, y - 1] == 3) && y - 1 != y1) if (Checker(field, x, y - 1, x, y)) f = true; else f = false;
                return f;
            }
        }

    }
    class Program
    {
        static void CTerm(int[,] PLfield, int[,] COMPsNew, ref int x1, ref int y1)
        {
            int x = 0, y = 0;
            if(x1 == 0 & y1 == 0)
            {
                x = new Random().Next(1, 11); y = new Random().Next(1, 11);
                System.Threading.Thread.Sleep(10);
                while (COMPsNew[x, y] != 0) { x = new Random().Next(1, 10); y = new Random().Next(1, 10); System.Threading.Thread.Sleep(10); }
            }
            else
            {
                if ((COMPsNew[x1 + 1, y1] == 0 || COMPsNew[x1 + 1, y1] == 2) && (COMPsNew[x1 - 1, y1] == 0 || COMPsNew[x1 - 1, y1] == 2) && 
                    (COMPsNew[x1, y1 + 1] == 0 || COMPsNew[x1, y1 + 1] == 2) && (COMPsNew[x1, y1 - 1] == 0 || COMPsNew[x1, y1 - 1] == 2))
                {
                    if (COMPsNew[x1 + 1, y1] == 0) { x = x1 + 1; y = y1; }
                    if (COMPsNew[x1 - 1, y1] == 0) { x = x1 - 1; y = y1; }
                    if (COMPsNew[x1, y1 + 1] == 0) { x = x1; y = y1 + 1; }
                    if (COMPsNew[x1, y1 - 1] == 0) { x = x1; y = y1 - 1; }
                }
                if (COMPsNew[x1 + 1, y1] == 3)
                {
                    if (COMPsNew[x1 - 1, y1] == 0) { x = x1 - 1; y = y1; }
                    if (x1 + 2 < COMPsNew.GetLength(0) && COMPsNew[x1 + 2, y1] == 0) { x = x1 + 2; y = y1; }
                    if (x1 + 3 < COMPsNew.GetLength(0) && COMPsNew[x1 + 3, y1] == 0 && COMPsNew[x1 + 2, y1] == 3) { x = x1 + 3; y = y1; }
                }
                if (COMPsNew[x1 - 1, y1] == 3)
                {
                    if (COMPsNew[x1 + 1, y1] == 0) { x = x1 + 1; y = y1; }
                    if (x1 - 2 > 0 && COMPsNew[x1 - 2, y1] == 0) { x = x1 - 2; y = y1; }
                    if (x1 - 3 > 0 && COMPsNew[x1 - 3, y1] == 0 && COMPsNew[x1 - 2, y1] == 3) { x = x1 - 3; y = y1; }
                }
                if (COMPsNew[x1, y1 + 1] == 3)
                {
                    if (COMPsNew[x1, y1 - 1] == 0) { x = x1; y = y1 - 1; }
                    if (y1 + 2 < COMPsNew.GetLength(1) && COMPsNew[x1, y1 + 2] == 0) { x = x1; y = y1 + 2; }
                    if (y1 + 3 < COMPsNew.GetLength(1) && COMPsNew[x1, y1 + 3] == 0 && COMPsNew[x1, y1 + 2] == 3) { x = x1; y = y1 + 3; }
                }
                if (COMPsNew[x1, y1 - 1] == 3)
                {
                    if (COMPsNew[x1, y1 + 1] == 0) { x = x1; y = y1 + 1; }
                    if (y1 - 2 > 0 && COMPsNew[x1, y1 - 2] == 0) { x = x1; y = y1 - 2; }
                    if (y1 - 3 > 0 && COMPsNew[x1, y1 - 3] == 0 && COMPsNew[x1, y1 - 2] == 3) { x = x1; y = y1 - 3; }
                }
                if (x == 0 || y == 0)
                {
                    x = new Random().Next(1, 10); y = new Random().Next(1, 10);
                    System.Threading.Thread.Sleep(10);
                    while (COMPsNew[x, y] != 0) { x = new Random().Next(1, 10); y = new Random().Next(1, 10); System.Threading.Thread.Sleep(10); }
                }
            }
            switch (PLfield[x, y])
            {
                case 0: { COMPsNew[x, y] = 2; break; }
                case 1:
                    {
                        x1 = x; y1 = y;
                        COMPsNew[x, y] = 3;
                        PLfield[x, y] = 3; if (Checking.CheckingMain(PLfield, x, y)) { Checking.CheckingMain(COMPsNew, x, y); x1 = 0; y1 = 0; } break;
                    }
            }
        }
        static void PTerm(int[,] COMP, int[,] PLAYER, string s)
        {
            int x, y;
            while (s.Length <= 1 || s.Contains(' ') || (s[0] < 'A' || s[0] > 'J') || s.Length > 3 || (s.Length == 3 && (s[1] != '1' || s[2] != '0')) || (s[1] < '1' || s[1] > '9'))
            { s = Console.ReadLine().ToUpper(); }
            y = Convert.ToInt32(s[0] - 'A' + 1);
            if (s.Length == 3) x = 10; else x = Convert.ToInt32(s[1] - '1' + 1);
            switch (COMP[x, y])
            {
                case 0: { PLAYER[x, y] = 2; break; }
                case 1:
                    {
                        PLAYER[x, y] = 3;
                        COMP[x, y] = 3; if (Checking.CheckingMain(COMP, x, y)) Checking.CheckingMain(PLAYER, x, y); break;
                    }
            }
        }
        static int[,] COMPFieldChooser()
        {
            int a = new Random().Next(1, 3);
            switch (a)
            {
                case 1:
                    {
                        int[,] field = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0},
                                         {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
                        return field;
                    }
                case 2:
                    {
                        int[,] field = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
                                         {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                         {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                         {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
                                         {0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0},
                                         {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
                        return field;
                    }
                default:
                    {
                        int[,] field = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                                         {0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0},
                                         {0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
                        return field;
                    }
            }
        }
        static int[,] PLAYFieldChooser(string s)
        {
            switch (s)
            {
                case "1":
                    {
                        int[,] field = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0},
                                         {0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
                        return field;
                    }
                case "2":
                    {
                        int[,] field = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
                                         {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
                        return field;
                    }
                default:
                    {
                        int[,] field = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
                                         {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0},
                                         {0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
                        return field;
                    }
            }
        }
        static void fieldoutput(int[,] field)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("      A B C D E F G H I J");
            Console.WriteLine("   ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            for (int i = 1; i < field.GetLength(0) - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{i:D2} ▓▓");
                for (int j = 1; j < field.GetLength(1) - 1; j++)
                {
                    switch (field[i, j])
                    {
                        case 0:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("▓▓");
                                break;
                            }
                        case 1:
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("▓▓");
                                break;
                            }
                        case 2:
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("▓▓");
                                break;
                            }
                        case 3:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▓▓");
                                break;
                            }
                        case 4:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("▓▓");
                                break;
                            }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("▓▓");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        }
        static void Main(string[] args)
        {
            int x1 = 0, y1 = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Выберите расстановку кораблей (от 1 до 3) : ");
            string s = Console.ReadLine();
            while (s != "1" && s != "2" && s != "3")
            {
                Console.Write("Ошибка: введенное число должно быть равно 1, 2 или 3. Повторите ввод : ");
                s = Console.ReadLine();
            }
            int[,] PLfield = PLAYFieldChooser(s), COMP = COMPFieldChooser(), PLAYER = new int[12, 12], COMPsNew = new int[12, 12];
            Console.Clear();
            Console.WriteLine("Ваша расстановка : ");
            fieldoutput(PLfield);
            while (true)
            {
                //Console.WriteLine("Ваш ход, введите клетку для атаки");
                fieldoutput(PLAYER);
                //s = Console.ReadLine().ToUpper();
                //PTerm(COMP, PLAYER, s);
                Console.Clear();
                CTerm(PLfield, COMPsNew, ref x1, ref y1);
                Console.WriteLine("Результат действий противника : ");
                //fieldoutput(PLfield);
                fieldoutput(COMPsNew);
                Console.ReadKey();
            }
        }
    }
}
