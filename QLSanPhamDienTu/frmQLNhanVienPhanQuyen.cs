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
        int maNhom = 0;
        int row = -1;
        int rowMaNDNhom = -1;
        public frmQLNhanVienPhanQuyen()
        {
            InitializeComponent();
            maNhom = NguoiDungBUS.Instance.layMaNHomNguoiDungDauTien();
        }
        public void loadLaiForm()
        {
            NguoiDungBUS.Instance.loadNguoiDungChuaCoNhom(gridControl2);
            NguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), gridControl3);
            NguoiDungBUS.Instance.loadNhomNguoiDung(treeViewNguoiDung);
            rowMaNDNhom = -1;
            row = -1;
        }
        private void frmQLNhanVienPhanQuyen_Load(object sender, EventArgs e)
        {
            // load nhóm người dùng lên treeList
            NguoiDungBUS.Instance.loadNhomNguoiDung(treeViewNguoiDung);

            // load nhóm người dùng lên combobox
            NguoiDungBUS.Instance.loadDSNhomNguoiDungComboBox(cboNhomNguoiDung);

            // load tất cả người dùng
            NguoiDungBUS.Instance.loadNguoiDung(gridContrrolNguoiDung);

            // laod ds người dùng chưa có nhóm
            NguoiDungBUS.Instance.loadNguoiDungChuaCoNhom(gridControl2);

            // load người dùng có mã nhóm đầu tiên
            NguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControl3);

            // load danh mục màn hình lên treeList
            DanhMucManHinhPhanQuyenBUS.Instance.loadDanhMucManHinh(treeListManHinh);


            // load nhóm người dùng lên gridControl
            NguoiDungBUS.Instance.loadNhomNguoiDung_GridCOntrol(gridControlQLNhomND);
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


        private void btnADD_Click(object sender, EventArgs e)
        {
            if(row==-1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên thêm vào nhóm!");
            }     
            else
            {
                if (NguoiDungBUS.Instance.themNguoiDungVaoNhom(row, int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), ""))
                {
                    MessageBox.Show("Thêm người dùng vào nhóm thành công!");
                    loadLaiForm();
                }
            }    
        }

        private void gridViewnguoiDungChuaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            row = int.Parse(gridViewnguoiDungChuaCoNhom.GetRowCellValue(gridViewnguoiDungChuaCoNhom.FocusedRowHandle, gridColumn3).ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(rowMaNDNhom == -1)
            {
                MessageBox.Show("Vui lòng chọn người dùng loại khỏi nhóm!");
            }    
            else
            {
                if (NguoiDungBUS.Instance.xoaNguoiDungRaKhoiNhom(rowMaNDNhom, int.Parse(cboNhomNguoiDung.SelectedValue.ToString())))
                {
                    MessageBox.Show("Loại người dùng ra khỏi nhóm thành công!");
                    loadLaiForm();
                }

            }    
        }

        private void gridViewNguoiDungDaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowMaNDNhom = int.Parse(gridViewNguoiDungDaCoNhom.GetRowCellValue(gridViewNguoiDungDaCoNhom.FocusedRowHandle, gridColumn10).ToString());
        }

        private void cboNhomNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), gridControl3);
                row = -1;
                rowMaNDNhom = -1;
            }
            catch
            {
                NguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControl3);
            }
        }

        private void gridView6_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            // load danh sách quyền chức năng
            try
            {
                int maNhom = int.Parse(gridView6.GetRowCellValue(gridView6.FocusedRowHandle, gridColumn29).ToString());
                DanhMucManHinhPhanQuyenBUS.Instance.loadDanhSachQuyenChucNang(gridControl6, maNhom);
            }
            catch
            {
                return;
            }
        }
    }
}
