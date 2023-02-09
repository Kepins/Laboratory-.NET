using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Csharp_Lab1
{
    class Program
    {
        private static string indentationString = "\t";
        static void Main(string[] args)
        {
            string rootDirStr = args[0];

            DirectoryInfo rootDir = new DirectoryInfo(rootDirStr);
            WalkDirectoryTree(rootDir);
            Console.WriteLine("Najstarszy plik: " + rootDir.GetOldestCreationTime());

            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, GetSizesFromDirectory(rootDir));
            stream.Position = 0;
            var dict = (SortedDictionary<string, long>)formatter.Deserialize(stream);

            stream.Close();
            foreach (var pair in dict)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }

        static void WalkDirectoryTree(DirectoryInfo di, string indentation = "")
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                // First, process all the files directly under this folder
                files = di.GetFiles("*.*");

                // Now find all the subdirectories under this directory.
                subDirs = di.GetDirectories();
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Log.Information(e.Message);
                return;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Log.Information(e.Message);
                return;
            }
            int sizeOfFile = subDirs.Length + files.Length;
            Console.WriteLine(indentation + di.Name + " (" + sizeOfFile +") "+ di.GetRahs());
            indentation += indentationString;

            foreach (System.IO.FileInfo fi in files)
            {
                // Access files
                Console.WriteLine(indentation + fi.Name + " " + fi.Length + " bajtow " + fi.GetRahs());
            }
            

            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                // Resursive call for each subdirectory.
                WalkDirectoryTree(dirInfo, indentation);
            }
        }

        static SortedDictionary<string, long> GetSizesFromDirectory(DirectoryInfo di)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                // First, process all the files directly under this folder
                files = di.GetFiles("*.*");
                var dict = new SortedDictionary<string, long>(new comparerLengthString());
                foreach(FileInfo file in files)
                {
                    dict.Add(file.Name, file.Length);
                }
                subDirs = di.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    int length = 0;
                    foreach(FileSystemInfo fsi in dirInfo.GetFileSystemInfos())
                    {
                        length++;
                    }

                    dict.Add(dirInfo.Name, length);
                }
                return dict;
            }
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Log.Information(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Log.Information(e.Message);
            }
            return null;
        }

        [Serializable]
        class comparerLengthString : IComparer<string>
        {
            int IComparer<string>.Compare(string x, string y)
            {
                if(x.Length != y.Length)
                {
                    return x.Length - y.Length;
                }
                return x.CompareTo(y);
            }
        }
    }
}
