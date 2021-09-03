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
using System.Net;
using System.IO;
using RestSharp;
using Newtonsoft.Json;

namespace QLSanPhamDienTu
{
    public partial class frmInsertProduct : Form
    {
        public static string infomationDetailsProduct = string.Empty;
        public delegate void sendData(string value);
        public sendData productID;
        public string fileName;
        private double unitprice;
        public frmInsertProduct()
        {
            InitializeComponent();
            productID = new sendData(getMaSanPham);

        }

        public void getMaSanPham(string productID)
        {
            txtProductCode.Text = productID;
        }

        private void frmThemSanPham_Load(object sender, EventArgs e)
        {
            CategoryBUS.Instance.loadDataCatgoriesNodeInCbo(cboCategoriesByNote);
            if (txtProductCode.Text != null)
            {
                try
                {
                    cboCategoriesByNote.Text = ProductBUS.Instance.productByCategory(int.Parse(txtProductCode.Text));
                }

                catch
                {
                    return;
                }
            }
           
        }


        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            txtProductName.Text = ProductBUS.Instance.productName(int.Parse(txtProductCode.Text)).Trim() == null ? "": ProductBUS.Instance.productName(int.Parse(txtProductCode.Text)).Trim();
            numericUpDownAmount.Value = ProductBUS.Instance.productAmount(int.Parse(txtProductCode.Text));
            txtMadeIn.Text = ProductBUS.Instance.productMadeIn(int.Parse(txtProductCode.Text)).Trim() == null ? "" : ProductBUS.Instance.productMadeIn(int.Parse(txtProductCode.Text)).Trim();
            txtImage.Text = ProductBUS.Instance.productImage(int.Parse(txtProductCode.Text)).Trim() == null ? "" : ProductBUS.Instance.productImage(int.Parse(txtProductCode.Text)).Trim();
            txtPromotion.Text = ProductBUS.Instance.productPromotion(int.Parse(txtProductCode.Text)).Trim() == null ? "" : ProductBUS.Instance.productPromotion(int.Parse(txtProductCode.Text)).Trim();
            txtUnitPrice.Text = Convert.ToString(ProductBUS.Instance.productUnitPrice(int.Parse(txtProductCode.Text))).Trim();
            txtUnitPriceImport.Text = Convert.ToString(ProductBUS.Instance.productUnitPriceImport(int.Parse(txtProductCode.Text))).Trim();
            //numEricUpdownDiscount.Value = Convert.ToString(SanPhamBUS.Instance.giamGia(int.Parse(txtProductCode.Text))).Trim();
            txtProductDetails.Text = Convert.ToString(ProductBUS.Instance.informationDetails(int.Parse(txtProductCode.Text))).Trim() == null ? "" : Convert.ToString(ProductBUS.Instance.informationDetails(int.Parse(txtProductCode.Text))).Trim();
            txtListImages.Text = ProductBUS.Instance.imageListProduct(int.Parse(txtProductCode.Text)).Trim();
            ckbStatus.Checked = (ProductBUS.Instance.productStatus(int.Parse(txtProductCode.Text)));
            pickerUpdateDate.Value = (DateTime)ProductBUS.Instance.productDateUpdate(int.Parse(txtProductCode.Text));

            if (ProductBUS.Instance.productImage(int.Parse(txtProductCode.Text)).Trim() != "")
            {
                try
                {
                    string img = ProductBUS.Instance.productImage(int.Parse(txtProductCode.Text)).Trim();
                    var request = WebRequest.Create("http://192.168.1.5:5000/Upload/"+ img);
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
        }

        private void txtThongTinChiTiet_Click(object sender, EventArgs e)
        {
            if (cboCategoriesByNote.Text.Equals("DienThoai"))
            {
                frmInfomationPhoneDetails frm = new frmInfomationPhoneDetails();
                if (txtProductDetails.Text.Trim() != null)
                {
                    try
                    {
                        frm.infomationDetails(txtProductDetails.Text);
                    }
                    catch { }
                }
                frm.ShowDialog();
            }
            if(cboCategoriesByNote.Text.Equals("Laptop"))
            {
                frmInfomationLaptopDetails frm = new frmInfomationLaptopDetails();
                if (txtProductDetails.Text.Trim() != null)
                {
                    try
                    {
                        frm.infomationDetails(txtProductDetails.Text);
                    }
                    catch { }
                }
                frm.ShowDialog();
            }    
            if(!string.IsNullOrEmpty(infomationDetailsProduct))
            {
                this.txtProductDetails.Text = infomationDetailsProduct;
            }    
        }


        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryBUS.Instance.loadDataCategoriesByNoteInCbo(cboTrademark, cboCategoriesByNote.SelectedItem.ToString());
            if(txtProductCode.Text.Trim() !=null)
            {
                try
                {
                    cboTrademark.Text = CategoryBUS.Instance.tenDanhMucTheoMaSP(int.Parse(txtProductCode.Text));
                }
                catch { }
            }
            
        }


