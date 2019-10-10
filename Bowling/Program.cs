using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    //har fått problem med att koppla ruta till spaleren
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var game = new Game();
            List<int> result = new List<int>();

            game.Roll(3);

            int Player = rnd.Next(0, 11);
            int Player2 = rnd.Next(0, 11);

            int game1 = game.Roll(Player);
            int game2 = game.Roll(Player2);

            bool stay = true;
            while (stay)
            {
                Console.WriteLine("  1  ,  2  ,  3  ,  4  ,  5  ,  6  ,  7  ,  8  ,  9  ,  10   \n----------------");

                if (game1 == 10)
                {
                    Console.WriteLine("X");

                    stay = false;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        game.Roll(game1);
                    }
                    result.Add(game1);

                    Console.WriteLine(game1 + " | " + game2 + "\n----------------");
                }
                Console.WriteLine("  " + game.Score() + "  ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //public void RollMany(int rolls, int pins)
        //{
        //    for (int i = 0; i < rolls; i++)
        //    {
        //        game.Roll(pins);
        //    }
        //}
    }
}
