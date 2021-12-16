using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityLibrary
{
    public class AutoCodedFile
    {
        public AutoCodedFile(string name, string absolutePath)
        {
            Name = name;
            AbsolutePath = absolutePath;
        }

        public AutoCodedFile(string name, string absolutePath, string relativePath, string extension) : this(name, absolutePath)
        {
            RelativePath = relativePath;
            Extension = extension;
        }

        public string Name { get; set; }
        public string AbsolutePath { get; set; }
        public string RelativePath { get; set; }
        public string Extension { get; set; }

        public FileType _FileType 
        {
            get
            {
                string[] imageExtensions = new string[] { ".bmp", ".dds", ".dib", ".hdr", ".jpg", ".pfm", ".png", ".ppm", ".tga" };
                string[] audioExtensions = new string[] { ".xap", ".wma", ".mp3", ".wav"};
                if (Array.Find(imageExtensions, x => x == this.Extension) != null)
                    return FileType.Texture;
                else
                    if (Array.Find(audioExtensions, x => x == this.Extension) != null)
                    return FileType.Audio;
                else
                    if (this.Extension == ".spritefont")
                    return FileType.Font;
                else
                    if (this.Extension == ".fx")
                    return FileType.Effect;

                return FileType.None;
            } 
        }
        public enum FileType
        {
            Texture,
            Audio,
            Font,
            Effect,
            None
        }
    }
}
