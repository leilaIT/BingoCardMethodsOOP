using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardMethodsOOP
{
    internal class Program
    {
        static int[,] bCard = new int[5, 5];
        static void Main(string[] args)
        {
            while(true)
            {
                generateCard();
                displayCard();
                regenerateCard();
            }

           
            Console.ReadKey();
        }
        static void generateCard ()
        {
            List<int> listNum = new List<int>();
            Random rnd = new Random();
            int num = 0;

            for (int x = 0; x < bCard.GetLength(0); x++)
            {   
                listNum.Clear();
                listNum = possibleValues(listNum);

                for (int y = 0; y < bCard.GetLength(1); y++)
                {
                    num = rnd.Next(0, listNum.Count);
                    bCard[y, x] = listNum[num];
                    listNum.RemoveAt(num);
                }
            }
        }
        static List<int> possibleValues (List<int> listNum)
        {
            for (int c = 1; c < 16; c++)
            {
                listNum.Add(c);
            }
            return listNum;
        }
        static void displayCard ()
        {
            string disp = "";
            int dispCount = 0;

            Console.WriteLine(" B\t I\t N\t G\t O");
            for (int x = 0; x < bCard.GetLength(0); x++)
            {
                for (int y = 0; y < bCard.GetLength(1); y++)
                {
                    bCard[x, y] += (15 * y);
                    disp = bCard[x, y].ToString();
                    dispCount = disp.Length;
                    while (dispCount != 3)
                    {
                        Console.Write("0");
                        dispCount++;
                    }
                    Console.Write(bCard[x, y] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void regenerateCard ()
        {
            string answer = "";
            
            Console.WriteLine("Would you like to regenerate the card? [Y/N]");
            answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                for (int x = 0; x < bCard.GetLength(0); x++)
                {
                    for (int y = 0; y < bCard.GetLength(1); y++)
                    {
                        bCard[x, y] = 0;
                    }
                }
            }
            else
            {
                break;
            }
        }
    }
}
