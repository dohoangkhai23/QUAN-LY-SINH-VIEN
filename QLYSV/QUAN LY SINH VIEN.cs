using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYSV
{
    public partial class QUAN_LY_SINH_VIEN : Form
    {
        public QUAN_LY_SINH_VIEN()
        {
            InitializeComponent();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new Khoa().ShowDialog();
        }

        private void QUAN_LY_SINH_VIEN_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmquanlysinhvien k = new frmquanlysinhvien();
            k.Show();
        }
    }
}
