using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bailamkt
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_DangKy"] == null)
            {
                frm_DangKy d = new frm_DangKy();
                d.MdiParent = this;
                d.Show();
            }
            else Application.OpenForms["frm_DangKy"].Activate();
        }
    }
}
