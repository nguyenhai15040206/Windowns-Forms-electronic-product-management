using DevExpress.XtraEditors;
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
    public partial class change_Password : DevExpress.XtraEditors.XtraForm
    {
        public change_Password()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPass.Text.Trim().Length > 0 && txtOldPass.Text.Trim().Length > 0 && txtReNewsPass.Text.Trim().Length > 0)
            {
                if (UserBUS.Instance.KiemTraTenDangNhapPass(frmMainForm.maND,txtOldPass.Text))
                {
                    if (txtNewPass.Text.Trim() == txtReNewsPass.Text.Trim())
                    {
                        if (UserBUS.Instance.doiMatKhau(frmMainForm.maND, txtNewPass.Text))
                        {
                            XtraMessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Mật khẩu không khớp");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập sai!");
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
                //txtTenDN.Focus();
            }
        }
    }
}