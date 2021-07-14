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
using DevExpress.XtraEditors;

namespace QLSanPhamDienTu
{
    public partial class frmScreenAndPermission : Form
    {
        int row = -1, rowMaNDNhom = -1;
        int maNhom = 0;
        int maNhomPhanQuyen = 0;
        int maManHinh = 0;
        bool hoatDong = true;
        bool coQuyen = true;
        public frmScreenAndPermission()
        {
            InitializeComponent();
            maNhom = UserBUS.Instance.layMaNHomNguoiDungDauTien();
        }
        private void frmQLNhanVienPhanQuyen_Load(object sender, EventArgs e)
        {
            // load nhóm người dùng
            UserBUS.Instance.loadNhomNguoiDung(treeListNguoiDUng);
            // load nhóm người dùng lên comBoBox
            UserBUS.Instance.loadDSNhomNguoiDungComboBox(cboNhomNguoiDung);
            // load tất cả người dùng còn hoạt động
            UserBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);

            // laod ds người dùng chưa có nhóm
            UserBUS.Instance.loadNguoiDungChuaCoNhom(gridControlNguoiDungChuaCoNhom);

            // load người dùng có mã nhóm đầu tiên
            UserBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControlNDCoNhom);

            UserBUS.Instance.loadDSNhomNguoiDung_GridControl(gridControlQLNhomND);

