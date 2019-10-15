using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    //Beräkningen på summan
    //tog en och halv dag innan jag fixat det
    public class Game
    {
        public int[] pinFalls = new int[21];
        public int currentRoll;
        //         ruta     kägla 
        public int Roll(int pins)
        {
            //Kast
            pins = pinFalls[currentRoll] = pins;
            currentRoll++;
            Console.WriteLine("Kast: " + currentRoll + "\n----------");
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

        public int Score()//sammlar resultat
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
    }
}