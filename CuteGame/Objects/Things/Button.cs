using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things
{
    public class Button : Thing
    {
        public Sprite IdleSprite { get; set; }
        public Sprite ClickSprite { get; set; }
        public Sprite OverSprite { get; set; }

        public Button(SpyGame game) : base(game)
        {

        }


    }
}
