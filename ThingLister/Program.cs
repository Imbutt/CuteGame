﻿using System;
using System.Collections.Generic;
using System.IO;

namespace ThingLister
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = args[0];

            string thingsFolder = root + @"\CuteGame\Objects\Things";

            // Get all files and subdirectories paths
            List<string> filesList = new List<string>();
            List<string> dirsList = new List<string>();

            string[] subdirectoryEntries = Directory.GetDirectories(thingsFolder);
            // Load subdirectories
            dirsList.Add(thingsFolder);
            dirsList.AddRange(new List<string>(subdirectoryEntries));
            filesList.AddRange(new List<string>(Directory.GetFiles(thingsFolder)));
            // Load subdirectories of subdirectories...
            foreach (string subdirectory in subdirectoryEntries)
                LoadSubDirs(subdirectory, filesList, dirsList);


            // Write in .cs file
            string listObjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ListContainerCode.txt";
            string lines = File.ReadAllText(listObjectPath);

            // write Using references
            int refIndex = lines.IndexOf("//StartUsing") + "//StartUsing".Length;
            foreach (string dirPath in dirsList)
            {
                // Get and format item
                string item = dirPath;
                item = item.Substring(item.LastIndexOf(@"\CuteGame\") + 1, item.Length - item.LastIndexOf(@"\CuteGame\") - 1);
                item = item.Replace('\\', '.');

                // Complete the line of code
                string itemWrite = $"using {item};";
                Console.WriteLine(itemWrite);

                // Write the code
                lines = lines.Insert(refIndex, "\n" + itemWrite);
                refIndex += itemWrite.Length + 1;
            }

            // Write inside list
            int listIndex = lines.IndexOf("//StartDict") + "//StartDict".Length;

            for (int i = 0; i < filesList.Count; i++)
            {
                // Get and format item 
                string item = filesList[i];
                item = item.Substring(item.LastIndexOf('\\') + 1, item.Length - item.LastIndexOf('\\') - 4);

                // Complete the line of code
                string itemWrite = $"\t\t\t [ \"{item}\", typeof({item}) ] ";
                itemWrite = itemWrite.Replace(']', '}').Replace('[', '{');
                if (i != filesList.Count - 1)
                    itemWrite += ',';

                Console.WriteLine(itemWrite);   // Debug

                // Write the code
                lines = lines.Insert(listIndex, "\n" + itemWrite);
                listIndex += itemWrite.Length + 1;
            }

            // Write all the code in the .cs file

            //File.WriteAllText(@"C:\Users\Utente\Desktop\Nuovo documento di testo.txt",lines);
            string codeFile = root + @"\CuteGame\Objects\Helper\ThingListContainer.cs";
            File.WriteAllText(codeFile, lines);
        
        }

        public static void LoadSubDirs(string dir, List<string> filesList, List<string> dirsList)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            // Save paths
            filesList.AddRange(new List<string>(Directory.GetFiles(dir)));
            dirsList.AddRange(new List<string>(subdirectoryEntries));


            // Load subdirs

            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory, filesList,dirsList);
            }
        }
    }
}
