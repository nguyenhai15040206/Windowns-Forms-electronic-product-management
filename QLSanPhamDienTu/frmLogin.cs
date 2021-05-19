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

namespace QLSanPhamDienTu
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
                this.txtTenDN.Focus();
                return;
            }
            if(string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                this.txtMatKhau.Focus();
                return;
            }
            int kq = NguoiDungBUS.Instance.checkConfig();
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
        }
        public void ProcessLogin()
        {
            if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 300)
            {
                this.DialogResult = DialogResult.OK;
            }
            if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 200)
            {
                MessageBox.Show("Tài khoản không khả dụng");
            }
            if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 100)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
    }
}
