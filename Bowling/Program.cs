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
    public class Program
    {
        static void Main(string[] args)
        {
            //Game game = new Game();
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("Bowling");
                GameStart();

                Console.WriteLine("Write e to Exit:\nOr Enter to play again  ");
                string filmNamn = Console.ReadLine();
                if (filmNamn == "e")
                {
                    stay = false;
                    break;
                }
                Console.Clear();
            }
        }

        static void GameStart()
        {
            //Allt häldelsen händer här från starta tävla mot varandra
            Random rnd = new Random();

            Game game = new Game();
            //kunde inte spara två olika resultater 
            //hittade lösning, skappat andra object
            Game game2 = new Game();
            int Pins = 10;

            //båda spelare kan tävla mot varandra
            #region test
            int count = 1;
            try
            {
                Console.WriteLine("From 0 to 10: ");
                //Samma som tio ruta i class Game.Score
                for (int i = 0; i < 10; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Spelaren Ruta: " + count);
                    Console.ResetColor();

                    int Player1 = Convert.ToInt32(Console.ReadLine());
                    //du får inte gör mer än tio slag
                    if (Player1 > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pins can't be more then 10");
                        Console.ResetColor();
                        Player1 = Convert.ToInt32(Console.ReadLine());
                    }
                    int remainning = Pins - Player1;

                    int slag1 = game.Roll(Player1 /*> 10 ? Calc(Player1) : Player1*/);

                    //player1 tvä sätt strike eller mindre än 10 käglor på sig  
                    //samma lösning till Motståndare finns till längt ner 
                    //den tog till mig två dagar att fixa
                    if (slag1 >= 0 && slag1 < 10)
                    {
                        int Player2 = Convert.ToInt32(Console.ReadLine());

                        if (Player2 > 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Pins can't be more then 10");
                            Console.ResetColor();
                            Player2 = Convert.ToInt32(Console.ReadLine());
                        }

                        if (Player2 > remainning)
                        {
                            Console.WriteLine("You have left: " + remainning);
                            Player2 = Convert.ToInt32(Console.ReadLine());
                        }

                        int slag2 = game.Roll(Player2);
                        int spare = slag1 + slag2;//?



                        if (spare == 10)
                        {
                            //den 10de ruta om man gör spärr eller strike man har rätt till att gör 3 slag
                            if (i == 9)//lösning till 3e slaget
                            {
                                if (spare == 10)
                                {
                                    int Player3 = Convert.ToInt32(Console.ReadLine());
                                    int slag3 = game.Roll(Player3);

                                    Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("  " + game.Score() + " Score" + "\n----------------\n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n   " + slag1 + "|/" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game.Score() + " Score" + "\n----------------\n");
                                Console.ResetColor();

                            }

                        }
                        else if (slag1 == 0 && slag2 == 0)
                        {
                            Console.WriteLine("\n   " + slag1 + "|" + slag1 + "" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"\n  {slag1}|{slag2}" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------\n");
                            Console.ResetColor();
                        }
                    }
                    else if (slag1 == 10)// om du slår ner en Strike du ett slag till i 10de ruta
                    {

                        if (i == 9)
                        {
                            if (slag1 == 10)
                            {
                                int Player2 = Convert.ToInt32(Console.ReadLine());
                                int slag2 = game.Roll(Player2);

                                int Player3 = Convert.ToInt32(Console.ReadLine());
                                if (Player3 > 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Pins can't be more then 10");
                                    Console.ResetColor();
                                    Player3 = Convert.ToInt32(Console.ReadLine());
                                }
                                int slag3 = game.Roll(Player3);

                                Console.WriteLine($"\n  {slag1}|{slag2}|{slag3}" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game.Score() + " Score" + "\n----------------\n");
                                Console.ResetColor();


                            }
                        }
                        else
                        {
                            Console.WriteLine("\n   |X" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game.Score() + " Score" + "\n----------------\n");
                            Console.ResetColor();
                        }

                    }

                    //--------------------------------------------------------------------------------------

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Motståndare Ruta: " + count);
                    Console.ResetColor();

                    //Motståndare gör ett Random slag 
                    //han har lite högre chans att vinna
                    int slagv1 = game2.Roll(rnd.Next(6, 10));

                    if (slagv1 >= 0 && slagv1 < 10)
                    {
                        int slagv2 = game2.Roll(slagv1 == 9 ? rnd.Next(0, 1) : slagv1 == 8 ? rnd.Next(0, 2) : slagv1 == 7 ? rnd.Next(1, 3) : rnd.Next(1, 4));
                        int spare = slagv1 + slagv2;//?

                        if (spare == 10)
                        {
                            //lösning till 3e slaget
                            if (i == 9)
                            {
                                if (spare == 10)
                                {
                                    int slagv3 = game2.Roll(rnd.Next(9, 10));

                                    Console.WriteLine($"\n  {slagv1}|{slagv2}|{slagv3}" + "\n----------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------\n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n " + slagv1 + "|/" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------\n");
                                Console.ResetColor();

                            }
                        }
                        else if (slagv1 == 0 && slagv2 == 0)
                        {
                            Console.WriteLine("\n   |-" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"\n  {slagv1}|{slagv2}" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------\n");
                            Console.ResetColor();
                        }
                    }
                    else if (slagv1 == 10)
                    {
                        if (i == 9)
                        {
                            if (slagv1 == 10)
                            {
                                int slag2 = game2.Roll(rnd.Next(10, 10));

                                int slag3 = game2.Roll(rnd.Next(0, 10));

                                Console.WriteLine($"\n  {slagv1}|{slag2}|{slag3}" + "\n----------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------\n");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n   |X" + "\n----------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  " + game2.Score() + " Score" + "\n----------------\n");
                            Console.ResetColor();
                        }

                    }
                    count++;
                }
                Console.WriteLine("Player's result: " + game.Score());
                Console.WriteLine("Opponent's result: " + game2.Score());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("          Finish");
                Console.ResetColor();

                //efter spelen dem får resultater
                if (game.Score() > game2.Score())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player is Won " + game.Score());
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opponent is Won " + game2.Score());
                    Console.ResetColor();
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
            #endregion
        }
    }
}
