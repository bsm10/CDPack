using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CDPack
{
    public static class Archivator
    {
        public static void CompressFiles(string directoryPath)
        {
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionLevel.Optimal))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                        FileInfo info = new FileInfo(directoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                        Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                    }
                }
            }
        }
        public static void CompressFile(string filePath)
        {
            
            FileInfo fileToCompress = new FileInfo(filePath);
            
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) &
                   FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                           CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                        //using (DeflateStream compressionStream = new DeflateStream(compressedFileStream, CompressionMode.Compress))
                        //{
                        //    originalFileStream.CopyTo(compressionStream);
                        //}
                    }
                    //FileInfo info = new FileInfo(directoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                    //Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                }
            }

        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                    }
                }
            }
        }

        public static void DecompressFolder(string directoryPath)
        {
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Decompress(fileToDecompress);
            }
        }

    }
}
