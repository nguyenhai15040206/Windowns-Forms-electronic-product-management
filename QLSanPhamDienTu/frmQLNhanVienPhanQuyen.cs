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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace QLSanPhamDienTu
{
    public partial class frmQLNhanVienPhanQuyen : Form
    {
        public frmQLNhanVienPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmQLNhanVienPhanQuyen_Load(object sender, EventArgs e)
        {
            NguoiDungBUS.Instance.loadNhomNguoiDung(treeViewNguoiDung);
            NguoiDungBUS.Instance.loadNguoiDung(gridContrrolNguoiDung);
        }

        private void menuItemClean_Click(object sender, EventArgs e)
        {
            txtMatKhau.ReadOnly = false;
        }

        private void menuItemThem_Click(object sender, EventArgs e)
        {
            if (NguoiDungBUS.Instance.themNguoiDung(txtTenNguoiDung.Text.Trim(), txtTenDangNhap.Text.Trim(), txtMatKhau.Text,
                txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text, dateTimePickerNgayVL.Value, true))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                // thêm thất bại
            }
        }
    }
}
