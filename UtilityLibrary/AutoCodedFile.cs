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
    }
}
