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
using DevExpress.XtraEditors;

namespace QLSanPhamDienTu
{
    public partial class frmLogin : Form
    {

        public string thongTinND = "";
        public int maNguoiDung = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
                this.txtUserName.Focus();
                return;
            }
            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                this.txtPassword.Focus();
                return;
            }
            int kq = UserBUS.Instance.checkConfig();
            if(kq==0) // chuỗi cấu hình phù hợp
            {
                ProcessLogin(); // cấu hình phù hợp xử lý đăng nhập
            }    
            if(kq==1)
            {
                // chuổi cấu hình không phù hợp
                // xử lý cấu hình
                MessageBox.Show("Chuỗi cấu hình không tồn tại");
                ProcessConfig();
            }  
            if(kq==2)
            {
                // xử lý cấu hình
                MessageBox.Show("Chuỗi cấu hình không phù hợp");
                ProcessConfig();
            }    
        }

        public void ProcessConfig()
        {
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
            this.Hide();
        }
        public void ProcessLogin()
        {
            try
            {
                    if (UserBUS.Instance.dangNhapHeThong(txtUserName.Text.Trim(), txtPassword.Text.Trim()) == 300)
                    {
                        this.DialogResult = DialogResult.OK;
                        maNguoiDung = UserBUS.Instance.maNguoiDung(txtUserName.Text.Trim());
                        thongTinND = UserBUS.Instance.thongTinNguoiDung(txtUserName.Text.Trim());
                        Program.mainForm = null;
                        if (Program.mainForm == null || Program.mainForm.IsDisposed)
                        {
                            Program.mainForm = new frmMain();
                            Program.mainForm.thongTinNguoiDung(Program.frm.thongTinND);
                            Program.mainForm.maNguoiDung(Convert.ToString(Program.frm.maNguoiDung));
                        }
                        Program.frm.Visible = false;
                        Program.mainForm.Show();
                    }
                    if (UserBUS.Instance.dangNhapHeThong(txtUserName.Text.Trim(), txtPassword.Text.Trim()) == 200)
                    {
                        XtraMessageBox.Show("Tài khoản không khả dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (UserBUS.Instance.dangNhapHeThong(txtUserName.Text.Trim(), txtPassword.Text.Trim()) == 100)
                    {
                        XtraMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUserName.Focus();
                    }
            }
            catch
            {
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
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

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
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
