using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI.DiceUIFolder
{
    public class DiceTile : DiceUIComponent
    {
        public int TileNum { get; set; }

        public DiceTile(SpyGame game,DiceUI diceUI, int tileN) : base(game, diceUI)
        {
            this.TileNum = tileN;
            this.DiceUI = diceUI;

            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.diceSlot_png);
            this.CollisionBox = this.GetDefaultCollisionBox();
        }
    }
}
