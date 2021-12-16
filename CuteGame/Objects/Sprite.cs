using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;
using CuteGame.Objects.Helper;

namespace CuteGame.Objects
{
    public class Sprite
    {
        public Thing ThingParent { get; private set; }
        public SpriteAnimation Anim { get; set; }

        public Sprite(Thing thingParent)
        {
            this.ThingParent = thingParent;
        }
        public Sprite(Thing thingParent, SpriteAnimation spriteanimation)
        {
            this.ThingParent = thingParent;
            this.Anim = spriteanimation;
            this.Texture = this.Anim.AnimationTextures2D[0];
        }

        public Sprite(Thing thingParent, string textureResource)
        {
            this.ThingParent = thingParent;
            this.Texture = this.ThingParent.Game.resourceManager.GetTexture(textureResource);
        }

        public Sprite(Thing thingParent, AutoCodedFile file)
        {
            this.ThingParent = thingParent;
            this.Texture = this.ThingParent.Game.resourceManager.GetTexture(file);
        }

        // Drawing
        private string _textureResource;
        public string SpriteResource
        {
            get => _textureResource;
            set
            {
                Texture = ThingParent.Game.resourceManager.GetTexture(value);
                _textureResource = value;
            }
        }

        // Active texture to draw
        private Texture2D _texture = null;
        public Texture2D Texture
        {
            get => _texture;

            set
            {
                _texture = value;
                this.Origin = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);
            }
        }

        // Sprite parameters

        public float Rotation { get; set; }
        public Color Color { get; set; } = Color.White;
        public SpriteEffects Effect { get; set; } = SpriteEffects.None;
        public Vector2 Origin { get; set; }
        public float Depth { get; set; } = 0;
        public bool Visible { get; set; } = true;


        // Animation
        public void UpdateAnimation()
        {
            if (Anim.Active)
            {
                float prevFrame = Anim.Frame;
                Anim.Frame += Anim.Velocity;


                Anim.CurrentAnimationNumb = Convert.ToInt32(Math.Floor(Anim.Frame));

                if (Anim.CurrentAnimationNumb >= Anim.AnimationTextures2D.Length)
                {
                    Anim.CurrentAnimationNumb = 0;
                    Anim.Frame = 0;
                }
                    

                this.Texture = Anim.AnimationTextures2D[Anim.CurrentAnimationNumb];


            }

        }


    }
}
