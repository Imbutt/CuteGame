using CuteGame.Objects.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle
{

    

    public class BattleCharacter : Thing
    {
        public enum SIDE
        {
            ALLY,
            ENEMY
        }
        public enum STATE
        {
            ATTACK,
            DONE,
            NONE,
            EMPTY
        }

        public SceneBattle sceneBattle;
        public SIDE Side { get; private set; }
        public BattleCharacter(SpyGame game, SceneBattle _sceneBattle) : base(game) 
        {
            this.sceneBattle = _sceneBattle;
            
        }

        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 2;
        public bool Dead { get; set; } = false;



        public STATE currentState = STATE.EMPTY;
        public BattleCharacter target = null;

        public void Hurt(BattleCharacter target,int damage)
        {
            target.Health -= damage;
            if (target.Health <= 0)
                target.Die();
        }

        public void AttackNormal(BattleCharacter target)
        {
            Hurt(target, this.Damage);
            EndAction();
        }

        public override void Update()
        {
            if(this.sceneBattle.ChosenAlly == this)
            {
                this.sceneBattle.selectArrow.Position = new Vector2(this.PosX, 
                    this.PosY - this.Sprite.Texture.Height);
            }

            if (this.IsClickedPressed(Helper.InputManager.MOUSEBUTTON.LEFT))
                this.sceneBattle.ChooseAlly(this);
        }

        public void EndAction()
        {

        }

        public override void Draw()
        {
            this.Game.drawer.DrawString("Font/Default", this.Health.ToString(),
                new Vector2(this.PosX, this.PosY + 10), Color.White);

            this.DrawPosition();

            base.Draw();
        }

        public void Die()
        {
            this.Dead = true;
        }
    }
}
