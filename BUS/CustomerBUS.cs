using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Data;
using System.Data.Sql;
using DevExpress.XtraEditors;

namespace BUS
{
    public class CustomerBUS
    {
        private static CustomerBUS instance;
        public static CustomerBUS Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new CustomerBUS();
                }
                return instance;
            }
           
        }

        public void getAllDataCustomer(GridControl grv)
        {
            grv.DataSource = CustomerDAO.Instance.getAllDataCustomer();
        }

        public void getAllDataCustomerToGridLookupEdit(GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Properties.DataSource = CustomerDAO.Instance.getAllDataCustomer();
            gridLookUpEdit.Properties.ValueMember = "MaKhachHang";
            gridLookUpEdit.Properties.DisplayMember = "TenKhachHang";
            gridLookUpEdit.CustomDisplayText += GridLookUpEdit_CustomDisplayText;
        }

        private void GridLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            KhachHangNews khachHangNews = gridLookUpEdit.Properties.GetRowByKeyValue(e.Value) as KhachHangNews;
            if(khachHangNews!=null)
            {
                e.DisplayText = khachHangNews.TenKhachHang + " - " + khachHangNews.SoDienThoai+ " - "+ khachHangNews.Email;
            }    
        }

        public bool insertCustomer(string customerName, string customerPhoneNumber, string email, string address)
        {
            return CustomerDAO.Instance.insertCustomer(customerName, customerPhoneNumber, email, address);
        }

        public bool checkPhoneNumberIsExist(string phoneNumber)
        {
            return CustomerDAO.Instance.checkCustomerPhoneIsExist(phoneNumber);
        }


        public bool updateCustomer(int customerID, string customerName, string customerPhoneNumber, string email, string address)
        {
            return CustomerDAO.Instance.updateCustomer(customerID, customerName, customerPhoneNumber, email, address);
        }

        public bool deleteCustomer(int customerID)
        {
            return CustomerDAO.Instance.deleteCustomer(customerID);
        }

        // tra ve thong tin cua mot khach hang
        public string customerName(int customerId)
        {
            return CustomerDAO.Instance.customerByID(customerId).tenKhachHang;
        }
        public string customerPhoneNumber(int customerId)
        {
            return CustomerDAO.Instance.customerByID(customerId).soDienThoai;
        }
        public string customerEmail(int customerId)
        {
            return CustomerDAO.Instance.customerByID(customerId).email;
        }
        public string customerAddress(int customerId)
        {
            return CustomerDAO.Instance.customerByID(customerId).diaChi;
        }
    }
}
