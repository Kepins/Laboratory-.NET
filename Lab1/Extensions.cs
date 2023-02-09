using System;
using System.IO;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab1
{
    public static class Extensions
    {
        public static DateTime? GetOldestCreationTime(this DirectoryInfo di)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            DateTime? currentOldest = null;
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
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Log.Information(e.Message);
            }
            if (files != null)
            {
                foreach(FileInfo file in files)
                {
                    if(currentOldest != null && file.CreationTime < currentOldest)
                    {
                        currentOldest = file.CreationTime;
                    }
                    else if(currentOldest == null)
                    {
                        currentOldest = file.CreationTime;
                    }
                }
            }
            if(subDirs != null)
            {
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    DateTime? oldestFromDir = dirInfo.GetOldestCreationTime();
                    if (oldestFromDir != null)
                    {
                        if (currentOldest != null && oldestFromDir < currentOldest)
                        {
                            currentOldest = oldestFromDir;
                        }
                        else if (currentOldest == null)
                        {
                            currentOldest = oldestFromDir;
                        }
                    }
                }
            }
            return currentOldest;
        }

        public static string GetRahs(this FileSystemInfo fsi)
        {
            string output = "";

            FileAttributes fileAttributes = fsi.Attributes;

            output+=((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) ? "r" : "-";
            output+=((fileAttributes & FileAttributes.Archive) == FileAttributes.Archive) ? "a" : "-";
            output+=((fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden) ? "h" : "-";
            output+=((fileAttributes & FileAttributes.System) == FileAttributes.System) ? "s" : "-";

            return output;
        }
    }
}