        public void resetData()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    if(control.Name!= "txtMaSP")
                    {
                        control.Text = string.Empty;
                    }  
                    else
                    {
                        continue;
                    }    
                }

            }
            btnAddNew.Enabled = true;

        }


        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim().Length > 0 && txtMadeIn.Text.Trim().Length > 0 &&txtUnitPriceImport.Text.Trim().Length > 0)
            {
                if(CheckDataInput.Instances.isDouble(txtUnitPriceImport.Text))
                {
                    if (txtImage.Text.Trim().Length > 0)
                    {
                        if(txtProductDetails.Text.Trim().Length >0)
                        {
                            string[] infomationDetails = txtProductDetails.Text.Trim().Split('&');
                            string description = infomationDetails[0].Trim().ToString();
                            string descriptionDetails = infomationDetails[1].Trim().ToString();
                            bool status = true;
                            if(int.Parse(numericUpDownAmount.Value.ToString()) == 0)
                            {
                                status = false;
                            }    
                            if(ProductBUS.instance.insertProduct(txtProductName.Text.Trim(), int.Parse(numericUpDownAmount.Value.ToString()),
                                        unitprice, double.Parse(txtUnitPriceImport.Text.Trim()), description, descriptionDetails, txtPromotion.Text.Trim(), double.Parse(numEricUpdownDiscount.Value.ToString()), pickerUpdateDate.Value,
                                        txtMadeIn.Text.Trim(), txtImage.Text.Trim(), null, int.Parse(cboTrademark.SelectedValue.ToString()), status))
                            {
                                XtraMessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                try
                                {
                                    using (var fileStream = File.Open(fileName, FileMode.Open))
                                    {
                                        var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/ImagesUpload");
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
                            XtraMessageBox.Show("Vui lòng điền thông tin chi tiết cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                    }
                    else
                    {
                        XtraMessageBox.Show("Vui lòng chọn hình minh họa cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đơn giá sai định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            resetData();
            btnResetData.Enabled = false;
        }

        private async void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim().Length > 0 && txtMadeIn.Text.Trim().Length > 0 && txtUnitPriceImport.Text.Trim().Length > 0)
            {
                if (CheckDataInput.Instances.isDouble(txtUnitPriceImport.Text))
                {
                    if (txtImage.Text.Trim().Length > 0)
                    {
                        if (txtProductDetails.Text.Trim().Length > 0)
                        {
                            string[] infomationDetails = txtProductDetails.Text.Trim().Split('&');
                            string description = infomationDetails[0].Trim().ToString();
                            string descriptionDetails = infomationDetails[1].Trim().ToString();
                            bool status = true;
                            if (int.Parse(numericUpDownAmount.Value.ToString()) == 0)
                            {
                                status = false;
                            }
                            if (ProductBUS.instance.updateProduct(int.Parse(txtProductCode.Text),txtProductName.Text.Trim(), int.Parse(numericUpDownAmount.Value.ToString()),
                                         unitprice, double.Parse(txtUnitPriceImport.Text.Trim()), description, descriptionDetails, txtPromotion.Text.Trim(), double.Parse(numEricUpdownDiscount.Value.ToString()), pickerUpdateDate.Value,
                                        txtMadeIn.Text.Trim(), txtImage.Text.Trim(), null, int.Parse(cboTrademark.SelectedValue.ToString()), status))
                            {
                                XtraMessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if(!string.IsNullOrEmpty(fileName))
                                {
                                    try
                                    {
                                        using (var fileStream = File.Open(fileName, FileMode.Open))
                                        {
                                            var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/ImagesUpload");
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
                        else
                        {
                            XtraMessageBox.Show("Vui lòng điền thông tin chi tiết cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Vui lòng chọn hình minh họa cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đơn giá sai định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChoseImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog() { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" };
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] url = open.FileName.Trim().Split('\\');
                txtImage.Text = url.Last();
                pictureBox1.ImageLocation = open.FileName;
                fileName = open.FileName;
            }
        }


        private void btnChoseListImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string filename;
                filename = open.FileName;
                string[] url = filename.Trim().Split('\\');
                txtListImages.Text = url.Last();
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void btnAddPromotion_Click(object sender, EventArgs e)
        {
            var rs=  XtraInputBox.Show("Nhập vào khuyến mãi của mặt hàng", "Khuyến mãi", "");
            if (txtPromotion.Text.Trim() == "")
            {
                txtPromotion.Text = rs;
            }
            else
            {
                txtPromotion.Text = txtPromotion.Text + "|" + rs;
            }

        }

        private void btnClearTextPromotion_Click(object sender, EventArgs e)
        {
            txtPromotion.Text = "";
        }

        private void txtUnitPriceImport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void txtUnitPriceImport_TextChanged(object sender, EventArgs e)
        {
            try
            {
                unitprice = double.Parse(txtUnitPriceImport.Text.Trim()) + (double.Parse(txtUnitPriceImport.Text.Trim()) * 15 / 100);
                txtUnitPrice.Text = string.Format("{0:0,0} vnđ", unitprice);
            }
            catch
            {
                unitprice = 0;
                txtUnitPrice.Text = "";
                return;
            }
        }
    }
}
