using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            lblKSeg1.Text = GetPathFile("KSeg1.txt");
        }
        private void btnSPSSeg1_Click(object sender, EventArgs e)
        {
            lblKSeg1.Text = GetPathFile("SPSSeg1.txt");
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

        private void ReadKSeg(string filePath)
        {
            string[] strings = File.ReadAllLines(filePath);
            
        }
    }
}
