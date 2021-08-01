using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using RestSharp;

namespace QLSanPhamDienTu
{
    public partial class frmInsertCategoryAndSupplier : Form
    {

        private string logo = "";
        private string fileName = "";
        public frmInsertCategoryAndSupplier()
        {
            InitializeComponent();
        }

        private void frmThemDanhMuc_Load(object sender, EventArgs e)
        {
            CategoryBUS.Instance.loadDataCategoriesInGridControl(gvCategory);
            NhaSanXuatBUS.Instance.loadNhaSanXuatCbo(cboNSX);
            CategoryBUS.Instance.loadDataCatgoriesNodeInCbo(cboGhiChu);
            txtTenDM.Focus();

            //
            SupplierBUS.Instance.loadDataToGridView(gvSupplier);
        }


        private void btnResetData_Click(object sender, EventArgs e)
        {
            txtMaDM.Text = "";
            btnInsertCategory.Enabled = true;
            btnUpdateCategory.Enabled = false;
            txtTenDM.Text = "";
            txtTenDM.Focus();
        }

        private async void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDM.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtTenDM.Text.Trim()))
                {
                    DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn cập nhật Danh mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (CategoryBUS.Instance.updateCategory(int.Parse(txtMaDM.Text.Trim()), txtTenDM.Text.Trim(), int.Parse(cboNSX.SelectedValue.ToString()), cboGhiChu.SelectedItem.ToString(), txtLogo.Text.Trim()))
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CategoryBUS.Instance.loadDataCategoriesInGridControl(gvCategory);
                            frmThemDanhMuc_Load(sender, e);
                            if(!string.IsNullOrEmpty(fileName))
                            {
                                try
                                {
                                    using (var fileStream = File.Open(fileName, FileMode.Open))
                                    {
                                        var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/DanhMuc");
                                        var request = new RestRequest();
                                        request.Method = Method.POST;
                                        using (MemoryStream memoryStream = new MemoryStream())
                                        {
                                            await fileStream.CopyToAsync(memoryStream);
                                            request.AddFile("file", memoryStream.ToArray(), fileName);
                                            request.AlwaysMultipartFormData = true;
                                            var response = await client.ExecuteAsync(request);
                                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                            {
                                                Console.WriteLine("Upload Images to server is Success!");
                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("" + ex);
                                    return;
                                }
                            }    
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDM.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn Danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDM.Focus();
            }
        }

        private async void btnInsertCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDM.Text.Trim()))
            {
                XtraMessageBox.Show("Vui lòng làm mới danh mục trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTenDM.Text.Trim()))
                {
                    if (CategoryBUS.Instance.insertCategory(txtTenDM.Text.Trim(), int.Parse(cboNSX.SelectedValue.ToString()), cboGhiChu.SelectedItem.ToString(), txtLogo.Text.Trim()))
                    {
                        XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CategoryBUS.Instance.loadDataCategoriesInGridControl(gvCategory);
                        btnInsertCategory.Enabled = false;
                        btnUpdateCategory.Enabled = false;
                        frmThemDanhMuc_Load(sender, e);
                        try
                        {
                            using (var fileStream = File.Open(fileName, FileMode.Open))
                            {
                                var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/DanhMuc");
                                var request = new RestRequest();
                                request.Method = Method.POST;
                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    await fileStream.CopyToAsync(memoryStream);
                                    request.AddFile("file", memoryStream.ToArray(), fileName);
                                    request.AlwaysMultipartFormData = true;
                                    var response = await client.ExecuteAsync(request);
                                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                    {
                                        Console.WriteLine("Upload Images to server is Success!");
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("" + ex);
                            return;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDM.Focus();
                }
            }
        }

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaDM.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnCategoryID).ToString();
                int categoryID = int.Parse(txtMaDM.Text.Trim());
                txtTenDM.Text = CategoryBUS.Instance.categoryNameByID(categoryID);
                cboGhiChu.Text = CategoryBUS.Instance.categoryNoteByID(categoryID);
                btnUpdateCategory.Enabled = true;
                btnInsertCategory.Enabled = false;
                string logo = CategoryBUS.Instance.categoryLogoByID(categoryID);
                txtLogo.Text = logo;
                if (logo != null)
                {
                    try
                    {
                        var request = WebRequest.Create("http://192.168.1.5:5000/DanhMuc/" + logo);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            pictureBox1.Image = Bitmap.FromStream(stream);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.mascot_fail;
                }
            }
            catch
            {
                return;   
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.Name == "gridColumn1")
            {
                if (!string.IsNullOrEmpty(txtMaDM.Text.Trim()))
                {
                    DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa Danh mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (CategoryBUS.Instance.deleteCategory(int.Parse(txtMaDM.Text.Trim())))
                        {
                            XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CategoryBUS.Instance.loadDataCategoriesInGridControl(gvCategory);
                            btnInsertCategory.Enabled = false;
                            btnUpdateCategory.Enabled = false;
                            frmThemDanhMuc_Load(sender, e);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn Danh mục!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtTenDM.Focus();
                }
            }    
        }

        private void btnChoseImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog() { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" };
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] url = open.FileName.Trim().Split('\\');
                txtLogo.Text = url.Last();
                pictureBox1.ImageLocation = open.FileName;
                fileName = open.FileName;
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtSupplierID.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSuppID).ToString();
                txtSupplierPhone.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSupPhone).ToString();
                txtSupplierName.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSuppName).ToString();
                txtSupplierAdress.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSuppAdress).ToString();
                txtSuplierEmail.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSuppEMail).ToString();
                btnInsertSupplier.Enabled = false;
                btnUpdateSuppler.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void btnResetDataSupplier_Click(object sender, EventArgs e)
        {
            resetDataSupp();
            btnInsertSupplier.Enabled = true;
            btnUpdateSuppler.Enabled = false;
        }
        public void resetDataSupp()
        {
            txtSupplierID.Text = "";
            txtSupplierPhone.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAdress.Text = "";
            txtSuplierEmail.Text = "";
        }    

        private void btnInsertSupplier_Click(object sender, EventArgs e)
        {
            if(txtSuplierEmail.Text.Trim().Length >0 && txtSupplierPhone.Text.Trim().Length > 0 
                && txtSupplierName.Text.Trim().Length > 0 && txtSupplierAdress.Text.Trim().Length > 0)
            {
                if(CheckDataInput.Instances.isPhoneNumber(txtSupplierPhone.Text.Trim()))
                {
                    if(CheckDataInput.Instances.isEmail(txtSuplierEmail.Text.Trim()))
                    {
                        if (SupplierBUS.Instance.insertSupplier(txtSupplierName.Text, txtSupplierAdress.Text, txtSupplierPhone.Text, txtSuplierEmail.Text))
                        {
                            XtraMessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetDataSupp();
                            btnInsertSupplier.Enabled = false;
                            SupplierBUS.Instance.loadDataToGridView(gvSupplier);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Địa chỉ email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateSuppler_Click(object sender, EventArgs e)
        {
            if (txtSuplierEmail.Text.Trim().Length > 0 && txtSupplierPhone.Text.Trim().Length > 0
                && txtSupplierName.Text.Trim().Length > 0 && txtSupplierAdress.Text.Trim().Length > 0)
            {
                if (CheckDataInput.Instances.isPhoneNumber(txtSupplierPhone.Text.Trim()))
                {
                    if (CheckDataInput.Instances.isEmail(txtSuplierEmail.Text.Trim()))
                    {
                        if (SupplierBUS.Instance.updateSupplier(int.Parse(txtSupplierID.Text.Trim()),txtSupplierName.Text, txtSupplierAdress.Text, txtSupplierPhone.Text, txtSuplierEmail.Text))
                        {
                            XtraMessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetDataSupp();
                            btnInsertSupplier.Enabled = false;
                            btnUpdateSuppler.Enabled = false;
                            SupplierBUS.Instance.loadDataToGridView(gvSupplier);
                        }
                        else
                        {
                            XtraMessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Địa chỉ email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn3")
            {
                int id = int.Parse(gridView2.GetRowCellValue(e.RowHandle, gridColumnSuppID).ToString());
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    GoodsReceivedNoteBUS.Instance.capNhatPhieuNhap(id);
                    if (SupplierBUS.Instance.deleteSupplierID(id))
                    {
                        XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CategoryBUS.Instance.loadDataCategoriesInGridControl(gvCategory);
                        resetDataSupp();
                        btnInsertSupplier.Enabled = false;
                        btnUpdateSuppler.Enabled = false;
                        SupplierBUS.Instance.loadDataToGridView(gvSupplier);
                    }
                }
            }
        }
    }
}
