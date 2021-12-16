using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI
{
    public class DiceSlot : Thing
    {
        public DiceSlot(SpyGame game) : base(game)
        {
            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.diceSlot_png);
            this.CollisionBox = this.GetDefaultCollisionBox();
        }
    }
}
