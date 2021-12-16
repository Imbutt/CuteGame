using CuteGame.Objects.Helper;
using CuteGame.Objects.Helper.Input.InputClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things
{
    public class Spy : Thing
    {
        public InputPlayer Input { get; set; } = new InputPlayer();
        public int Speed { get; set; } = 1;

        public SpriteAnimation AnimRun { get; set; }
        public SpriteAnimation AnimIdle { get; set; }

        public Spy(SpyGame game) : base (game)
        {
            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Knight._Idle.knight_f_idle_anim_f0_png);

            this.CollisionBox = this.GetDefaultCollisionBox();
            this.CollidesWithTypes.Add(typeof(Block));

            this.AnimRun = new SpriteAnimation(this.Game, this.Game.resourceContainer._Content._Texture._Knight._Idle);
            this.AnimIdle = new SpriteAnimation(this.Game, this.Game.resourceContainer._Content._Texture._Knight._Run);
            this.AnimRun.Velocity = 0.1f;
            this.AnimIdle.Velocity = 0.1f;
        }

        public override void Update()
        {
            this.Game.camera.Position = this.Position;

            // Input
            int hInput = 0; int vInput = 0;

            if (Game.inputManager.IsKeybKeyDown(Input.Left))
                hInput = -1;
            if (Game.inputManager.IsKeybKeyDown(Input.Right))
                hInput = 1;
            if (Game.inputManager.IsKeybKeyDown(Input.Up))
                vInput = -1;
            if (Game.inputManager.IsKeybKeyDown(Input.Down))
                vInput = 1;

            // Animation
            if (hInput != 0 || vInput != 0)
                this.Sprite.Anim = this.AnimRun;
            else
                this.Sprite.Anim = this.AnimIdle;

            if (Game.inputManager.IsKeybKeyPressed(Input.Special))
                Game.audioManager.PlaySound("Audio/hit");
            if (Game.inputManager.IsKeybKeyPressed(Input.Jump))
                Game.audioManager.PlaySound("Audio/jump");


            this.Velocity = new Vector2(hInput * this.Speed, vInput * this.Speed);

            this.ApplyCollisionsVelocity();
            this.ApplyVelocity(true);

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            Game.drawer.DrawStringHud("a",new Vector2(10,10));
           
        }
    }
}
