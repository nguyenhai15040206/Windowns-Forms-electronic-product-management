using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSanPhamDienTu
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
        }

        private void menuTTNhanVien_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmQLNhanVienPhanQuyen));
            if(form == null)
            {
                frmQLNhanVienPhanQuyen frm = new frmQLNhanVienPhanQuyen();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private Form IstActive(Type type)
        {
            foreach(Form f in this.MdiChildren)
            {
                if(f.GetType() == type)
                {
                    return f;
                }
            }
            return null;
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmQLSanPham));
            if (form == null)
            {
                frmQLSanPham frm = new frmQLSanPham();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }
    }
}
