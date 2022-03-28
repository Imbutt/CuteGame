using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI.DiceUIFolder
{
    public class ActionSlot : DiceUIComponent
    {
        

        public ActionSlot(SpyGame game, DiceUI diceUI) : base(game, diceUI)
        {
            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.actionOK_png);
            this.CollisionBox = this.GetDefaultCollisionBox();
        }
    }
}
