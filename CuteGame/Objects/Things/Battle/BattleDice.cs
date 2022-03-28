using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle
{
    public class BattleDice : Thing
    {
        public enum DiceColorEnum
        {
            White,
            Red
        }

        public int Number { get; set; }
        public DiceColorEnum DiceColor { get; set; }
        public BattleDice(SpyGame game, DiceColorEnum diceColor): base(game)
        {
            this.DiceColor = diceColor;

            var fold = this.Game.resourceContainer._Content._Battle._Dice;
            
        }

        public void GenerateRandom()
        {
            this.Game._random.Next(1, 6);
        }
    }
}
