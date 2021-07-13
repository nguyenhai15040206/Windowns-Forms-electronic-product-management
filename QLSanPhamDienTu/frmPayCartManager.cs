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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DTO;
using QLSanPhamDienTu.Report;

namespace QLSanPhamDienTu
{
    public partial class frmPayCartManager : Form
    {
        private int productID = 0;
        private int row = 0;
        private double sumMoney = 0;
        private double sumDiscount = 0;
        private double sumUnitprice = 0;
        public frmPayCartManager()
        {
            InitializeComponent();
        }


        private void btnResetData_Click(object sender, EventArgs e)
        {
            btnInvoicePrinting.Enabled = false;
            resetData();
        }

        private void frmPayCartManager_Load(object sender, EventArgs e)
        {
            CustomerBUS.Instance.getAllDataCustomerToGridLookupEdit(gridLookUpEditCustomer);
            CategoryBUS.Instance.loadDataCatgoriesNodeInCbo(cboCategorisNote);

        }

        public void resetData()
        {
            productID = 0;
            row = 0;
            sumDiscount = 0;
            sumMoney = 0;
            sumUnitprice = 0;
            foreach (Control item in groupBox1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void cboCategorisNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CategoryBUS.Instance.loadDataCategoriesByNoteInCbo(cboCategoryByNote, cboCategorisNote.Text.Trim());
            }
            catch
            {
                return;
            }
        }

