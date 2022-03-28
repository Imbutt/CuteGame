using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI.DiceUIFolder
{
    public class DiceSlot : DiceUIComponent
    {
        public Point SlotPosition { get; private set; }

        public DiceSlot(SpyGame game,string diceUI,int tileX, int tileY) : base(game, new DiceUI(new Scenes.Scene(new SpyGame())))
        {
            this.SlotPosition = new Point(tileX, tileY);
            //this.DiceUI = diceUI;

            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.diceSlot_png);
            this.CollisionBox = this.GetDefaultCollisionBox();
        }
    }
}
