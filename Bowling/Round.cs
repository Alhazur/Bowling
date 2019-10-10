using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Round
    {
        Game game;
        public void SetUpGame()
        {
            game = new Game();
        }
        //rolls är ruta
        void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        public void RollSpareFirstFrame()
        {
            game.Roll(9);
            game.Roll(1);
            RollMany(18, 1);
        }

        public void RollSpareEveryFrame()
        {
            RollMany(21, 5);
        }

        public void RollNineOneSpares()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(9); game.Roll(1);
            }
            game.Roll(9);
        }

        public void RollPerfectGame()
        {
            RollMany(12, 10);
        }

        public void TypicalGame()
        {
            game.Roll(10);
            game.Roll(9); game.Roll(1);
            game.Roll(5); game.Roll(5);
            game.Roll(7); game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9); game.Roll(0);
            game.Roll(8); game.Roll(2);
            game.Roll(9); game.Roll(1);
        }
    }
}