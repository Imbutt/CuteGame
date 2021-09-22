using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace CuteGame.Objects
{
    public class Sprite
    {
        public Thing ThingParent { get; private set; }

        public Sprite(Thing thingParent)
        {
            this.ThingParent = thingParent;
        }
        public Sprite(Thing thingParent, string[] _animationTexturesResource)
        {
            this.ThingParent = thingParent;
            this.AnimationTexturesResource = _animationTexturesResource;
            this.Texture = thingParent.Game.spriteManager.GetTexture(this.AnimationTexturesResource[0]);
        }

        public Sprite(Thing thingParent, string textureResource)
        {
            this.ThingParent = thingParent;
            this.Texture = this.ThingParent.Game.spriteManager.GetTexture(textureResource);
        }

        public Sprite(Thing thingParent, AutoCodedFile file)
        {
            this.ThingParent = thingParent;
            this.Texture = this.ThingParent.Game.spriteManager.GetTexture(file);
        }

        // Drawing
        private string _textureResource;
        public string SpriteResource
        {
            get => _textureResource;
            set
            {
                Texture = ThingParent.Game.spriteManager.GetTexture(value);
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
        public Texture2D[] AnimationTextures { get; private set; }
        private string[] _animationTexturesResource;
        public string[] AnimationTexturesResource 
        {
            get { return _animationTexturesResource; }
            set 
            {
                _animationTexturesResource = value;

                SetAnimationTextures(_animationTexturesResource);
            }
        }
        public int CurrentAnimationNumb { get; set; }
        public int AnimationInterval { get; set; }

        public void SetAnimationTextures(string[] stringsResources)
        {
            this.AnimationTextures = new Texture2D[stringsResources.Length];
            for (int i = 0; i < stringsResources.Length; i++)
            {
                this.AnimationTextures[i] = this.ThingParent.Game.spriteManager.GetTexture(stringsResources[i]);
            }
        }

        private void UpdateAnimation()
        {
            this.CurrentAnimationNumb++;

            if (this.CurrentAnimationNumb >= AnimationTextures.Length)
                this.CurrentAnimationNumb = 0;

            this.Texture = this.AnimationTextures[this.CurrentAnimationNumb];
        }

    }
}
