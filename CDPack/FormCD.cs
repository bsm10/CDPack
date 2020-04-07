using System;
using System.IO;
using System.Windows.Forms;
using static CDPack.Helpers;

namespace CDPack
{
    public partial class FormCD : Form
    {
        FormDebug frmDebug;
        public FormCD()
        {
            InitializeComponent();
        }

        private void btnKSeg1_Click(object sender, EventArgs e)
        {
            lblKSeg1.Text = GetPathFile("KSeg*.txt");
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

        private void FormCD_Load(object sender, EventArgs e)
        {
            frmDebug = new FormDebug();
            frmDebug.Show();
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
    }
}