            UserBUS.Instance.loadDanhMucManHinh(treeList2);
        }

        private void gridViewDSNDPhanQuyen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            // load danh sách quyền chức năng
            try
            {
                maNhomPhanQuyen = int.Parse(gridViewDSNDPhanQuyen.GetRowCellValue(gridViewDSNDPhanQuyen.FocusedRowHandle, gridColumn29).ToString());
                UserBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyenDmanHinh, maNhomPhanQuyen);
            }
            catch
            {
                return;
            }
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            txtMatKhau.ReadOnly = false;
            txtTenDangNhap.ReadOnly = false;
            toolStripButtonLuuND.Enabled = true;
            toolStripButtonCapNhat.Enabled = false;
            foreach (Control item in panel8.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
            txtTenNguoiDung.Focus();
        }

        private void toolStripButtonLuuND_Click(object sender, EventArgs e)
        {
            if (txtTenNguoiDung.Text.Trim().Length > 0 && txtTenDangNhap.Text.Trim().Length > 0 && txtMatKhau.Text.Trim().Length > 0 && txtDiaChi.Text.Trim().Length > 0 &&
                txtSoDienThoai.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0)
            {
                if (CheckDataInput.Instances.isContainSpace(txtTenDangNhap.Text.Trim()) && CheckDataInput.Instances.isContainSpace(txtMatKhau.Text.Trim()))
                {
                    if (CheckDataInput.Instances.isPhoneNumber(txtSoDienThoai.Text))
                    {
                        if (CheckDataInput.Instances.isEmail(txtEmail.Text.Trim()))
                        {
                            if (UserBUS.Instance.KiemTraTenDangNhap(txtTenDangNhap.Text.Trim()) == false)
                            {
                                if (UserBUS.Instance.kiemTraSoDienThoai(txtSoDienThoai.Text.Trim()))
                                {
                                    if (UserBUS.Instance.themNguoiDung(txtTenNguoiDung.Text.Trim(), txtTenDangNhap.Text.Trim(), txtMatKhau.Text,
                                    txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text, dateTimePickerNgayVL.Value, hoatDong))
                                    {
                                        XtraMessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        UserBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                                        toolStripButtonLuuND.Enabled = false;
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtSoDienThoai.Focus();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Tên đăng nhập đã tồn tại vui lòng nhập tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTenDangNhap.Focus();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Nhập sai định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhập sai định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoDienThoai.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không chứa khoản trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguoiDung.Focus();
            }
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked == true)
            {
                hoatDong = true;
                UserBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                cbStatus.Text = "Hoạt động";
            }
            else
            {
                hoatDong = false;
                UserBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                cbStatus.Text = "Không hoạt động";
            }
        }

        private void toolStripButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenNguoiDung.Text.Trim().Length > 0 && txtDiaChi.Text.Trim().Length > 0 &&
                txtSoDienThoai.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0)
            {
                if (CheckDataInput.Instances.isPhoneNumber(txtSoDienThoai.Text))
                {
                    if (CheckDataInput.Instances.isEmail(txtEmail.Text.Trim()))
                    {
                        if (UserBUS.Instance.capNhatNhanVien(int.Parse(txtMaNguoiDung.Text.Trim()), txtTenNguoiDung.Text.Trim(),
                            txtDiaChi.Text.Trim(), txtSoDienThoai.Text.Trim(), txtEmail.Text.Trim(), hoatDong))
                        {
                            XtraMessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UserBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                        }
                        else
                        {
                            XtraMessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSoDienThoai.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhập sai định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Nhập sai định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDienThoai.Focus();

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguoiDung.Focus();
            }
        }

        private void gridView7_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            maManHinh = int.Parse(gridView7.GetRowCellValue(e.RowHandle, gridColumnMaMnHinh).ToString());
                //coQuyen = bool.Parse(gridView7.GetRowCellValue(e.RowHandle, gridColumnCoQuyen).ToString()) == null ? false : bool.Parse(gridView7.GetRowCellValue(e.RowHandle, gridColumnCoQuyen).ToString());
                coQuyen = bool.Parse(gridView7.GetRowCellValue(e.RowHandle, gridColumnCoQuyen).ToString());
            
        }

        private void gridView7_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumnCoQuyen")
            {
                if (coQuyen == true)
                {
                    UserBUS.Instance.phanQuyen(maNhomPhanQuyen, maManHinh, false);
                    UserBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyenDmanHinh, maNhomPhanQuyen);
                }
                else
                {
                    UserBUS.Instance.phanQuyen(maNhomPhanQuyen, maManHinh, true);
                    UserBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyenDmanHinh, maNhomPhanQuyen);
                }


            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumnXoa")
            {
                if (cbStatus.Checked == true)
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (UserBUS.Instance.xoaNhanVien(int.Parse(gridView2.GetRowCellValue(e.RowHandle, gridColumnMaNguoiDung).ToString()), false))
                        {
                            XtraMessageBox.Show("Nhân viên không còn hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            UserBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                        }
                    }
                }
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaNguoiDung.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnMaNguoiDung).ToString();
                txtTenDangNhap.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnTenDN).ToString();
                txtTenNguoiDung.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnTenNguoiDung).ToString();
                txtSoDienThoai.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnSoDienThoai).ToString();
                txtDiaChi.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnDiaChi).ToString();
                txtEmail.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnEmail).ToString();
                txtMatKhau.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnMatKhau).ToString();
                dateTimePickerNgayVL.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnNgayVL).ToString();
                toolStripButtonLuuND.Enabled = false;
                txtMatKhau.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                if (cbStatus.Checked == true)
                {
                    toolStripButtonCapNhat.Enabled = true;
                }
                else
                {
                    toolStripButtonCapNhat.Enabled = false;
                }
            }
            catch
            {
                return;
            }
        }

        private void gridViewnguoiDungChuaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            row = int.Parse(gridViewnguoiDungChuaCoNhom.GetRowCellValue(gridViewnguoiDungChuaCoNhom.FocusedRowHandle, gridColumn3).ToString());
            btnRemove.Enabled = false;
            btnADD.Enabled = true;
        }

        private void gridViewNguoiDungDaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowMaNDNhom = int.Parse(gridViewNguoiDungDaCoNhom.GetRowCellValue(gridViewNguoiDungDaCoNhom.FocusedRowHandle, gridColumn10).ToString());
            btnADD.Enabled = false;
            btnRemove.Enabled = true;
        }

        private void cboNhomNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), gridControlNDCoNhom);
                row = -1;
                rowMaNDNhom = -1;
            }
            catch
            {
                UserBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControlNDCoNhom);
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (row == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên thêm vào nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (UserBUS.Instance.themNguoiDungVaoNhom(row, int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), ""))
                {
                    XtraMessageBox.Show("Thêm người dùng vào nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLaiForm();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (rowMaNDNhom == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn người dùng loại khỏi nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (UserBUS.Instance.xoaNguoiDungRaKhoiNhom(rowMaNDNhom, int.Parse(cboNhomNguoiDung.SelectedValue.ToString())))
                {
                    XtraMessageBox.Show("Loại người dùng ra khỏi nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLaiForm();
                }

            }
        }

        public void loadLaiForm()
        {
            UserBUS.Instance.loadNguoiDungChuaCoNhom(gridControlNguoiDungChuaCoNhom);
            UserBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), gridControlNDCoNhom);
            UserBUS.Instance.loadNhomNguoiDung(treeListNguoiDUng);
            rowMaNDNhom = -1;
            row = -1;
        }
    }
}
