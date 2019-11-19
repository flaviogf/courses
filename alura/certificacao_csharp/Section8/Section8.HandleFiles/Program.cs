using System;
using System.IO;

namespace Section8.HandleFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UsingFileClass();

            HandleExceptions();

            GettingDriveInfo();

            GettingFileInfo();

            void ListDirectory(DirectoryInfo info)
            {
                foreach (var directory in info.GetDirectories())
                {
                    foreach (var file in directory.GetFiles("*.cs"))
                    {
                        Console.WriteLine(file.FullName);
                    }

                    ListDirectory(directory);
                }
            }

            ListDirectory(new DirectoryInfo(Path.Join("..", "..")));
        }

        private static void GettingFileInfo()
        {
            var info = new FileInfo("temp.txt");

            info.Create();
            Console.WriteLine("Exists? {0}", info.Exists);
            Console.WriteLine("Attributes: {0}", info.Attributes);
            info.Attributes = info.Attributes | FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);
            info.Attributes = info.Attributes & ~FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);
            info.Delete();
            Console.WriteLine("Exists? {0}", info.Exists);
        }

        private static void GettingDriveInfo()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                Console.WriteLine("Name: {0}", drive.Name);
                Console.WriteLine("IsReady {0}", drive.IsReady);
                Console.WriteLine("Type: {0}", drive.DriveType);
                Console.WriteLine("Format: {0}", drive.DriveFormat);
                Console.WriteLine("Free space:");
                var bytes = drive.TotalFreeSpace;
                Console.WriteLine("{0} Bytes", drive.TotalFreeSpace);
                var kb = bytes / 1024;
                Console.WriteLine("{0} Kb's", kb);
                var mb = kb / 1024;
                Console.WriteLine("{0} Mb's", mb);
                var gb = mb / 1024;
                Console.WriteLine("{0} Gb's", gb);
                var tb = gb / 1024;
                Console.WriteLine("{0} Tb's", tb);

                Console.WriteLine();
            }
        }

        private static void HandleExceptions()
        {
            try
            {
                File.ReadAllText("anything.text");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.FileName);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UsingFileClass()
        {
            File.WriteAllText("File.txt", "Write text\n");

            File.AppendAllText("File.txt", "Append text\n");

            Console.WriteLine(File.ReadAllText("File.txt"));
        }
    }
}
