using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things
{
    public class Block : Thing
    {
        public Block(SpyGame game) : base(game) 
        {
            this.Sprite = new Sprite(this, this.Game.enumListContainer._Content._Texture.block_png);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
