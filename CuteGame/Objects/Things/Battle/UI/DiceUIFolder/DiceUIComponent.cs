using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI.DiceUIFolder
{
    public abstract class DiceUIComponent : Thing
    {
        public DiceUI DiceUI { get; set; }

        public DiceUIComponent(SpyGame game, DiceUI diceUI) : base(game)
        {
            this.DiceUI = diceUI;
        }


    }
}
