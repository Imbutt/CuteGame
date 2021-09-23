using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace CuteGame.Objects.Helper
{
    public class ResourceManager
    {
        public SpyGame Game { get; private set; }

        // Loaded Content dictionaries
        Dictionary<string, Texture2D> listTexturesLoaded = new Dictionary<string, Texture2D>();
        Dictionary<string, SoundEffect> listSoundEffectLoaded = new Dictionary<string, SoundEffect>();
        Dictionary<string, Song> listSongLoaded = new Dictionary<string, Song>();

        public ResourceManager(SpyGame game)
        {
            this.Game = game;
        }

        // Textures
       

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

        // Sound
        public SoundEffect GetSoundEffect(string soundEffectResource)
        {
            SoundEffect soundEffect;
            if (!listSoundEffectLoaded.TryGetValue(soundEffectResource, out soundEffect))
            {
                soundEffect = this.Game.Content.Load<SoundEffect>(soundEffectResource);
                listSoundEffectLoaded.Add(soundEffectResource, soundEffect);
            }

            return soundEffect;
        }
        public SoundEffect GetSoundEffect(AutoCodedFile file)
        {
            return this.GetSoundEffect(file.Name);
        }

        public Song GetSong(string songResource)
        {
            Song soundEffect;
            if (!listSongLoaded.TryGetValue(songResource, out soundEffect))
            {
                soundEffect = this.Game.Content.Load<Song>(songResource);
                listSongLoaded.Add(songResource, soundEffect);
            }

            return soundEffect;
        }

        public Song GetSong(AutoCodedFile file)
        {
            return this.GetSong(file.Name);
        }



        /// <summary>
        /// Clears all the resources dictionaries
        /// </summary>
        public void UnloadResources()
        {
            this.listSongLoaded.Clear();
            this.listSoundEffectLoaded.Clear();
            this.listTexturesLoaded.Clear();
        }
    }
}
