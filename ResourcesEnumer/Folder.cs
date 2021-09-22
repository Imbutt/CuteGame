using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResourcesEnumer
{
    public class Folder
    {
        public List<Folder> SubFolders { get; set; } = new List<Folder>();
        public List<string> Files { get; set; } = new List<string>();
        public string FolderPath { get; set; }
        public string Name
        {
            get
            {
                return Path.GetFileName(this.FolderPath);
            }

            set { value = null; }
        }

        public Folder(string path, string[] excludeDirs, string[] excludeFiles)
        {
            this.FolderPath = path;
            this.Analyze(excludeDirs, excludeFiles);
        }

        public Folder(string path)
        {
            this.FolderPath = path;
        }

        /// <summary>
        /// Analyze files and subdirectories of the folder, excluding parameters' names'
        /// </summary>
        /// <param name="excludeDirs"> Array of directory names to exclude </param>
        /// <param name="excludeFiles"> Array of file names to exclude </param>
        public List<Folder> Analyze(string[] excludeDirs, string[] excludeFiles)
        {
            // Analyze files
            string[] files = Directory.GetFiles(this.FolderPath);
            for (int i = 0; i < files.Length; i++)
            {
                if (IsValid(files[i], excludeFiles))
                    this.Files.Add(Path.GetFileName(files[i]));
            }

            // Analyze subfolders
            string[] subDirs = Directory.GetDirectories(this.FolderPath);
            for (int i = 0; i < subDirs.Length; i++)
            {
                Folder folder = new Folder(subDirs[i]);
                if(IsValid(folder.Name,excludeDirs))
                {
                    // Continue recursion on found subfolder
                    folder.Analyze(excludeDirs, excludeFiles);
                    this.SubFolders.Add(folder);
                }
            }

            return this.SubFolders;
        }

        /// <summary>
        /// Checks if the name is part of the excluded names
        /// </summary>
        /// <param name="name"> Name to check </param>
        /// <param name="excludeNames"> Excluded names </param>
        /// <returns></returns>
        public bool IsValid(string name, string[] excludeNames)
        {
            
            bool valid = true;
            for (int i = 0; i < excludeNames.Length; i++)
            {
                if (name == excludeNames[i])
                    valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Analyze a folder and return itself and all its subfolders
        /// </summary>
        /// <param name="rootPath"> root folder to analyze </param>
        /// <param name="excludeDirs"> Array of directory names to exclude </param>
        /// <param name="excludeFiles"> Array of file names to exclude </param>
        /// <returns></returns>
        public static List<Folder> AnalyzeFolder(string rootPath, string[] excludeDirs, string[] excludeFiles)
        {
            Folder rootFolder = new Folder(rootPath);
            List<Folder> listFolders = new List<Folder>() { rootFolder };
            
            listFolders.AddRange(rootFolder.Analyze(excludeDirs, excludeFiles));

            return listFolders;
        }
    }


}
