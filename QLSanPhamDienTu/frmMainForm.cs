using BUS;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
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
    public partial class frmMainForm : Form
    {
        public static int maND;
        public delegate void sendData(string value);
        public sendData thongTinNguoiDung;
        public sendData maNguoiDung;
        public frmMainForm()
        {
            InitializeComponent();
            thongTinNguoiDung = new sendData(getTTNguoiDung);
            maNguoiDung = new sendData(getMaNguoiDung);
            //WindowState = FormWindowState.Maximized;
            
        }

        public void getTTNguoiDung(string ttNguoiDung)
        {
            this.Text = "Phần mềm quản lý sản phẩm điện tử. Xin chào!   " + ttNguoiDung;
        }
        public void getMaNguoiDung(string maNguoiDung)
        {
            maND = int.Parse(maNguoiDung.Trim());
            CategoryScreenAndPermissionBUS.Instance.phanQuyen(menuStrip1, maND);
        }
        private Form IstActive(Type type)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == type)
                {
                    return f;
                }
            }
            return null;
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            tabbedView1.DocumentAdded += TabbedView1_DocumentAdded1;
        }

        private void TabbedView1_DocumentAdded1(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            ((Document)tabbedView1.Documents[tabbedView1.Documents.Count - 1]).Appearance.Header.BackColor = Color.SeaShell;
        }

        private void menuItemPhanQuyen_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmScreenAndPermission));
            if (form == null)
            {
                frmScreenAndPermission frm = new frmScreenAndPermission();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void menuItemPayCart_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmPayCartManager));
            if (form == null)
            {
                frmPayCartManager frm = new frmPayCartManager();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void menuItemInvoiceManager_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmInvoice));
            if (form == null)
            {
                frmInvoice frm = new frmInvoice();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void menuItemCustomerManager_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmCustomerManager));
            if (form == null)
            {
                frmCustomerManager frm = new frmCustomerManager();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void menuItemNewsManager_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmNewsAndBannerManager));
            if (form == null)
            {
                frmNewsAndBannerManager frm = new frmNewsAndBannerManager();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void menuItemProductManager_Click(object sender, EventArgs e)
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

        private void menuItemGoodsRevriveNote_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmInsertProductBySupplier));
            if (form == null)
            {
                frmInsertProductBySupplier frm = new frmInsertProductBySupplier();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void menuItemSupplierManager_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmInsertCategoryAndSupplier));
            if (form == null)
            {
                frmInsertCategoryAndSupplier frm = new frmInsertCategoryAndSupplier();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
    }
}
