using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CDPack.Helpers;

namespace CDPack
{
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
        }

        private void btnUnpack_Click(object sender, EventArgs e)
        {
            txtUnpack.Text = UnPackKSeg(txtStringForUnpack.Text);
        }
    }
}
