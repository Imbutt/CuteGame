using CuteGame.Objects.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.Enemies
{
    public class Slime : BattleCharacter
    {
        public Slime(SpyGame game, SceneBattle scene) : base(game, scene)
        {
            string[] anim = new string[] { "Texture/BigDemon/big_demon_idle_anim_f0", "Texture/BigDemon/big_demon_idle_anim_f1"
                , "Texture/BigDemon/big_demon_idle_anim_f2", "Texture/BigDemon/big_demon_idle_anim_f3"};
            this.Sprite = new Sprite(this,anim);
        }



        
    }
}
