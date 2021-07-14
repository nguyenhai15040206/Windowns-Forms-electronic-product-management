using System;
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
    public class InvoiceDetailsBUS
    {
        private static InvoiceDetailsBUS instance;
        public static InvoiceDetailsBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new InvoiceDetailsBUS();
                }
                return instance;
            }
        }

        public bool insertInvoiceDetails(int invoiceID, int productID, int amount, double unitPrice, double discount, double sumMoney, string note)
        {
            return InvoiceDetailsDAO.Instance.insertInvoiceDetails(invoiceID, productID, amount, unitPrice, discount, sumMoney, note);
        }

        public bool deleteInvoiceDetail(int invoiceID, int productID)
        {
            return InvoiceDetailsDAO.Instance.deleteInvoiceDetail(invoiceID, productID);
        }

        public void getALLHoaDon(GridControl grv, bool tt)
        {
            grv.DataSource = InvoiceDAO.Instance.getALLHoaDon(tt);
        }

        public void getALLCTHoaDon(GridControl grv, int mahd)
        {
            grv.DataSource = InvoiceDetailsDAO.Instance.getALLCTHoaDon(mahd);
        }
    }
}
