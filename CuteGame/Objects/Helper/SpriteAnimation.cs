using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace CuteGame.Objects.Helper
{
    public class SpriteAnimation
    {
        public Texture2D[] AnimationTextures2D { get; set; }
        public SpyGame Game { get; private set; }

        public int CurrentAnimationNumb { get; set; } = 0;
        public int AnimationInterval { get; set; } = 0;

        public SpriteAnimation(SpyGame game,AutoCodedFolder folder)
        {
            this.Game = game;
            this.SetAnimationTextures(folder);
        }

        public SpriteAnimation(SpyGame game, string[] stringsResources)
        {
            this.Game = game;
            this.SetAnimationTextures(stringsResources);
        }

        public SpriteAnimation(SpyGame game, AutoCodedFile[] files)
        {
            this.Game = game;
            this.SetAnimationTextures(files);
        }

        public void SetAnimationTextures(string[] stringsResources)
        {
            this.AnimationTextures2D = new Texture2D[stringsResources.Length];
            for (int i = 0; i < stringsResources.Length; i++)
            {
                this.AnimationTextures2D[i] = this.Game.resourceManager.GetTexture(stringsResources[i]);
            }
        }

        public void SetAnimationTextures(AutoCodedFile[] files)
        {
            this.AnimationTextures2D = new Texture2D[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                this.AnimationTextures2D[i] = this.Game.resourceManager.GetTexture(files[i]);
            }
        }

        public void SetAnimationTextures(AutoCodedFolder folder)
        {
            // Find all texture files inside the folder and save them in a temporany list
            List<Texture2D> tempAnimationTextures2D = new List<Texture2D>();
            for (int i = 0; i < folder.FilesList.Count; i++)
            {
                AutoCodedFile file = folder.FilesList[i];
                if (file._FileType == AutoCodedFile.FileType.Texture)
                {
                    Texture2D texture = this.Game.resourceManager.GetTexture(file);
                    tempAnimationTextures2D.Add(texture);
                }
            }

            // Put list in property as array
            if (tempAnimationTextures2D.Count > 0)
                this.AnimationTextures2D = tempAnimationTextures2D.ToArray();
        }


        // Animation
        public bool Active { get; set; } = true;
        public float Velocity { get; set; } = 1;
        public float Frame { get; set; } = 0;


    }
}
