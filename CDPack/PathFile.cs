using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPack
{
    class PathFile
    {
        public const string OutFileName = "ohb.xml";
        //public const string ConvertedFileName = "ohb_conv.xml";

        public static string PathToOutYmlFile { get; set; } =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), OutFileName);
        
        public static string InitialDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    }
}
