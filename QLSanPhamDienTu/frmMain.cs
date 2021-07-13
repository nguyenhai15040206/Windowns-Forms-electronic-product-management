using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

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
            phanQuyen(menuStrip1);
        }

        public void phanQuyen(MenuStrip menuStrip1)
        {
            List<int> nhomND = NguoiDungBUS.Instance.getMaNhomNguoiDung(1);

            foreach (int item in nhomND)
            {
                List<QL_PhanQuyen> dsQuyen = NguoiDungBUS.Instance.getMaManHinh(item);
                for (int i = 0; i < dsQuyen.Count; i++)
                {
                    FindMenuPhanQuyen(menuStrip1.Items, dsQuyen[i].maManHinh.ToString(), (bool)dsQuyen[i].coQuyen);
                }

            }
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {

                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, pScreenName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable; menu.Visible = pEnable;
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;
                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }
            return false;
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
            Form form = IstActive(typeof(frmProductManager));
            if (form == null)
            {
                frmProductManager frm = new frmProductManager();
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
