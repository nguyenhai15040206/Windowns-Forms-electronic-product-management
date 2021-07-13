using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

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
    }
}
