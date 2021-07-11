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
    public partial class frmKhachHang : Form
    {
        int maKH;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void LamMoiDuLieu()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = string.Empty;
                }
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LamMoiDuLieu();
            btnThemKH.Enabled = true;
        }

        public void LoadForm()
        {
            KhachHangBUS.Instance.LoadTatCaKhachHang(gridControl1);

            btnCapNhat.Enabled = false;
            btnThemKH.Enabled = false;
            btnChonKH.Enabled = false;
            btnLamMoi.Enabled = true;
            txtTenKhachHang.Focus();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

            LoadForm();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if(txtSoDienThoai.Text.Trim().Length>0&&txtDiaChi.Text.Trim().Length>0
                &&txtEmail.Text.Trim().Length>0&&txtTenKhachHang.Text.Trim().Length>0)
            {
                if(CheckData.Instances.KtraSoDienThoai(txtSoDienThoai.Text))
                {
                    if(KhachHangBUS.Instance.KtraSoDienThoaiTonTai(txtSoDienThoai.Text))
                    {
                        if (CheckData.Instances.KtraEmail(txtEmail.Text))
                        {
                            if (KhachHangBUS.Instance.ThemMotKhachHang(txtTenKhachHang.Text, txtSoDienThoai.Text, txtEmail.Text, txtDiaChi.Text))
                            {
                                MessageBox.Show("Thêm khách hàng thành công");
                                LamMoiDuLieu();
                                LoadForm();
                            }
                            else
                            {
                                MessageBox.Show("Thêm khách hàng thất bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai đinh dạng Email");
                        }
                    }    
                    else
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                    }    
                }   
                else
                {
                    MessageBox.Show("Sai định dạng số điện thoại");
                }    
            }   
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }    
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaKH).ToString();
                txtTenKhachHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnTenKH).ToString();
                txtSoDienThoai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnSoDT).ToString();
                txtEmail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnEmail).ToString();
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnDiaChi).ToString();
                maKH = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaKH).ToString());
                btnLamMoi.Enabled = false;
                btnCapNhat.Enabled = true;
                btnChonKH.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1")
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhachHangBUS.Instance.xoaKhachHang(maKH))
                    {
                        MessageBox.Show("Xóa thành công");
                        LamMoiDuLieu();
                        LoadForm();

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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(txtSoDienThoai.Text.Trim().Length > 0 && txtDiaChi.Text.Trim().Length > 0
                && txtEmail.Text.Trim().Length > 0 && txtTenKhachHang.Text.Trim().Length > 0)
            {
                if(CheckData.Instances.KtraEmail(txtEmail.Text))
                {
                   if(CheckData.Instances.KtraSoDienThoai(txtSoDienThoai.Text))
                    {
                        if (KhachHangBUS.Instance.capNhatThongTinKH(int.Parse(txtMaKH.Text), txtTenKhachHang.Text, txtSoDienThoai.Text, txtEmail.Text, txtDiaChi.Text))
                        {
                            MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                            LamMoiDuLieu();
                            LoadForm();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại! Vui lòng kiểm tra lại thông tin nhập vào");
                        }
                    }  
                   else
                    {
                        MessageBox.Show("Cập nhật thất bại! Sai định dạng Số điện thoại");
                    }    
                }   
                else
                {
                    MessageBox.Show("Cập nhật thất bại! Sai định dạng Email");
                }    

            }   
            else
            {
                MessageBox.Show("Cập nhật thất bại! Vui lòng điền đầy đủ thông tin");
            }    
        }
    }
}
