using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardMethodsOOP
{
    internal class Program
    {
        static int[,] _bCard = new int[,] { };
        static void Main(string[] args)
        {
            while(true)
            {
                initializeCard();
                generateCard();
                displayCard();

                if (!regenerateCard())
                    break;
            }

            Console.ReadKey();
        }
        static void initializeCard()
        {
            _bCard = new int[5, 5];
        }
        static void generateCard ()
        {
            List<int> listNum = new List<int>();
            Random rnd = new Random();
            int num = 0;

            for (int x = 0; x < _bCard.GetLength(0); x++)
            {   
                listNum.Clear();
                for (int c = 1; c < 16; c++)
                {
                    listNum.Add(c);
                }

                for (int y = 0; y < _bCard.GetLength(1); y++)
                {
                    num = rnd.Next(0, listNum.Count);
                    _bCard[y, x] = listNum[num];
                    listNum.RemoveAt(num);
                }
            }
            _bCard[2, 2] = -1;
        }
        static void displayCard ()
        {
            string disp = "";
            int dispCount = 0;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("    B\t    I\t    N\t    G\t    O");
            Console.ResetColor();

            for (int x = 0; x < _bCard.GetLength(0); x++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("|  ");
                Console.ResetColor();

                for (int y = 0; y < _bCard.GetLength(1); y++)
                {
                    _bCard[x, y] += (15 * y);
                    disp = _bCard[x, y].ToString();
                    dispCount = disp.Length;

                    if (_bCard[x, y] == _bCard[2, 2])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("FRE");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  |  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        while (dispCount != 3)
                        {
                            Console.Write("0");
                            dispCount++;
                        }
                        Console.Write(_bCard[x, y]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  |  ");
                        Console.ResetColor();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n-----------------------------------------");
                Console.ResetColor();
            }
        }
        static bool regenerateCard ()
        {
            string answer = "";
            bool ans = true;
            
            while (true)
            {
                Console.WriteLine("Would you like to regenerate the card? [Y/N]");
                answer = Console.ReadLine().ToUpper();
                if (answer == "N")
                {
                    ans = false;
                    break;
                }
                else if (answer == "Y")
                {
                    break;
                }
                else
                    Console.WriteLine("Invalid Input.");
            }
            return ans;
        }
    }
}
