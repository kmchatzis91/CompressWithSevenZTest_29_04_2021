using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenZipNET;
using System.IO;

namespace CompressWithSevenZTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            string sourceDirectory = "Source_Directory";
            string destinationDirectory = "Destination_Directory";
            #endregion

            SevenZHandle.InitSevenZHandle(sourceDirectory, destinationDirectory);

        } // END static void Main(string[] args)

    } // END class Program

} // END namespace CompressWithSevenZTest
