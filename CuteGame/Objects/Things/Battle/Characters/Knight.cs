using CuteGame.Objects.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.Characters
{
    public class Knight : BattleCharacter
    {
        public Knight(SpyGame game, SceneBattle _screenBattle) : base(game, _screenBattle)
        {
            this.Sprite = new Sprite(this, "knight_f_idle_anim_f0");
        }


    }
}
