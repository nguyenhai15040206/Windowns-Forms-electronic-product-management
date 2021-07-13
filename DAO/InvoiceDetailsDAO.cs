using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class InvoiceDetailsDAO
    {
        private static InvoiceDetailsDAO instance;
        public static InvoiceDetailsDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new InvoiceDetailsDAO();
                }
                return instance;
            }
        }

        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        // thêm chi tiết hóa đơn
        public bool insertInvoiceDetails(int invoiceID, int productID, int amount, double unitPrice, double discount,double sumMoney,string note)
        {
            try
            {
                CTHoaDon inDetails = new CTHoaDon();
                inDetails.maHoaDon = invoiceID;
                inDetails.maSanPham = productID;
                inDetails.soLuong = amount;
                inDetails.donGia = (decimal?)unitPrice;
                inDetails.giamGia = (double?)discount;
                inDetails.thanhTien = (decimal?)sumMoney;
                inDetails.ghiChu = note;
                db.CTHoaDons.InsertOnSubmit(inDetails);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // xóa chi tiết hóa đơn
        public bool deleteInvoiceDetail(int invoiceID, int productID)
        {
            try
            {
                var cthd = db.CTHoaDons.SingleOrDefault(m => m.maHoaDon == invoiceID && m.maSanPham == productID);
                db.CTHoaDons.DeleteOnSubmit(cthd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
