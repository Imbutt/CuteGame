using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper
{
    public class SoundManager
    {
        public SpyGame Game { get; private set; }

        Dictionary<string, SoundEffect> listSoundEffectLoaded = new Dictionary<string, SoundEffect>();
        Dictionary<string, Song> listSongLoaded = new Dictionary<string, Song>();

        public SoundManager(SpyGame game)
        {
            this.Game = game;
        }

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

        public void PlaySoundName(string soundEffectName)
        {
            this.GetSoundEffect(soundEffectName).Play();
        }
        public void PlaySound(SoundEffect soundEffect)
        {
            soundEffect.Play();
        }

        public void PlaySong(Song song)
        {
            Game.PlaySong(song);
        }

        public void PlaySongName(string songName)
        {
            Game.PlaySong(GetSong(songName));
        }

        public void UnloadResources()
        {
            this.listSongLoaded.Clear();
            this.listSoundEffectLoaded.Clear();
        }
    }
}
