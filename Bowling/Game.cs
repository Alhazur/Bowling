using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    //Beräkningen på summan class
    public class Game
    {
        int[] pinFalls = new int[21];
        int rollCounter;
        //                   kägla 
        public int Roll(int pins)
        {
            int pin = pinFalls[rollCounter] = pins;
            rollCounter++;
            return pin;
        }

        public bool IsStrike(int frameIndex)
        {
            return pinFalls[frameIndex] == 10;
        }

        public bool IsSpare(int frameIndex)
        {
            return pinFalls[frameIndex] + pinFalls[frameIndex + 1] == 10;
        }

        public int StrikeBonus(int frameIndex)
        {
            return pinFalls[frameIndex + 1] + pinFalls[frameIndex + 2];
        }

        public int SpareBonus(int i)
        {
            return pinFalls[i + 2];
        }
        public int Score()
        {
            int score = 0;
            for (int i = 0; i < 10; i++)
            {
                if (IsStrike(i))
                {
                    score += 10 + StrikeBonus(i);
                    i += 1;
                }
                else if (IsSpare(i))
                {
                    score += 10 + SpareBonus(i);
                    i += 2;
                }
                else
                {
                    score += pinFalls[i] + pinFalls[i + 1];
                    i += 2;
                }
            }
            return score;
        }
    }
}