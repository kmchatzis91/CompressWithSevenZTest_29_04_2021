using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenZipNET;

namespace CompressWithSevenZTest
{
	class SevenZHandle
	{
        public static void InitSevenZHandle(string sourceDirectory, string destinationDirectory) 
        {
            #region Variables
            string date = DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss");
            string sevenZipName = "7z_Result_" + date;           
            string sevenZDirectory = Path.Combine(destinationDirectory, sevenZipName);
            var allCsvLstBinFiles = Directory.EnumerateFiles(sourceDirectory)
                .Where(file => file.ToLower().EndsWith("csv") || file.ToLower().EndsWith("lst") || file.ToLower().EndsWith("bin"))
                .ToList();
            #endregion

            CheckIfDirectoryExistsElseCreate(sevenZDirectory);
            CreateDirectoryWithSelectedFiles(sourceDirectory, sevenZDirectory, allCsvLstBinFiles);
            CompressGivenDirectory(sevenZDirectory);
            KeepOnlyCompressedDirectory(sevenZDirectory);

        } // END public static void InitSevenZHandle()

        private static void KeepOnlyCompressedDirectory(string sevenZDirectory)
        {
            Directory.Delete(sevenZDirectory, true);

        } // END private static void KeepOnlyCompressedDirectory(string sevenZDirectory)

        private static void CompressGivenDirectory(string sevenZDirectory)
        {
            SevenZipCompressor sevenZipCompressor = new SevenZipCompressor(sevenZDirectory);
            sevenZipCompressor.CompressDirectory(sevenZDirectory, CompressionLevel.Normal);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n All Files are compressed! \n");
            Console.ForegroundColor = ConsoleColor.White;

        } // END private static void CompressGivenDirectory(string sevenZDirectory)

        private static void CreateDirectoryWithSelectedFiles(string sourceDirectory, string sevenZDirectory, IEnumerable<string> allCsvLstBinFiles)
        {
            foreach (var csvLstBinFile in allCsvLstBinFiles)
            {
                FileInfo infoCsvLstBinFile = new FileInfo(csvLstBinFile);
                string file = Path.Combine(sourceDirectory, infoCsvLstBinFile.Name);
                string movedFile = Path.Combine(sevenZDirectory, infoCsvLstBinFile.Name);
                File.Move(file, movedFile);
            }

        } // END private static void CreateDirectoryWithSelectedFiles(string sourceDirectory, string sevenZDirectory, IEnumerable<string> allCsvLstFiles)

        private static void CheckIfDirectoryExistsElseCreate(string sevenZDirectory)
        {
            bool directoryExists = Directory.Exists(sevenZDirectory);

            if (!directoryExists)
            {
                Directory.CreateDirectory(sevenZDirectory);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Directory ' {0} ' created!", sevenZDirectory);
                Console.ForegroundColor = ConsoleColor.White;
            }

        } // END private static void CheckIfDirectoryExistsElseCreate(string sevenZDirectory)

    } // END class SevenZHandle

} // END namespace CompressWithSevenZTest
