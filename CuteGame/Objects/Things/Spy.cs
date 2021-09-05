﻿using CuteGame.Objects.Helper.Input.InputClasses;
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

        public Spy(SpyGame game) : base (game)
        {
            this.Sprite = new Sprite(this, "knight_f_idle_anim_f0");

            this.CollidesWithTypes.Add(typeof(Block));
        }

        // Testing ldtk
        public Spy(SpyGame game,string test) : base(game)
        {
            this.Sprite = new Sprite(this, "knight_f_idle_anim_f0");

            this.CollidesWithTypes.Add(typeof(Block));
        }

        public Spy(SpyGame game, string[] test) : this(game)
        {
            this.Sprite = new Sprite(this, "knight_f_idle_anim_f0");

            this.CollidesWithTypes.Add(typeof(Block));


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

            if (Game.inputManager.IsKeybKeyPressed(Input.Special))
                Game.soundManager.PlaySoundName("Audio/hit");
            if (Game.inputManager.IsKeybKeyPressed(Input.Jump))
                Game.soundManager.PlaySoundName("Audio/jump");


            this.Velocity = new Vector2(hInput * this.Speed, vInput * this.Speed);

            this.ApplyCollisions();
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