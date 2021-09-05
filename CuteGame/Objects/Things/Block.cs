using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things
{
    public class Block : Thing
    {
        public Block(SpyGame game) : base(game) 
        {
            this.Sprite = new Sprite(this, "floor_1");
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
