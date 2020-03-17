using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Проект_Морской_бой
{
    class Program
    {
        static string vitalka(int y)
        {
            string s = "";
            switch(y)
            {
                case 1: s = "A"; break;
                case 2: s = "B"; break;
                case 3: s = "C"; break;
                case 4: s = "D"; break;
                case 5: s = "E"; break;
                case 6: s = "F"; break;
                case 7: s = "G"; break;
                case 8: s = "H"; break;
                case 9: s = "I"; break;
                case 10: s = "J"; break;
            }
            return s;
        }
        static void superSwithFun(int[,] PLfield, int[,] COMPsNew, int x, int y, ref int xC, ref int yC)
        {
            int k = 0;
            switch (PLfield[x, y])
            {
                case 0: { COMPsNew[x, y] = 2; break; }
                case 1:
                    {
                        COMPsNew[x, y] = 3;
                        xC = x; yC = y;
                        PLfield[x, y] = 3; if (Checker(PLfield, x, y, ref k)) { Checker(COMPsNew, x, y, ref k); xC = -1; yC = -1; } break;
                    }
            }
            switch (k)
            {
                case 1: { string[] s = {Convert.ToString(x - 2), vitalka(y)} ; PTerm(PLfield, COMPsNew, s); break; }
                case 2: { string[] s = {Convert.ToString(x + 2), vitalka(y)} ; PTerm(PLfield, COMPsNew, s); break; }
                case 3: { string[] s = {Convert.ToString(x), vitalka(y + 2)} ; PTerm(PLfield, COMPsNew, s); break; }
                case 4: { string[] s = {Convert.ToString(x), vitalka(y - 2)} ; PTerm(PLfield, COMPsNew, s); break; }
            }
        }
        static void CTerm(int[,] COMPsNew, int[,] PLfield, ref int xC, ref int yC)
        {
            int x, y;
            if(xC == -1 && yC == -1)
            {
                x = new Random().Next(1, 10);
                y = new Random().Next(1, 10);
                while(COMPsNew[x, y] != 0) { x = new Random().Next(1, 10); y = new Random().Next(1, 10); }
                superSwithFun(PLfield, COMPsNew, x, y, ref xC, ref yC);
            }///*
            else
            {
                if (COMPsNew[xC, yC + 1] != 2 && COMPsNew[xC, yC + 1] != 3) superSwithFun(PLfield, COMPsNew, xC, yC + 1, ref xC, ref yC);
                else
                {
                    if (COMPsNew[xC, yC - 1] != 2 && COMPsNew[xC, yC - 1] != 3) superSwithFun(PLfield, COMPsNew, xC, yC - 1, ref xC, ref yC);
                    else
                    {
                        if (COMPsNew[xC + 1, yC] != 2 && COMPsNew[xC + 1, yC] != 3) superSwithFun(PLfield, COMPsNew, xC + 1, yC, ref xC, ref yC);
                        else if (COMPsNew[xC - 1, yC] != 2 && COMPsNew[xC - 1, yC] != 3) superSwithFun(PLfield, COMPsNew, xC - 1, yC, ref xC, ref yC);
                    }
                }
            }//*/
        }
        static bool Checker(int[,] field, int i, int j, ref int k)
        {
            if ((field[i + 1, j] != 1 && field[i + 1, j] != 3) && (field[i + 1, j - 1] != 1 && field[i + 1, j - 1] != 1) && (field[i + 1, j + 1] != 1 && field[i + 1, j + 1] != 3) &&
                    (field[i, j - 1] != 1 && field[i, j - 1] != 3) && (field[i, j + 1] != 1 && field[i, j + 1] != 1) && (field[i - 1, j] != 1 && field[i - 1, j] != 3) &&
                    (field[i - 1, j - 1] != 1 && field[i - 1, j - 1] != 3) && (field[i - 1, j + 1] != 1 && field[i - 1, j + 1] != 3))
                {
                if (field[i + 1, j] == 3 || field[i + 1, j - 1] == 3 || field[i + 1, j + 1] == 1 ||
                    field[i, j - 1] == 3 || field[i, j + 1] == 3 || field[i - 1, j] == 3 ||
                    field[i - 1, j - 1] == 3 || field[i - 1, j + 1] == 3)
                {
                    //if (i <= 8 && field[i + 2, j] != 2 && field[i + 1, j] == 3) { k = 1; return false; }
                    //if (i >= 2 && field[i - 2, j] != 2 && field[i - 1, j] == 3) { k = 2; return false; }
                    //if (j >= 8 && field[i, j + 2] != 2 && field[i, j + 1] == 3) { k = 3; return false; }
                    //if (j <= 2 && field[i, j + 1] != 2 && field[i, j - 1] == 3) { k = 4; return false; }
                }
                if(true)
                {
                    for (int x = 0; x < field.GetLength(0); x++)
                    {
                        for (int y = 0; y < field.GetLength(1); y++)
                        {
                            if (field[x, y] == 3)
                            {
                                field[x, y] = 4;
                                if (field[x + 1, y + 1] == 0) field[x + 1, y + 1] = 2;
                                if (field[x + 1, y] == 0) field[x + 1, y] = 2;
                                if (field[x, y + 1] == 0) field[x, y + 1] = 2;
                                if (field[x - 1, y + 1] == 0) field[x - 1, y + 1] = 2;
                                if (field[x - 1, y] == 0) field[x - 1, y] = 2;
                                if (field[x + 1, y - 1] == 0) field[x + 1, y - 1] = 2;
                                if (field[x, y - 1] == 0) field[x, y - 1] = 2;
                                if (field[x - 1, y - 1] == 0) field[x - 1, y - 1] = 2;
                            }
                        }
                    }
                }
                return true;
                }
            return false;
        }
        static void PTerm(int[,] COMP, int[,] PLAYER, string[] s)
        {
            int k = 0;
            int x, y;
            while((s.Length != 2 || (s[0].Length != 1 || (Convert.ToChar(s[0]) < 'A' && Convert.ToChar(s[0]) > 'J' && Convert.ToInt32(s[1]) < 1 && Convert.ToInt32(s[1]) > 10)) &&
                                    (s[1].Length != 1 || (Convert.ToChar(s[1]) < 'A' && Convert.ToChar(s[1]) > 'J' && Convert.ToInt32(s[0]) < 1 && Convert.ToInt32(s[0]) > 10))))
                { s = Console.ReadLine().ToUpper().Split(); }
            if (s[0].Length == 1 && Convert.ToChar(s[0]) >= 'A' && Convert.ToChar(s[0]) <= 'J') { x = Convert.ToInt32(s[1]); y = Convert.ToChar(s[0]) - 'A' + 1; }
            else { x = Convert.ToInt32(s[0]); y = Convert.ToChar(s[1]) - 'A' + 1; }
            switch (COMP[x, y])
            {
                case 0:{ PLAYER[x, y] = 2; break; }
                case 1:{ PLAYER[x, y] = 3;
                         COMP[x, y] = 3; if (Checker(COMP, x, y, ref k)) Checker(PLAYER, x, y, ref k); break;}
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
        static int[,] PLAYFieldChooser()
        {
            string s = Console.ReadLine();
            while (s != "1" && s != "2" && s != "3")
            {
                Console.Write("Ошибка: введенное число должно быть равно 1, 2 или 3. Повторите ввод : ");
                s = Console.ReadLine();
            }
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
            for(int i = 1; i < field.GetLength(0) - 1; i++)
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
            Console.ForegroundColor = ConsoleColor.Green;
            int xC = -1, yC = -1;
            Console.Write("Выберите расстановку кораблей (от 1 до 3) : ");
            int[,] PLfield = PLAYFieldChooser(), COMP = COMPFieldChooser(), PLAYER = new int[12, 12], COMPsNew = new int[12, 12];
            Console.WriteLine("Ваша расстановка : ");
            fieldoutput(PLfield);
            while(true)
            {
                //Console.WriteLine("Ваш ход, введите клетку для атаки ");
                //fieldoutput(PLAYER);
                //string[] s = Console.ReadLine().ToUpper().Split();
                //PTerm(COMP, PLAYER, s);
                //Console.WriteLine("Результат атаки : ");
                fieldoutput(PLAYER);
                Console.WriteLine("Результат действий противника : ");
                CTerm(COMPsNew, PLfield, ref xC, ref yC);
                fieldoutput(COMPsNew);
                fieldoutput(PLfield);
                Console.ReadKey();
            }
        }
    }
}
