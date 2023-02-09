using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTasks
{
    static class Compressor
    {
        public static void Compress(DirectoryInfo dir)
        {
            FileInfo[] files = null;
            try
            {
                // First, process all the files directly under this folder
                files = dir.GetFiles("*.*");
            }

            catch (UnauthorizedAccessException e)
            {
                return;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                return;
            }

            Parallel.ForEach(files, file =>
            {
                FileAttributes fa = file.Attributes;
                if (file.Extension != ".gz" && !((fa & FileAttributes.ReadOnly) == FileAttributes.ReadOnly))
                {
                    using (FileStream originalFileStream = File.Open(file.FullName, FileMode.Open))
                    {
                        using (FileStream compressedFileStream = File.Create(file.FullName + ".gz"))
                        {
                            using (var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressor);
                            }
                        }
                    }
                }
            });
        }

        public static void Decompress(DirectoryInfo dir)
        {
            FileInfo[] files = null;
            try
            {
                // First, process all the files directly under this folder
                files = dir.GetFiles("*.gz");
            }

            catch (UnauthorizedAccessException e)
            {
                return;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                return;
            }

            Parallel.ForEach(files, file =>
            {
                FileInfo newFile = new FileInfo(file.FullName.Substring(0, file.FullName.Length - 3));
                if (!newFile.Exists)
                {
                    using (FileStream compressedFileStream = File.Open(file.FullName, FileMode.Open))
                    {



                        using (FileStream decompressedFileStream = File.Create(newFile.FullName))
                        {
                            using (var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                            {
                                decompressor.CopyTo(decompressedFileStream);
                            }
                        }
                    }
                }
            });

        }
    }
}
