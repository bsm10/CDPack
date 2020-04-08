using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CDPack.Helpers;

namespace CDPack
{
    public partial class FormCD : Form
    {
        FormDebug frmDebug;
        IProgress<int> progress;
        IProgress<string> progressTime;
        public FormCD()
        {
            InitializeComponent();
        }

        private void btnKSeg1_Click(object sender, EventArgs e)
        {
            lblKSeg1.Text = GetPathFile("CD.txt");
        }
        private void btnSPSSeg1_Click(object sender, EventArgs e)
        {
            lblKSeg1.Text = GetPathFile("*.txt");
        }

        private string GetPathFile(string fileName)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = PathFile.InitialDirectory;
                openFileDialog.Filter = $"{fileName} | {fileName}";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileName;
                else
                    return string.Empty;
            }
        }
        private string GetPathFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            else
                return "";
        }



        private void FormCD_Load(object sender, EventArgs e)
        {
            progress = new Progress<int>(percent =>
            {
                progressBarCD.Value = percent;
            });
            progressTime = new Progress<string>(time =>
            {
                lblProgress.Text = time;
            });

#if DEBUG
            lblFolderKseg.Text = @"c:\Users\user\source\repos\Archivator\KSin-Test\";
            lblUnpack.Text = @"c:\Users\user\source\repos\Archivator\KSin-Test\CD.dat";
#endif

            frmDebug = new FormDebug();
            //frmDebug.Show();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (lblKSeg1.Text == "") return;
            Archivator.CompressFile(lblKSeg1.Text);

            //string kseg1 = PackKSeg(lblKSeg1.Text);
            //string hex = "";
            //byte[] bte = File.ReadAllBytes(lblKSeg1.Text);
            //string fileText = File.ReadAllText(lblKSeg1.Text);
            //foreach (byte b in bte)
            //{
            //    hex += string.Format("{0:X2}", b);
            //}
            //string binToHex = kseg1.BinToHex();


            //frmDebug.txtKSeg1.Text = $"File:\r\n{fileText}" +
            //                         $"\r\nFile Hex: {hex} ({hex.Length/2} bytes)" +
            //                         $"\r\nBin: {kseg1} ({kseg1.Length} bits)\r\nHex: {binToHex} ({binToHex.Length/2}) bytes";
            //frmDebug.txtStringForUnpack.Text = binToHex;
            //frmDebug.txtUnpack.Text = UnPackKSeg(binToHex);
        }

        private void btnSelectFolderKSeg_Click(object sender, EventArgs e)
        {
            lblFolderKseg.Text = GetPathFolder();
        }

        private async void btnPackFolder_Click(object sender, EventArgs e)
        {
            
            if (lblFolderKseg.Text == "") return;
            //await Archivator.CompressFolderAsync(lblFolderKseg.Text);
            await PackFolderKSegAsync(lblFolderKseg.Text);
            //await GlueFilesKSeg(lblFolderKseg.Text);
            //PackFolderKSeg(lblFolderKseg.Text);
        }

        private async Task PackFolderKSegAsync(string folder)
        {
            string filename = "CD.dat";
            string[] files = Directory.GetFiles(folder, "Ks*.txt");
            string result = string.Empty;
            progressBarCD.Value = 0;
            progressBarCD.Minimum = 0;
            progressBarCD.Maximum = files.Length;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int i = 0;
            await Task.Run(() =>
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(folder, filename), FileMode.Create)))
                {
                    foreach (string file in files)
                    {
                        progress.Report(i);
                        progressTime.Report(sw.Elapsed.ToString());
                        if(i == 0)
                            writer.Write(PackKSin(Path.Combine(folder, file), true).BinToByte());
                        else
                            writer.Write(PackKSin(Path.Combine(folder, file)).BinToByte());
                        Console.WriteLine($"packing {file}");
                    }
                    Console.WriteLine($"Ok!");
                }
                //Archivator.CompressFile(Path.Combine(folder, filename));
            });
            sw.Stop();
            FileInfo fi = new FileInfo(Path.Combine(folder, filename));
            progressBarCD.Value = 0;
            lblProgress.Text = $"Готово! Обработано файлов: {i}. Итоговый файл {filename}: {fi.Length / 1000f} kb. Время: {sw.Elapsed}";

        }

        private async Task UnPackKSinAsync(string filename)
        {
            string result = string.Empty;
            FileInfo fi = new FileInfo(filename);
            DirectoryInfo diNew =  Directory.CreateDirectory(fi.DirectoryName + @"\pck");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int i = 0;
            await Task.Run(() =>
            {
                string lastY = string.Empty;
                BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open));
                // пока не достигнут конец файла считываем каждое значение из файла
                while (reader.PeekChar() > -1)
                {
                    if(i == 0)//первая точка с нулем: 0 -132560 - 32 + 40 bit  
                    {
                        //
                        byte[] arr = reader.ReadBytes(10);
                        string binaryString = string.Join("", Enumerable.Range(0, arr.Length).Select(j =>
                                Convert.ToString(arr[j], 2).PadLeft(8, '0')));
                        Console.WriteLine(binaryString.Length);
                        string Y0 = GetCoordinateFromBin(binaryString.Substring(15, 25));
                        string X = GetCoordinateFromBin(binaryString.Substring(40, 15));
                        string Y = GetCoordinateFromBin(binaryString.Substring(55, 25));
                        lastY = "0 {Y}";
                        i++;
                        string filenameUnpack = Path.Combine(diNew.FullName, $"KSin{i}.txt");
                        File.WriteAllText(filenameUnpack, $"0 {Y0}\r\n{X} {Y}");
                        
                        continue;
                    }
                    if (reader.ReadByte() == 0x0) // 5 byte -> 40 bit (15 bit X; 25 bit Y)
                    {
                        //считываем байты и конвертируем в двоичное число, которое потом конвертируем в координаты Х и У
                        byte[] arr = reader.ReadBytes(5);
                        string byteString = string.Join("", Enumerable.Range(0, arr.Length).Select(j =>
                                Convert.ToString(arr[j], 2).PadLeft(8, '0')));
                        byteString.ToStringKsegXY();
                        // и записываем в файл с предыдущей координатой У

                    }
                    else // 10 byte
                    {

                    }
                    i++;
                }
                reader.Close();
                
            });
            sw.Stop();
        }

        private static string GetCoordinateFromBin(string binaryString)
        {
            string coordinate = binaryString.Substring(1).BinToDec().ToString();
            return binaryString.Substring(0, 1).BinToDec() == "1" ? "-" + coordinate : coordinate;
        }

        private async Task GlueFilesKSeg(string folder)
        {
            string filename = "CD.txt";
            try
            {
                string[] files = Directory.GetFiles(folder, "KSin*.txt").OrderBy(x => x, new ComparerFileNames()).ToArray();
                string result = string.Empty;
                int i = 0;
                progressBarCD.Value = 0;
                progressBarCD.Minimum = 0;
                progressBarCD.Maximum = files.Length;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                await Task.Run(() =>
                {
                    List<string> list = new List<string>();
                    foreach (string file in files)
                    {
                        progress.Report(i);
                        progressTime.Report(sw.Elapsed.ToString());

                        string[] strings = File.ReadAllLines(Path.Combine(folder, file));
                        
                        list.AddRange(strings);
                        //result += KSeg(Path.Combine(folder, file));
                        Console.WriteLine($"add {file}");
                        i++;
                    }
                    Console.WriteLine($"Ok! File contains {list.Count} lines");
                    File.WriteAllText(Path.Combine(folder, filename), string.Join("\r\n", list));

                });
                sw.Stop();
                FileInfo fi = new FileInfo(Path.Combine(folder, filename));
                progressBarCD.Value = 0;
                lblProgress.Text = $"Готово! Обработано файлов: {i}. Итоговый файл {filename}: {fi.Length / 1000f} kb. Время: {sw.Elapsed}";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDebug.Show();
        }

        public class ComparerFileNames : IComparer<string>
        {
            /// <returns>1 if the first value 
            /// is greater than the second value,
            /// -1 if the first value is less than the second value
            public int Compare(string s1, string s2)
            {
                int num1 = int.Parse(Path.GetFileNameWithoutExtension(s1).Substring(4));
                int num2 = int.Parse(Path.GetFileNameWithoutExtension(s2).Substring(4));
                if (num1 == num2)
                    return 0;
                else if (num1 > num2)
                    return 1;
                else
                    return -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblKSeg1.Text == "") return;
        }

        private async void btnUnpack_Click(object sender, EventArgs e)
        {
            await UnPackKSinAsync(lblUnpack.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblUnpack.Text = GetPathFile("CD.dat");
        }
    }
}
