using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class InvoiceBUS
    {
        private static InvoiceBUS instance;
        public static InvoiceBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new InvoiceBUS();
                }
                return instance;
            }
        }


        public void getALLHoaDon(GridControl grv, bool tt)
        {
            grv.DataSource = InvoiceDAO.Instance.getALLHoaDon(tt);
        }

        public bool insertInvoice(DateTime date, int customerID, double sumUnitPrice, double sumDiscount, double sumMoney, string note, int userID, bool status)
        {
            return InvoiceDAO.Instance.insertInvoice(date, customerID, sumUnitPrice, sumDiscount, sumMoney, note, userID, status);
        }

        public bool deleteInvoice(int invoiceID)
        {
            return InvoiceDAO.Instance.deleteInvoice(invoiceID);
        }

        public int selectTopOneIsInvoiceID()
        {
            return InvoiceDAO.Instance.selectTopOneIsInvoiceID();
        }

        public double sumMoney(int invoiceID)
        {
            return (double)InvoiceDAO.Instance.invoiceByID(invoiceID).tongTien;
        }
    }
}
