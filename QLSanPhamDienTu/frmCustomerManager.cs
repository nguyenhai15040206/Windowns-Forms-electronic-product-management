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
    public partial class frmCustomerManager : Form
    {
        private int customerID=0;
        public frmCustomerManager()
        {
            InitializeComponent();
        }

        public void resetData()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = string.Empty;
                }
            }


        }

        public void LoadForm()
        {
            CustomerBUS.Instance.getAllDataCustomer(gvCustomer);

            btnCapNhat.Enabled = false;
            btnInsertCustomer.Enabled = false;
            //btnChonKH.Enabled = false;
            btnResetData.Enabled = true;
            txtCustomerName.Focus();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                btnResetData.Enabled = true;
                btnCapNhat.Enabled = true;
                btnInsertCustomer.Enabled = false;
                txtCustomerID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaKH).ToString();
                customerID = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaKH).ToString());
                txtCustomerName.Text = CustomerBUS.Instance.customerName(customerID);
                txtCustomerPhoneNumber.Text = CustomerBUS.Instance.customerPhoneNumber(customerID);
                txtEmail.Text = CustomerBUS.Instance.customerEmail(customerID);
                txtAddress.Text = CustomerBUS.Instance.customerAddress(customerID);
                //btnChonKH.Enabled = true;
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
                    if (CustomerBUS.Instance.deleteCustomer(customerID))
                    {
                        XtraMessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetData();
                        LoadForm();
                    }
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtCustomerPhoneNumber.Text.Trim().Length > 0 && txtCustomerName.Text.Trim().Length > 0)
            {
                if (CheckDataInput.Instances.isPhoneNumber(txtCustomerPhoneNumber.Text))
                {
                    string email = "";
                    if (txtEmail.Text.Trim().Length > 0)
                    {
                        if (CheckDataInput.Instances.isEmail(txtEmail.Text))
                        {
                            email = txtEmail.Text.Trim();
                        }
                        else
                        {
                            XtraMessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                        }
                    }
                    if (CustomerBUS.Instance.updateCustomer(customerID,txtCustomerName.Text, txtCustomerPhoneNumber.Text, email, txtAddress.Text))
                    {
                        XtraMessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetData();
                        LoadForm();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerPhoneNumber.Focus();
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
            btnInsertCustomer.Enabled = true;
            btnCapNhat.Enabled = false;
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerPhoneNumber.Text.Trim().Length > 0 && txtCustomerName.Text.Trim().Length > 0)
            {
                if (CheckDataInput.Instances.isPhoneNumber(txtCustomerPhoneNumber.Text))
                {
                    string email = "";
                    if (txtEmail.Text.Trim().Length > 0)
                    {
                        if (CheckDataInput.Instances.isEmail(txtEmail.Text))
                        {
                            email = txtEmail.Text.Trim();
                        }
                        else
                        {
                            XtraMessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                        }
                    }
                    if (CustomerBUS.Instance.insertCustomer(txtCustomerName.Text, txtCustomerPhoneNumber.Text, email, txtAddress.Text))
                    {
                        XtraMessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetData();
                        LoadForm();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerPhoneNumber.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
