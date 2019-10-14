using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    //har fått problem med att koppla ruta till spaleren
    public class Program
    {
        public Game game;
        //
        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            List<int> result2 = new List<int>();
            Random rnd = new Random();
            Game game = new Game();
            //kunde inte spara två olika resultater 
            //hittade lösning, skappat andra object
            Game game2 = new Game();


            //båda spelare kan tävla mot varandra
            #region test
            int count = 1;
            bool stay = true;
            while (stay)
            {
                try
                {
                    Console.WriteLine("Input pin from 0 to 10: ");
                    Console.WriteLine("  1  ,  2  ,  3  ,  4  ,  5  ,  6  ,  7  ,  8  ,  9  ,  10   \n----------------");

                    for (int i = 0; i < 10; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Spelaren " + count);
                        Console.ResetColor();

                        int Player1 = Convert.ToInt32(Console.ReadLine());
                        int slag1 = game.Roll(Player1);

                        if (slag1 >= 0 && slag1 < 10)
                        {
                            int Player2 = Convert.ToInt32(Console.ReadLine());
                            int slag2 = game.Roll(Player2);
                            int spare = slag1 + slag2;//?

                            if (i == 9)//lösning till 3e slaget
                            {
                                if (spare == 10)
                                {
                                    int Player3 = Convert.ToInt32(Console.ReadLine());
                                    int slag3 = game.Roll(Player3);

                                    Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                                    Console.ResetColor();
                                }
                            }

                            if (spare == 10)
                            {
                                Console.WriteLine("\n   " + slag1 + "|/" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }
                            else if (slag1 == 0 && slag2 == 0)
                            {
                                Console.WriteLine("\n   |-" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine($"\n  {slag1}|{slag2}" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }
                        }
                        else if (slag1 == 10)
                        {
                            if (i == 9)
                            {
                                if (slag1 == 10)
                                {
                                    int Player2 = Convert.ToInt32(Console.ReadLine());
                                    int slag2 = game.Roll(Player2);

                                    int Player3 = Convert.ToInt32(Console.ReadLine());
                                    int slag3 = game.Roll(Player3);

                                    Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                                    Console.ResetColor();


                                }
                            }
                            else
                            {
                                Console.WriteLine("\n   |X" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }

                        }
                        //save results


                        //--------------------------------------------------------------------------------------
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Motståndare " + count);
                        Console.ResetColor();




                        int Versys1 = rnd.Next(0, 10);
                        int slagv1 = game2.Roll(Versys1);


                        if (slagv1 >= 0 && slagv1 < 10)
                        {
                            int Versys2 = rnd.Next(0, 10);
                            int slagv2 = game2.Roll(Versys2);
                            int spare = slagv1 + slagv2;//?

                            if (i == 9)//lösning till 3e slaget
                            {
                                if (spare == 10)
                                {
                                    int Versys3 = rnd.Next(0, 10);
                                    int slagv3 = game2.Roll(Versys3);

                                    Console.WriteLine($"\n  {slagv1}|{slagv2}|{slagv3}" + "\n----------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------");
                                    Console.ResetColor();
                                }
                            }

                            if (spare == 10)
                            {
                                Console.WriteLine("\n " + slagv1 + "|/" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }
                            else if (slagv1 == 0 && slagv2 == 0)
                            {
                                Console.WriteLine("\n   |-" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine($"\n  {slagv1}|{slagv2}" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }
                        }
                        else if (slagv1 == 10)
                        {
                            if (i == 9)
                            {
                                if (slagv1 == 10)
                                {
                                    int Player2 = rnd.Next(0, 10);
                                    int slag2 = game2.Roll(Player2);

                                    int Player3 = rnd.Next(0, 10);
                                    int slag3 = game2.Roll(Player3);

                                    Console.WriteLine($"\n  {slagv1}|{slag2}|{slag3}" + "\n----------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n   |X" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------");
                                Console.ResetColor();
                            }

                        }
                        count++;
                        stay = false;
                    }
                    //int save = game.Score();
                    //result.Add(save);


                    //foreach (var item in result)
                    //{
                    //    Console.WriteLine("Player's result: " + item);
                    //}

                    //int save2 = game2.Score();
                    //result2.Add(save2);


                    //foreach (var item in result2)
                    //{
                    //    Console.WriteLine("Opponent's result: " + item);
                    //}

                    Console.WriteLine("Player's result: " + game.Score());
                    Console.WriteLine("Opponent's result: " + game2.Score());
                    Console.WriteLine("Finish");

                    if (game.Score() > game2.Score())
                    {
                        Console.WriteLine("Player is Won " + game.Score());
                    }
                    else
                    {
                        Console.WriteLine("Opponent is Won " + game2.Score());
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not right number\nPush enter to try again");
                    Console.ResetColor();
                }
                Console.ReadLine();
                Console.Clear();
            }
            #endregion

            #region Game1 = Player
            //int count = 1;
            //bool stay = true;
            //while (stay)//har fått problem med att, mer än 10 visar 
            //{
            //    try
            //    {
            //        Console.WriteLine("Input pin from 0 to 10: ");
            //        Console.WriteLine("  1  ,  2  ,  3  ,  4  ,  5  ,  6  ,  7  ,  8  ,  9  ,  10   \n----------------");

            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.WriteLine("N " + count);
            //            Console.ResetColor();

            //            int Player1 = Convert.ToInt32(Console.ReadLine());
            //            int slag1 = game.Roll(Player1);


            //            if (slag1 >= 0 && slag1 < 10)
            //            {
            //                int Player2 = Convert.ToInt32(Console.ReadLine());
            //                int slag2 = game.Roll(Player2);
            //                int spare = slag1 + slag2;//?

            //                if (i == 9)//lösning till 3e slaget
            //                {
            //                    if (spare == 10)
            //                    {
            //                        int Player3 = Convert.ToInt32(Console.ReadLine());
            //                        int slag3 = game.Roll(Player3);

            //                        Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
            //                        Console.ForegroundColor = ConsoleColor.Green;
            //                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                        Console.ResetColor();
            //                    }
            //                }

            //                if (spare == 10)
            //                {
            //                    Console.WriteLine("\n   " + slag1 + "|/" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //                else if (slag1 == 0 && slag2 == 0)
            //                {
            //                    Console.WriteLine("\n   |-" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //                else
            //                {
            //                    Console.WriteLine($"\n  {slag1}|{slag2}" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //            }
            //            else if (slag1 == 10)
            //            {
            //                if (i == 9)
            //                {
            //                    if (slag1 == 10)
            //                    {
            //                        int Player2 = Convert.ToInt32(Console.ReadLine());
            //                        int slag2 = game.Roll(Player2);

            //                        int Player3 = Convert.ToInt32(Console.ReadLine());
            //                        int slag3 = game.Roll(Player3);

            //                        Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
            //                        Console.ForegroundColor = ConsoleColor.Green;
            //                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                        Console.ResetColor();
            //                    }
            //                }
            //                else
            //                {
            //                    Console.WriteLine("\n   |X" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //            }
            //            count++;
            //        }
            //        int save = game.Score();
            //        result.Add(save);


            //        foreach (var item in result)
            //        {
            //            Console.WriteLine("Player's is result: " + item);
            //        }
            //        Console.WriteLine("Finish");
            //    }
            //    catch (FormatException)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Not right number\nPush enter to try again");
            //        Console.ResetColor();
            //    }
            //    Console.ReadLine();
            //    Console.Clear();
            //}
            #endregion

            #region Game2 = Versys
            //int count = 1;
            //bool stay = true;
            //while (stay)//har fått problem med att, mer än 10 visar 
            //{
            //    try
            //    {
            //        Console.WriteLine("Input pin from 0 to 10: ");
            //        Console.WriteLine("  1  ,  2  ,  3  ,  4  ,  5  ,  6  ,  7  ,  8  ,  9  ,  10   \n----------------");

            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.WriteLine("N " + count);
            //            Console.ResetColor();




            //            int Versys1 = rnd.Next(0, 10);
            //            int slagv1 = game.Roll(Versys1);


            //            if (slagv1 >= 0 && slagv1 < 10)
            //            {
            //                int Versys2 = rnd.Next(0, 10);
            //                int slagv2 = game.Roll(Versys2);
            //                int spare = slagv1 + slagv2;//?

            //                if (i == 9)//lösning till 3e slaget
            //                {
            //                    if (spare == 10)
            //                    {
            //                        int Versys3 = rnd.Next(0, 10);
            //                        int slagv3 = game.Roll(Versys3);

            //                        Console.WriteLine($"\n  {slagv1}|{slagv2}|{slagv3}" + "\n----------------");
            //                        Console.ForegroundColor = ConsoleColor.Green;
            //                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                        Console.ResetColor();
            //                    }
            //                }

            //                if (spare == 10)
            //                {
            //                    Console.WriteLine("\n " + slagv1 + "|/" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //                else if (slagv1 == 0 && slagv2 == 0)
            //                {
            //                    Console.WriteLine("\n   |-" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //                else
            //                {
            //                    Console.WriteLine($"\n  {slagv1}|{slagv2}" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }
            //            }
            //            else if (slagv1 == 10)
            //            {
            //                if (i == 9)
            //                {
            //                    if (slagv1 == 10)
            //                    {
            //                        int Player2 = rnd.Next(0, 10);
            //                        int slag2 = game.Roll(Player2);

            //                        int Player3 = rnd.Next(0, 10);
            //                        int slag3 = game.Roll(Player3);

            //                        Console.WriteLine($"\n  {slagv1}|{slag2}|{slag3}" + "\n----------------");
            //                        Console.ForegroundColor = ConsoleColor.Green;
            //                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                        Console.ResetColor();
            //                    }
            //                }
            //                else
            //                {
            //                    Console.WriteLine("\n   |X" + "\n----------------");
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
            //                    Console.ResetColor();
            //                }

            //            }
            //            count++;
            //            Console.ReadLine();
            //        }
            //        int save2 = game.Score();
            //        result2.Add(save2);


            //        foreach (var item in result2)
            //        {
            //            Console.WriteLine("Opponent's is result: " + item);
            //        }
            //        Console.WriteLine("Finish");
            //    }
            //    catch (FormatException)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Not right number\nPush enter to try again");
            //        Console.ResetColor();
            //    }
            //    Console.ReadLine();
            //    Console.Clear();
            //}
            #endregion

            //bool stay = true;
            //int write = Convert.ToInt32(Console.ReadLine());

            //while (stay)//har fått problem med att, mer än 10 visar 
            //{
            //    //2 spelaren gör inte varanan slag
            //    try
            //    {

            //        Player();

            //        for (int i = 0; i < 10; i++)
            //        {
            //            RollMany(i, write);
            //        }

            //        Opponent();

            //    }
            //    catch (FormatException)
            //    {

            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Not right number\nPush enter to try again");
            //        Console.ResetColor();
            //    }
            //}
            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        static void Player()
        {

            List<int> result = new List<int>();
            Game game = new Game();



            int count = 1;
            Console.WriteLine("Input pin from 0 to 10: ");
            Console.WriteLine("  1  ,  2  ,  3  ,  4  ,  5  ,  6  ,  7  ,  8  ,  9  ,  10   \n----------------");

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("N " + count);
                Console.ResetColor();

                int Player1 = Convert.ToInt32(Console.ReadLine());
                int slag1 = game.Roll(Player1);


                if (slag1 >= 0 && slag1 < 10)
                {
                    int Player2 = Convert.ToInt32(Console.ReadLine());
                    int slag2 = game.Roll(Player2);
                    int spare = slag1 + slag2;//?

                    if (i == 9)//lösning till 3e slaget
                    {
                        if (spare == 10)
                        {
                            int Player3 = Convert.ToInt32(Console.ReadLine());
                            int slag3 = game.Roll(Player3);

                            Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                            Console.ResetColor();
                        }
                    }

                    if (spare == 10)
                    {
                        Console.WriteLine("\n   " + slag1 + "|/" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }
                    else if (slag1 == 0 && slag2 == 0)
                    {
                        Console.WriteLine("\n   |-" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"\n  {slag1}|{slag2}" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }
                }
                else if (slag1 == 10)
                {
                    if (i == 9)
                    {
                        if (slag1 == 10)
                        {
                            int Player2 = Convert.ToInt32(Console.ReadLine());
                            int slag2 = game.Roll(Player2);

                            int Player3 = Convert.ToInt32(Console.ReadLine());
                            int slag3 = game.Roll(Player3);

                            Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                            Console.ResetColor();


                        }
                    }
                    else
                    {
                        Console.WriteLine("\n   |X" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }

                }
                count++;
            }
            //save results
            int save = game.Score();
            result.Add(save);


            foreach (var item in result)
            {
                Console.Write("Player's result: " + item);
            }

            Console.Clear();
            Console.ReadLine();
        }

        static void Opponent()
        {
            List<int> result2 = new List<int>();
            Game game = new Game();
            Random rnd = new Random();
            int count = 1;

            Console.WriteLine("Input pin from 0 to 10: ");
            Console.WriteLine("  1  ,  2  ,  3  ,  4  ,  5  ,  6  ,  7  ,  8  ,  9  ,  10   \n----------------");


            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("N " + count);
                Console.ResetColor();

                int Versys1 = rnd.Next(0, 10);
                int slagv1 = game.Roll(Versys1);


                if (slagv1 >= 0 && slagv1 < 10)
                {
                    int Versys2 = rnd.Next(0, 10);
                    int slagv2 = game.Roll(Versys2);
                    int spare = slagv1 + slagv2;//?

                    if (i == 9)//lösning till 3e slaget
                    {
                        if (spare == 10)
                        {
                            int Versys3 = rnd.Next(0, 10);
                            int slagv3 = game.Roll(Versys3);

                            Console.WriteLine($"\n  {slagv1}|{slagv2}|{slagv3}" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                            Console.ResetColor();
                        }
                    }

                    if (spare == 10)
                    {
                        Console.WriteLine("\n " + slagv1 + "|/" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }
                    else if (slagv1 == 0 && slagv2 == 0)
                    {
                        Console.WriteLine("\n   |-" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"\n  {slagv1}|{slagv2}" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }
                }
                else if (slagv1 == 10)
                {
                    if (i == 9)
                    {
                        if (slagv1 == 10)
                        {
                            int Player2 = rnd.Next(0, 10);
                            int slag2 = game.Roll(Player2);

                            int Player3 = rnd.Next(0, 10);
                            int slag3 = game.Roll(Player3);

                            Console.WriteLine($"\n  {slagv1}|{slag2}|{slag3}" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n   |X" + "\n----------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  " + game.Score() + " Score" + "\n----------------");
                        Console.ResetColor();
                    }

                }
                count++;
                Console.ReadLine();
            }
            int save2 = game.Score();
            result2.Add(save2);


            foreach (var item in result2)
            {
                Console.WriteLine("Opponent's is result: " + item);
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void RollMany(int rolls, int pins)
        {
            Game game = new Game();
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
