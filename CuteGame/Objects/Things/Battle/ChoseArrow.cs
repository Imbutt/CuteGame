using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle
{
    public class ChoseArrow : Thing
    {
        public ChoseArrow(SpyGame game) :base (game)
        {
            this.Sprite = new Sprite(this, "Texture/block");
        }
    }
}
