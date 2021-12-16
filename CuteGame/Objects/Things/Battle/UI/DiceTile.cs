﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI
{
    public class DiceTile : Thing
    {
        public DiceTile(SpyGame game) : base(game)
        {
            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.diceSlot_png);
            this.CollisionBox = this.GetDefaultCollisionBox();
        }
    }
}