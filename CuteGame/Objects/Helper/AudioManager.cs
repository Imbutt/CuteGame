using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace CuteGame.Objects.Helper
{
    public class AudioManager
    {
        public SpyGame Game { get; set; }
        public Song CurrentSong { get; set; }

        public AudioManager(SpyGame game)
        {
            Game = game;
        }

        // Sounds
        public void PlaySound(string soundEffectName)
        {
            this.Game.resourceManager.GetSoundEffect(soundEffectName).Play();
        }

        public void PlaySound(AutoCodedFile file)
        {
            this.PlaySound(file.RelativePath);
        }

        public void PlaySound(SoundEffect soundEffect)
        {
            soundEffect.Play();
        }

        // Songs
        public void PlaySong(Song song)
        {
            MediaPlayer.Stop();
            this.CurrentSong = song;
            MediaPlayer.Play(this.CurrentSong);
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
            this.CurrentSong = null;
        }

        public void PlaySong(AutoCodedFile file)
        {
            this.PlaySong(file.Name);
        }

        public void PlaySong(string songName)
        {
            this.PlaySong(this.Game.resourceManager.GetSong(songName));
        }
    }
}
