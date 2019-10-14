using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    //Beräkningen på summan
    public class Game
    {
        public int[] pinFalls = new int[21];
        public int currentRoll;
        //                  kägla 
        public int Roll(int pins)
        {
            //int pin;//lagt till nytt variable pin, löst problem
            pins = pinFalls[currentRoll] = pins;
            currentRoll++;
            Console.WriteLine("Slaget: " + currentRoll);
            return pins;
        }

        public bool IsStrike(int ten)
        {
            return pinFalls[ten] == 10;
        }

        public bool IsSpare(int five)
        {
            return pinFalls[five] + pinFalls[five + 1] == 10;
        }

        public int StrikeBonus(int frameIndex)
        {
            return pinFalls[frameIndex + 1] + pinFalls[frameIndex + 2];
        }

        public int SpareBonus(int i)
        {
            return pinFalls[i + 2];
        }

        private int NormalScore(int roll)
        {
            return pinFalls[roll] + pinFalls[roll + 1];
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll += 1;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += NormalScore(roll);
                    roll += 2;
                }

            }
            return score;
        }

        //public int Score()
        //{
        //    int score = 0;
        //    int roll = 0;
        //    for (int frame = 0; frame < 10; frame++)
        //    {
        //        if (IsStrike(roll))
        //        {
        //            score += 10 + pinFalls[roll + 1] + pinFalls[roll + 2];
        //            roll += 1;
        //        }
        //        else if (IsSpare(roll))
        //        {
        //            score += 10 + pinFalls[roll + 2];
        //            roll += 2;
        //        }
        //        else
        //        {
        //            score += pinFalls[roll] + pinFalls[roll + 1];
        //            roll += 2;
        //        }
        //    }
        //    return score;
        //}
    }
}