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

        private string PackKSeg(string filePath)
        {
            string[] strings = File.ReadAllLines(filePath);
            List<string[]> list = new List<string[]>();
            string result = string.Empty;
            foreach (string line in strings)
            {
                string[] point = new string[2];
                point = line.Split(' ');
                if(point[0] != "0")
                {
                    result += point[0].ToKsegX() + point[1].ToKsegY();
                }
                else
                {
                    result += point[1].ToKsegY();
                }
                
                //list.Add(line.Split(' '));
            }

            ////2 points
            //if(list.Count > 2)
            //{

            //}
            //else//1points
            //{
            //    if (list[0][0] == "0")
            //    {
            //        result = $"{list[0][1].ToKsegY()}{list[1][0].ToKsegX()}{list[1][1].ToKsegY()}";
            //    }
            //    else
            //    {
            //        result = $"{list[0][0].ToKsegX()}{list[0][1].ToKsegY()}{ list[1][0].ToKsegX()}{list[1][1].ToKsegY()}";
            //    }
            //}
#if DEBUG
            string hex = "";
            byte[] bte = File.ReadAllBytes(filePath);
            for (int i = 0; i < bte.Length; i++)
            {
                hex += string.Format("{0:X2}", bte[i]);
            }
            frmDebug.txtKSeg1.Text = $"File:\r\n{strings[0]}\r\n{strings[1]}" +
                                     $"\r\nFile Hex: {hex}" +
                                     $"\r\nBin: {result}\r\nHex: {result.BinToHex()}";
            //$"\r\nBin: {result}\r\nHex: {result.Substring(2).BinToHex()}";
#endif
            return result;
        }
        private string UnPackKSeg(string filePath)
        {
            string[] strings = File.ReadAllLines(filePath);
            List<string[]> list = new List<string[]>();
            string result = string.Empty;
            foreach (string line in strings)
            {
                list.Add(line.Split(' '));
            }
            //2 points
            if(list.Count > 2)
            {

            }
            else//1points
            {
                if (list[0][0] == "0")
                {
                    result = $"{list[0][1].ToKsegY()}{list[1][0].ToKsegX()}{list[1][1].ToKsegY()}";
                }
                else
                {
                    result = $"{list[0][0].ToKsegX()}{list[0][1].ToKsegY()}{ list[1][0].ToKsegX()}{list[1][1].ToKsegY()}";
                }
            }
#if DEBUG
            string hex = "";
            byte[] bte = File.ReadAllBytes(filePath);
            for (int i = 0; i < bte.Length; i++)
            {
                hex += string.Format("{0:X2}", bte[i]);
            }
            frmDebug.txtKSeg1.Text = $"File:\r\n{strings[0]}\r\n{strings[1]}" +
                                     $"\r\nFile Hex: {hex}" +
                                     $"\r\nBin: {result}\r\nHex: {result.Substring(2).BinToHex()}";
#endif
            return result;
        }



        private void btnExecute_Click(object sender, EventArgs e)
        {
            string kseg1 = PackKSeg(lblKSeg1.Text);
            
        }
    }
}
