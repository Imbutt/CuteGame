using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThingLister;

using System.Diagnostics;

namespace ResourcesEnumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string ProjectFolder;
        public string enumerClassCode;
        public string masterFilesCode;
        public string fileCode;

        private void button_BuildEnum_Click(object sender, RoutedEventArgs e)
        {
            string rootPath = textbox_Directory.Text;
            string[] excludeDirs = new string[] { "bin","obj" };
            string[] excludeFiles = new string[] { "Content.mgcb", "CuteGame.json" };
            Folder mainFolder = new Folder(rootPath, excludeDirs, excludeFiles);

            ProjectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // Read .cs reference file
            string lines = File.ReadAllText(ProjectFolder + "\\ListEnumerCode.txt")
                .Replace("ClassId",mainFolder.Name)
                .Replace("(ClassName)",mainFolder.Name);

            // Setup codes
            enumerClassCode = File.ReadAllText(ProjectFolder + "\\EnumerClassCode.txt");
            masterFilesCode = File.ReadAllText(ProjectFolder + "\\MasterFilesCode.txt");
            fileCode = File.ReadAllText(ProjectFolder + "\\FileCode.txt");

            // Write final code
            List<string> nameList = new List<string>() { mainFolder.Name };
            string outLines = WriteDirClass(ref lines, mainFolder, nameList);


            // Write all the code in the .cs file

            //File.WriteAllText(@"C:\Users\Utente\Desktop\Nuovo documento di testo.cs", outLines);
            string codeFile = rootPath + @"\Objects\Helper\AutoCoded\EnumListContainer.cs";
            File.WriteAllText(codeFile, outLines);
        }

        public string WriteDirClass(ref string lines, Folder folder, List<string> nameList)
        {
            // SubDirs(parentId,id)

            // Write EnumClass

            // Create ClassId string
            string classId = GetClassId(nameList);

            // Replace "(ClassId)" with the ClassId
            lines = lines.Replace("ClassId", classId);

            /*
            string startClass = "//Subdirs(ClassId)".Replace("(ClassId)", classId);
            int SubDirsClassIndex = lines.IndexOf(startClass) + startClass.Length;
            string classString = EnumerClassCode.Replace("(ClassName)",folder.Name).Replace("(ClassId)", parentCla);
            lines = lines.Insert(SubDirsClassIndex, "\n" + classString);
            */

            
            
            // Write files
            if (folder.Files.Count > 0)
            {
                string enumString = masterFilesCode.Replace("ClassId", classId.ToString());

                // Write Enum items
                string startEnumItem = $"//Enum({classId})";
                int refEnumItemIndex = enumString.IndexOf(startEnumItem) + startEnumItem.Length;
                for (int i = 0; i < folder.Files.Count; i++)
                {
                    // Write the enum item
                    string item = $"{folder.Files[i]},";
                    item = item.Insert(0, "\t");    // Identate
                    item = item.Replace(" ", "_").Replace(".","_"); // Replace spaces and commas

                    if (i == folder.Files.Count - 1)    // If it's the last item, remove the comma (,)
                        item = item.Remove(item.Length - 1);

                    // Write the code
                    enumString = enumString.Insert(refEnumItemIndex, "\n" + item);
                    refEnumItemIndex += item.Length + 1;
                }

                // Write Enum 
                string startEnum = $"//Files({classId})";
                int refEnumIndex = lines.IndexOf(startEnum) + startEnum.Length;
                enumString = this.Indentate(enumString, nameList.Count);
                lines = lines.Insert(refEnumIndex, "\n" + enumString);

                

                
            }
            

            Debug.WriteLine(lines + "\n --------------------------------------------------------------------- \n");

            // Write SubFolders
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                List<string> newNameList = new List<string>(nameList);
                newNameList.Add(folder.SubFolders[i].Name);

                string newClassId = classId + ":" + folder.SubFolders[i].Name;

                // Find "//Subdirs(classId) index"
                string subdirString = $"Subdirs({classId}";
                int SubDirsClassIndex = lines.IndexOf(subdirString) + subdirString.Length + 1;
                // Prepare class template and insert it


                string classString = enumerClassCode.Replace("(ClassName)", folder.SubFolders[i].Name);  // className
                classString = this.Indentate(classString, nameList.Count);

                lines = lines.Insert(SubDirsClassIndex, "\n" + classString);

                // Pass to the subfolder
                lines = WriteDirClass(ref lines, folder.SubFolders[i], newNameList);
            }

            

            return lines;

        }

        /// <summary>
        /// Identates a piece of string code
        /// </summary>
        /// <param name="_string"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public string Indentate(string _string,int times)
        {
            string identation = new String('\t', times + 2);
            _string = _string.Replace("\n", "\n" + identation).Insert(0, identation);

            return _string;
        }

        public string GetClassId(List<string> nameList)
        {
            string classId = String.Empty;
            foreach (string nameClass in nameList)
            {
                classId += nameClass + ":";
            }
            classId = classId.Remove(classId.Length - 1);   // Remove last ":"

            return classId;
        }
    }
}
