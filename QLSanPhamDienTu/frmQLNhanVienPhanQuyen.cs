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
    public partial class frmQLNhanVienPhanQuyen : Form
    {
        int maNhom = 0;
        int row = -1;
        int rowMaNDNhom = -1;
        bool hoatDong = false;
        int maKH;
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


            menutItemThem.Enabled = false;
            btnUpdate.Enabled = false;
            btnClean.Enabled = true;

        }

        public void LamMoiDuLieu()
        {
            
            foreach (Control control in panel10.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = string.Empty;
                }
            }
        }

        private void menuItemClean_Click(object sender, EventArgs e)
        {
            LamMoiDuLieu();
            menutItemThem.Enabled = true;
            btnClean.Enabled = false;
        }

        private void menuItemThem_Click(object sender, EventArgs e)
        {
            if(txtTenNguoiDung.Text.Trim().Length>0&&txtTenDangNhap.Text.Trim().Length>0 && txtMatKhau.Text.Trim().Length>0 && txtDiaChi.Text.Trim().Length>0 &&
                txtSoDienThoai.Text.Trim().Length>0||txtEmail.Text.Trim().Length>0)
            {
                if (NguoiDungBUS.Instance.KtraTenNguoiDung(txtTenDangNhap.Text))
                {
                    if (CheckDataInput.Instances.isPhoneNumber(txtSoDienThoai.Text))
                    {
                        if (NguoiDungBUS.Instance.KTraSoDienThoaiTonTai(txtSoDienThoai.Text))
                        {
                            if (CheckDataInput.Instances.isEmail(txtEmail.Text))
                            {
                                if (NguoiDungBUS.Instance.themNguoiDung(txtTenNguoiDung.Text.Trim(), txtTenDangNhap.Text.Trim(), txtMatKhau.Text,
                                txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text, dateTimePickerNgayVL.Value, true))
                                {
                                    MessageBox.Show("Thêm thành công!");
                                    frmQLNhanVienPhanQuyen_Load( sender,e);
                                    LamMoiDuLieu();
                                    menutItemThem.Enabled = false;
                                    btnClean.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nhập sai định dạng email");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập sai định dạng số điện thoại");
                    }
                }   
                else
                {
                    MessageBox.Show("Tên người dùng đã tồn tại");
                }    
            }   
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
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



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTenNguoiDung.Text.Trim().Length > 0 && txtDiaChi.Text.Trim().Trim().Trim().Length > 0 &&
                txtSoDienThoai.Text.Trim().Trim().Length > 0 && txtEmail.Text.Trim().Length > 0)
            {
                if(CheckDataInput.Instances.isEmail(txtEmail.Text))
                {
                    if(CheckDataInput.Instances.isPhoneNumber(txtSoDienThoai.Text))
                    {
                        if (NguoiDungBUS.Instance.CapNhatThongTinNguoiDung(int.Parse(txtMaNguoiDung.Text), txtTenNguoiDung.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text, dateTimePickerNgayVL.Value, hoatDong))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            LamMoiDuLieu();
                            frmQLNhanVienPhanQuyen_Load(sender, e);
                            btnUpdate.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại, Số điện thoại đã tồn tại");
                        }
                    }    
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại, Sai định dạng Số điện thoại");
                    }    
                } 
                else
                {
                    MessageBox.Show("Cập nhật thất bại, Sai định dạng Email");
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }    
        }



        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaNguoiDung.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaNguoiDung).ToString();
                txtTenNguoiDung.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenNguoiDung).ToString();
                txtTenDangNhap.Text= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenDN).ToString();
                txtMatKhau.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMatKhau).ToString();
                txtSoDienThoai.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSoDienThoai).ToString();
                txtDiaChi.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnDiaChi).ToString();
                txtEmail.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnEmail).ToString();
                dateTimePickerNgayVL.Value= DateTime.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNgayVL).ToString());
                ckbHoatDong.Checked = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnHoatDong).ToString());
                btnUpdate.Enabled = true;
                maKH= int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaNguoiDung).ToString());
            }
            catch
            {
                return;
            }
        }

        private void ckbHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHoatDong.Checked)
                hoatDong = true;
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.Name== "gridColumn1")
            {
                if(XtraMessageBox.Show("Bạn có muốn xóa người dùng này không?","Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if(NguoiDungBUS.Instance.XoaNguoiDung(maKH))
                    {
                        MessageBox.Show("Xóa thành công");
                        LamMoiDuLieu();
                        frmQLNhanVienPhanQuyen_Load(sender, e);
                        
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }    
                }    
                else
                {
                    return;
                }    
            }    
        }
    }
}
