using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            lblKSeg1.Text = GetPathFile("KS*.txt");
        }
        private void btnSPSSeg1_Click(object sender, EventArgs e)
        {
            lblKSeg1.Text = GetPathFile("SPSSeg*.txt");
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

            
            frmDebug = new FormDebug();
            //frmDebug.Show();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (lblKSeg1.Text == "") return;
            string kseg1 = PackKSeg(lblKSeg1.Text);
            string hex = "";
            byte[] bte = File.ReadAllBytes(lblKSeg1.Text);
            string fileText = File.ReadAllText(lblKSeg1.Text);
            foreach (byte b in bte)
            {
                hex += string.Format("{0:X2}", b);
            }
            string binToHex = kseg1.BinToHex();
            frmDebug.txtKSeg1.Text = $"File:\r\n{fileText}" +
                                     $"\r\nFile Hex: {hex} ({hex.Length/2} bytes)" +
                                     $"\r\nBin: {kseg1} ({kseg1.Length} bits)\r\nHex: {binToHex} ({binToHex.Length/2}) bytes";
            frmDebug.txtStringForUnpack.Text = binToHex;
            frmDebug.txtUnpack.Text = UnPackKSeg(binToHex);
        }

        private void btnSelectFolderKSeg_Click(object sender, EventArgs e)
        {
            lblFolderKseg.Text = GetPathFolder();
        }

        private async void btnPackFolder_Click(object sender, EventArgs e)
        {
            if (lblFolderKseg.Text == "") return;
            await GlueFilesKSeg(lblFolderKseg.Text);
            //PackFolderKSeg(lblFolderKseg.Text);
        }

        private void PackFolderKSeg(string folder)
        {
            string[] files = Directory.GetFiles(folder);
            string result = string.Empty;

            foreach (string file in files)
            {
                result += PackKSeg(Path.Combine(folder, file));
                Console.WriteLine($"packing {file}");
            }
            Console.WriteLine($"Ok!");
            File.WriteAllText(Path.Combine(folder, "result.dat"), result);
        }
        private async Task GlueFilesKSeg(string folder)
        {
            try
            {
                string[] files = Directory.GetFiles(folder, "*.txt");
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
                    File.WriteAllText(Path.Combine(folder, "Kseg.dat"), string.Join("\r\n", list));

                });
                sw.Stop();
                FileInfo fi = new FileInfo(Path.Combine(folder, "Kseg.dat"));
                progressBarCD.Value = 0;
                lblProgress.Text = $"Готово! Обработано файлов: {i}. Итоговый файл: {fi.Length / 1000f} kb. Время: {sw.Elapsed}";

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
    }
}
