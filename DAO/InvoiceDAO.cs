using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class InvoiceDAO
    {
        private static InvoiceDAO instance;
        public static InvoiceDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new InvoiceDAO();
                }
                return instance;
            }
        }

        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        // load hoas ddown
        public List<HoaDon> loadHoaDon(bool tinhTrang)
        {
            var invoice = db.HoaDons.Where(m => m.tinhTrang == tinhTrang).ToList();
            return invoice;
        }

        // lấy mã hóa đơn mới nhất
        public int selectTopOneIsInvoiceID()
        {
            int maHD = (int)(from hd in db.HoaDons
                             orderby hd.maHoaDon descending
                             select hd.maHoaDon).Take(1).Single();
            return maHD;
        }

        public HoaDon invoiceByID(int invoiceID)
        {
            var invoice = db.HoaDons.SingleOrDefault(m => m.maHoaDon == invoiceID);
            return invoice;
        }


        //
        // thêm hóa đơn(thêm mới vào csdl)
        public bool insertInvoice(DateTime date, int customerID, double sumUnitPrice, double sumDiscount, double sumMoney, string note, int userID, bool status)
        {
            // mặt định trình trạng hóa đơn có hiệu lực (true)
            // hóa đơn có ngày lập là ngày hiện tại
            try
            {
                HoaDon invoice = new HoaDon();
                invoice.ngayBan = date;
                invoice.maKhachHang = customerID;
                invoice.tienBan = (decimal?)sumUnitPrice;
                invoice.giamGia = (double?)sumDiscount;
                invoice.tongTien = (decimal?)sumMoney;
                invoice.ghiChu = note;
                invoice.maNguoiDung = userID;
                invoice.tinhTrang = status;
                db.HoaDons.InsertOnSubmit(invoice);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // hủy hóa đơn(có nghĩa hóa đơn này không có giá trị)
        public bool deleteInvoice(int invoiceID)
        {
            try
            {
                var hoaDon = db.HoaDons.SingleOrDefault(m => m.maHoaDon == invoiceID);
                hoaDon.tinhTrang = false;
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
