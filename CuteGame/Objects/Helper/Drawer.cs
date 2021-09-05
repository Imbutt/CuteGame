using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper
{
    public class Drawer
    {
        public SpyGame Game { get; private set; }

        // Fonts
        Dictionary<string, SpriteFont> listFontsLoaded = new Dictionary<string, SpriteFont>();
        public string FontResourceDefault { get; set; }
        public Color ColorDefault { get; set; } = Color.White;
        public float RotationDefault { get; private set; } = 0.00f;
        public float ScaleDefault { get; set; } = 1.00f;
        public Vector2 RotationOriginDefault { get; private set; } = new Vector2(0, 0);
        public SpriteEffects SpriteEffectsDefault { get; private set; } = SpriteEffects.None;

        public Drawer(SpyGame game)
        {
            this.Game = game;
            this.FontResourceDefault = "Font/Default";
        }

        public SpriteFont GetFont(string fontResource)
        {
            SpriteFont texture;

            if (!listFontsLoaded.TryGetValue(fontResource, out texture))
            {
                texture = Game.Content.Load<SpriteFont>(fontResource);
                listFontsLoaded.Add(fontResource, texture);
            }

            return texture;

        }

        public void DrawSprite(string spriteResource, Vector2 position, Color color, float rotation,
            float scale, float depth)
        {
            Texture2D texture = this.Game.spriteManager.GetTexture(spriteResource);

            Game._spriteBatch.Draw(texture, position, null, color,
                rotation, new Vector2(texture.Width / 2,texture.Height / 2), scale * Game.globalScale,
                SpriteEffects.None, depth);
        }

        public void DrawString(string fontResource,string text, Vector2 position, Color color, float scale, float layer)
        {
            this.DrawString(fontResource, text, position, color,
                this.RotationDefault, this.RotationOriginDefault, scale,
                this.SpriteEffectsDefault, layer);
        }

        public void DrawString(string fontResource, string text, Vector2 position, Color color)
        {
            SpriteFont font = GetFont(fontResource);

            this.Game._spriteBatch.DrawString(font, text, position, color);
        }

        /// <summary>
        /// Complete drawstring with all parameters
        /// </summary>
        public void DrawString(string fontResource, string text, Vector2 position, Color color,
            float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            SpriteFont font = GetFont(fontResource);

            this.Game._spriteBatch.DrawString(font,text,position,color,rotation,origin, scale, effects,layerDepth);
        }

        public void DrawStringHud(string text, Vector2 position)
        {
            DrawStringHud(this.FontResourceDefault, text, position, this.ColorDefault, this.ScaleDefault, 10000);
        }

        /// <summary>
        /// Draw string that follows the camera
        /// </summary>
        /// <param name="fontResource"> Resource name of the font to use </param>
        /// <param name="text"> Text to draw </param>
        /// <param name="position"> Position relative to the top left corner of the camera's viewpoint </param>
        /// <param name="color"> Color of the text </param>
        public void DrawStringHud(string fontResource, string text, Vector2 position, Color color, float scale,float layer)
        {
            Camera camera = Game.camera;
            Vector2 vec = new Vector2(camera.Position.X - camera.viewport.Width / 2 / camera.Zoom, 
                camera.Position.Y - camera.viewport.Height / 2 / camera.Zoom);

            this.DrawString(fontResource, text,vec + position, color,scale / camera.Zoom,layer);
        }
    }
}
