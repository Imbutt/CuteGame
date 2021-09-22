using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace CuteGame.Objects.Helper
{
    public class SpriteManager
    {
        public SpyGame Game { get; private set; }

        public SpriteManager(SpyGame game)
        {
            this.Game = game;
        }

        Dictionary<string, Texture2D> listTexturesLoaded = new Dictionary<string, Texture2D>();

        public Texture2D GetTexture(string textureResource)
        {
            Texture2D texture;

            if (!listTexturesLoaded.TryGetValue(textureResource, out texture))
            {
                texture = Game.Content.Load<Texture2D>(textureResource);
                listTexturesLoaded.Add(textureResource, texture);
            }

            return texture;

        }

        public Texture2D GetTexture(AutoCodedFile autoCodedFile)
        {
            return this.GetTexture(autoCodedFile.RelativePath);
        }

        public void UnloadResources()
        {
            listTexturesLoaded.Clear();
        }
    }
}
