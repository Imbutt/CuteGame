using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI.DiceUIFolder
{
    public class ActionTile : DiceUIComponent
    {
        public int TileNum { get; set; }

        public ActionTile(SpyGame game,DiceUI diceUI, int tileN) : base(game,diceUI)
        {
            this.TileNum = tileN;

            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.actionOK_png);
            this.CollisionBox = this.GetDefaultCollisionBox();
        }
    }
}