        private void cboCategoryByNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductBUS.Instance.getDataProductsByCategoryID(gridLookUpEditProductByNote, int.Parse(cboCategoryByNote.SelectedValue.ToString()));
            }
            catch
            {
                return;
            }
        }

        private void gridLookUpEditCustomer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int customerID = int.Parse(gridLookUpEditCustomer.EditValue.ToString());
                txtCustomerName.Text = CustomerBUS.Instance.customerName(customerID);
                txtPhoneNumber.Text = CustomerBUS.Instance.customerPhoneNumber(customerID);
            }
            catch
            {
                return;
            }
        }

        private void gridLookUpEditProductByNote_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                productID = int.Parse(gridLookUpEditProductByNote.EditValue.ToString());
                gridView1.SetRowCellValue(0, gridColProductID, productID);

                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            if (productID != 0)
            {
                bool check = true;
                dgvInvoiveDetails.FirstDisplayedScrollingRowIndex = dgvInvoiveDetails.RowCount - 1;
                for (int i = 0; i < dgvInvoiveDetails.Rows.Count; i++)
                {
                    if (dgvInvoiveDetails.Rows[i].Cells["maSanPham"].Value != null && int.Parse(dgvInvoiveDetails.Rows[i].Cells["maSanPham"].Value.ToString()) == productID)
                    {
                        check = false;
                        dgvInvoiveDetails.Rows[i].Cells["soLuong"].Value = int.Parse(dgvInvoiveDetails.Rows[i].Cells["soLuong"].Value.ToString())+1;
                        dgvInvoiveDetails.Rows[i].Cells["donGia"].Value = int.Parse(dgvInvoiveDetails.Rows[i].Cells["soLuong"].Value.ToString())* ProductBUS.Instance.productUnitPrice(productID);
                        dgvInvoiveDetails.Rows[i].Cells["giamGia"].Value = ProductBUS.Instance.productDiscount(productID) * int.Parse(dgvInvoiveDetails.Rows[i].Cells["soLuong"].Value.ToString());
                        dgvInvoiveDetails.Rows[i].Cells["tongTien"].Value = (double)(int.Parse(dgvInvoiveDetails.Rows[i].Cells["soLuong"].Value.ToString()) *  ProductBUS.Instance.productUnitPrice(productID)) -  double.Parse(dgvInvoiveDetails.Rows[i].Cells["giamGia"].Value.ToString());
                        sumMoneyInDgv();
                        txtCustomerMoney.Focus();
                        return;
                    }
                    else
                    {
                        check = true;
                        continue;
                    }

                }
                if (check)
                {
                    int rowId = dgvInvoiveDetails.Rows.Add();
                    DataGridViewRow row = dgvInvoiveDetails.Rows[rowId];
                    row.Cells["maSanPham"].Value = productID;
                    row.Cells["tenSanPham"].Value = ProductBUS.Instance.productName(productID);
                    row.Cells["DVT"].Value = "Cái";
                    row.Cells["soLuong"].Value = 1;
                    row.Cells["donGia"].Value = 1* ProductBUS.Instance.productUnitPrice(productID);
                    row.Cells["giamGia"].Value = 1* ProductBUS.Instance.productDiscount(productID);
                    row.Cells["tongTien"].Value = (int.Parse(row.Cells["soLuong"].Value.ToString()) * ProductBUS.Instance.productUnitPrice(productID) - ProductBUS.Instance.productDiscount(productID));
                }
                sumMoneyInDgv();
                txtCustomerMoney.Focus();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm cần mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void sumMoneyInDgv()
        {
            sumDiscount = 0;
            sumMoney = 0;
            sumUnitprice = 0;
            for (int i = 0; i < dgvInvoiveDetails.Rows.Count - 1; i++)
            {
                sumDiscount += double.Parse(dgvInvoiveDetails.Rows[i].Cells["giamGia"].Value.ToString());
                sumMoney += double.Parse(dgvInvoiveDetails.Rows[i].Cells["tongTien"].Value.ToString());
                sumUnitprice += double.Parse(dgvInvoiveDetails.Rows[i].Cells["donGia"].Value.ToString());
            }
            if(sumMoney<=0)
            {
                txtDiscount.Text = "";
                txtSumMoney.Text = "";
            }
            else
            {
                txtDiscount.Text = string.Format("{0:0,0} vnđ", Math.Round(sumDiscount));
                txtSumMoney.Text = string.Format("{0:0,0} vnđ", Math.Round(sumMoney));
            }  
        }

        private void gridViewInvoiceDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Name == "gridColProductID")
            {
                var ma = gridView1.GetRowCellValue(e.RowHandle, e.Column);
            }    
        }

        private void repositoryItemLookUpEditProducts_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void dgvInvoiveDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvInvoiveDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void txtCustomerMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCustomerMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtSumMoney.Text.Trim()!=""&& double.Parse(txtCustomerMoney.Text.Trim())>= sumMoney)
                {
                    txtExcessCash.Text = string.Format("{0:0,0} vnđ", (double.Parse(txtCustomerMoney.Text.Trim()) - sumMoney));
                    btnPayCart.Enabled = true;
                }
                else
                {
                    btnPayCart.Enabled = false;
                }   
            }
            catch
            {
                return;
            }
        }

        private void dgvInvoiveDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvInvoiveDetails.Rows[e.RowIndex].Cells[0].Selected)
            {
                if(dgvInvoiveDetails.Rows[e.RowIndex].Cells[1].Value!=null)
                {
                    dgvInvoiveDetails.Rows.Remove(dgvInvoiveDetails.Rows[e.RowIndex]);
                    sumMoneyInDgv();
                    txtCustomerMoney.Focus();
                }    
            }    
        }

        private void btnPayCart_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text.Trim().Length > 0)
            {
                if(InvoiceBUS.Instance.insertInvoice(dateTimePickerDate.Value.Date,1,sumUnitprice,sumDiscount,sumMoney,"Đã thanh toán",1,true))
                {
                    int invoiceID = InvoiceBUS.Instance.selectTopOneIsInvoiceID();
                    for (int i = 0; i < dgvInvoiveDetails.Rows.Count - 1; i++)
                    {

                        int productID = int.Parse(dgvInvoiveDetails.Rows[i].Cells["maSanPham"].Value.ToString());
                        int amount = int.Parse(dgvInvoiveDetails.Rows[i].Cells["soLuong"].Value.ToString());
                        double unitPrice = double.Parse(dgvInvoiveDetails.Rows[i].Cells["donGia"].Value.ToString());
                        double discount = double.Parse(dgvInvoiveDetails.Rows[i].Cells["giamGia"].Value.ToString());
                        double thanhTien = (amount * unitPrice) - (amount * discount);
                        if (InvoiceDetailsBUS.Instance.insertInvoiceDetails(invoiceID, productID, amount, unitPrice,discount, thanhTien,"Đã thanh toán"))
                        {
                            ProductBUS.Instance.updateAmount_Buy(productID, amount);
                        }

                    }
                    if (XtraMessageBox.Show("Thêm thành công! Bạn có muốn in hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        XtraReportInvoiceDetails rpt = new XtraReportInvoiceDetails();
                        XRLabel xRLabel = rpt.xrLabelSumMoney;
                        double sumMoney = InvoiceBUS.Instance.sumMoney(invoiceID);
                        xRLabel.Text = CheckDataInput.Instances.formatMoneyToString((double)sumMoney);
                        rpt.DataSource = ReportBUS.Instance.printInvoice(invoiceID);
                        rpt.ShowPreviewDialog();
                    }
                    btnPayCart.Enabled = false;
                    resetData();
                    CustomerBUS.Instance.getAllDataCustomerToGridLookupEdit(gridLookUpEditCustomer);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn một khách hàng cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
