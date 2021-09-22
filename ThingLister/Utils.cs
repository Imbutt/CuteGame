using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThingLister
{
    public static class Utils
    {
        public static List<string>[] LoadSubDirs(string dir, List<string> filesList, List<string> dirsList, string[]? excludeDirs, string[]? excludeFiles)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            // Save paths
            filesList.AddRange(new List<string>(Directory.GetFiles(dir)));
            dirsList.AddRange(new List<string>(subdirectoryEntries));

            dirsList = ExcludeFromList(dirsList, excludeDirs);
            filesList = ExcludeFromList(filesList, excludeFiles);
            // Load subdirs

            foreach (string subdirectory in subdirectoryEntries)
            {
                List<string>[] lists = LoadSubDirs(subdirectory, filesList, dirsList, excludeDirs, excludeFiles);
                filesList = lists[0];
                dirsList = lists[1];
            }

            return new List<string>[] { filesList, dirsList };
        }

        public static List<string>[] LoadFilesAndDirs(string folder, string[]? excludeDirs, string[]? excludeFiles)
        {
            // Get all files and subdirectories paths
            List<string> filesList = new List<string>();
            List<string> dirsList = new List<string>();

            string[] subdirectoryEntries = Directory.GetDirectories(folder);
            
            // Load subdirectories
            dirsList.Add(folder);
            dirsList.AddRange(new List<string>(subdirectoryEntries));
            filesList.AddRange(new List<string>(Directory.GetFiles(folder)));

            // Exclude specified directories and files
            dirsList = ExcludeFromList(dirsList, excludeDirs);
            filesList = ExcludeFromList(filesList, excludeFiles);
            

            // Load subdirectories of subdirectories...
            foreach (string subdirectory in subdirectoryEntries)
            {
                List<string>[] lists = Utils.LoadSubDirs(subdirectory, filesList, dirsList, excludeDirs, excludeFiles);
                filesList = lists[0];
                dirsList = lists[1];
            }
                

            return new List<string>[] { filesList, dirsList };
        }

        public static List<string> ExcludeFromList(List<string> list, string[] excludeArr)
        {
            if (excludeArr != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < excludeArr.Length; j++)
                    {
                        if (list[i] == excludeArr[j])
                        {
                            list.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            return list;
        }

        public static string WriteDictionaryLine(string key, string item, bool last)
        {
            // Complete the line of code
            string itemWrite = $"\t\t\t [ \"{key}\", typeof({item}) ] ";
            itemWrite = itemWrite.Replace(']', '}').Replace('[', '{');
            if (last)
                itemWrite += ',';

            return itemWrite;
        }

    }
}
