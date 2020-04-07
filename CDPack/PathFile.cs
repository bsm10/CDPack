using System;
using System.IO;

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
