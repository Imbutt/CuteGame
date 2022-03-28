using CuteGame.Objects.Helper;
using CuteGame.Objects.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.Enemies
{
    public class Slime : BattleCharacter
    {
        public Slime(SpyGame game, SceneBattle scene) : base(game, scene)
        {
            SpriteAnimation anim = new SpriteAnimation(this.Game,this.Game.resourceContainer._Content._Texture._BigDemon);
            this.Sprite = new Sprite(this,anim);

            this.CollisionBox = this.GetDefaultCollisionBox();
        }



        
    }
}
