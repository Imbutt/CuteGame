using CuteGame.Objects.Helper;
using CuteGame.Objects.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things
{
    public class Slimee : Thing
    {
        public Slimee(SpyGame game) : base(game)
        {
            SpriteAnimation anim = new SpriteAnimation(this.Game,this.Game.resourceContainer._Content._Texture._BigDemon);

            this.Sprite = new Sprite(this, anim);
        }




    }
}
