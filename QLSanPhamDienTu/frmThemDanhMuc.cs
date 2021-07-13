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
    public partial class frmThemDanhMuc : Form
    {

        string logo = "";
        public frmThemDanhMuc()
        {
            InitializeComponent();
        }

        private void frmThemDanhMuc_Load(object sender, EventArgs e)
        {
            CategoryBUS.Instance.loadDataCategoriesInGridControl(gridControl1);
            NhaSanXuatBUS.Instance.loadNhaSanXuatCbo(cboNSX);
            CategoryBUS.Instance.loadDataCatgoriesNodeInCbo(cboGhiChu);
            txtTenDM.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDM.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtTenDM.Text.Trim()))
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn cập nhật Danh mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        if (CategoryBUS.Instance.updateCategory(int.Parse(txtMaDM.Text.Trim()), txtTenDM.Text.Trim(), int.Parse(cboNSX.SelectedValue.ToString()), cboGhiChu.SelectedItem.ToString(), logo))
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                            CategoryBUS.Instance.loadDataCategoriesInGridControl(gridControl1);
                            frmThemDanhMuc_Load(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                    txtTenDM.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Danh mục!", "Thông báo", MessageBoxButtons.OK);
                txtTenDM.Focus();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
            try
            {
                txtMaDM.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn1).ToString();
                txtTenDM.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn2).ToString();  
                cboGhiChu.Text =  gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn5).ToString();
            }
            catch
            {
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDM.Text.Trim()))
            {
                MessageBox.Show("Vui lòng làm mới danh mục trước khi thêm!");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTenDM.Text.Trim()))
                {
                    if (CategoryBUS.Instance.insertCategory(txtTenDM.Text.Trim(), int.Parse(cboNSX.SelectedValue.ToString()), cboGhiChu.SelectedItem.ToString(), logo))
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                        CategoryBUS.Instance.loadDataCategoriesInGridControl(gridControl1);
                        frmThemDanhMuc_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                    txtTenDM.Focus();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDM.Text.Trim()))
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa Danh mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    if (CategoryBUS.Instance.deleteCategory(int.Parse(txtMaDM.Text.Trim())))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                        CategoryBUS.Instance.loadDataCategoriesInGridControl(gridControl1);
                        frmThemDanhMuc_Load(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Danh mục!", "Thông báo", MessageBoxButtons.OK);
                txtTenDM.Focus();
            }
        }

        private void cboGhiChu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDM.Text = "";
            txtTenDM.Text = "";
            txtTenDM.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string filename;
                filename = open.FileName;
                //MessageBox.Show(filename);
                pictureBox1.ImageLocation = filename;
                string[] url = filename.Trim().Split('\\');
                logo = url.Last();
            }
        }
    }
}
