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
using UtilityLibrary;

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

        public string rootPath;

        private void button_BuildEnum_Click(object sender, RoutedEventArgs e)
        {
            rootPath = textbox_Directory.Text + "/Content";
            string[] excludeDirs = new string[] { "bin", "obj" };
            string[] excludeFiles = new string[] { "Content.mgcb", "CuteGame.json" };
            Folder mainFolder = new Folder(rootPath, excludeDirs, excludeFiles);

            ProjectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // Read .cs reference file
            string lines = File.ReadAllText(ProjectFolder + "\\ListEnumerCode.txt")
                .Replace("ClassId", mainFolder.Name)
                .Replace("(ClassName)", mainFolder.Name);

            // Setup codes
            enumerClassCode = File.ReadAllText(ProjectFolder + "\\EnumerClassCode.txt");
            masterFilesCode = File.ReadAllText(ProjectFolder + "\\MasterFilesCode.txt");
            fileCode = File.ReadAllText(ProjectFolder + "\\FileCode.txt");

            // Write final code
            List<string> nameList = new List<string>() { mainFolder.Name };
            string outLines = WriteDirClass(ref lines, mainFolder, nameList);


            // Write all the code in the .cs file

            //File.WriteAllText(@"C:\Users\Utente\Desktop\Nuovo documento di testo.cs", outLines);
            string p = rootPath.Replace(@"/Content", "");
            string codeFile = p + @"\Objects\Helper\AutoCoded\ResourceContainer.cs";
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

                // Write file classes
                string startEnum = $"//Files({classId})";

                for (int i = 0; i < folder.Files.Count; i++)
                {
                    AutoCodedFile file = folder.Files[i];

                    string fileClassName = file.Name.Replace(" ", "_").Replace(".", "_");

                    string fileExtension = file.Name.Substring(file.Name.LastIndexOf('.'));

                    string relativePath = file.AbsolutePath
                        .Replace(this.rootPath, "") // Get only the relative path to the Resources path
                        .Remove(0, 1)
                        .Replace(fileExtension, ""); // Remove the first "\", since monogame does not read it on the first folder


                    string fileString = this.fileCode
                        .Replace("(fileClassName)", fileClassName)
                        .Replace("(fileName)", file.Name)
                        .Replace("(filePath)", file.AbsolutePath)
                        .Replace("(fileRelativePath)", relativePath)
                        .Replace("(fileExtension)", fileExtension);
                    fileString = this.Indentate(fileString, nameList.Count + 1);


                    // Write in FileList

                    string fileInList = fileClassName + ',';
                    if (i == folder.Files.Count)
                        fileInList.Remove(fileInList.Length - 1);

                    int refStartFileList = lines.IndexOf($"/*FilesList({classId})*/");
                    lines = lines.Insert(refStartFileList, fileInList);





                    int refEnumIndex = lines.IndexOf(startEnum) + startEnum.Length;
                    lines = lines.Insert(refEnumIndex, "\n" + fileString);
                    /*
                    enumString = enumString.Insert(refClassItemIndex, "\n" + fileString);
                    refClassItemIndex += fileString.Length + 1;
                    */
                }

                // Write Enum 






            }


            Debug.WriteLine(lines + "\n --------------------------------------------------------------------- \n");

            string foldersListString = string.Empty;
            // Write SubFolders
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                List<string> newNameList = new List<string>(nameList);
                newNameList.Add(folder.SubFolders[i].Name);

                string newClassId = classId + ":" + folder.SubFolders[i].Name;

                // Find "//Subdirs(classId) index"
                string subdirString = $"Subdirs({classId}";
                int SubDirsClassIndex = lines.IndexOf(subdirString) + subdirString.Length + 1;

                // Write in FoldersList
                foldersListString += 

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
        public string Indentate(string _string, int times)
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
