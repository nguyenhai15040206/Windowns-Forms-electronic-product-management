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




        #region load tất cả hóa đơn
        public List<HoaDonNews> getALLHoaDon(bool tinhTrang)
        {
            var listhd = (from hd in db.HoaDons
                          join kh in db.KhachHangs on hd.maKhachHang equals kh.maKhachHang
                          join nd in db.NguoiDungs on hd.maNguoiDung equals nd.maNguoiDung into NguoiDung_join
                          from ndJoin in NguoiDung_join.DefaultIfEmpty()
                          where hd.tinhTrang == tinhTrang
                          select new HoaDonNews
                          {
                              MaNguoiDuong = ndJoin.maNguoiDung,
                              MaHoaDon = hd.maHoaDon,
                              TenNguoiDung = ndJoin.tenNguoiDung,
                              TinhTrang = hd.tinhTrang,
                              DiaChi = kh.diaChi,
                              TenKhachHang = kh.tenKhachHang,
                              SoDienThoai = kh.soDienThoai,
                              GiamGia = hd.giamGia,
                              TongTien = hd.tongTien,
                              NgayBan = hd.ngayBan,
                              NgayGiao = hd.ngayGiao,
                              GhiChu = hd.ghiChu
                          }).ToList();
            return listhd;
        }

        public List<HoaDonNews> getALLHoaDonBy_Note(string note)
        {
            var listhd = (from hd in db.HoaDons
                          join kh in db.KhachHangs on hd.maKhachHang equals kh.maKhachHang
                          join nd in db.NguoiDungs on hd.maNguoiDung equals nd.maNguoiDung into NguoiDung_join
                          from ndJoin in NguoiDung_join.DefaultIfEmpty()
                          where hd.ghiChu == note && hd.tinhTrang== true
                          select new HoaDonNews
                          {
                              MaNguoiDuong = ndJoin.maNguoiDung,
                              MaHoaDon = hd.maHoaDon,
                              TenNguoiDung = ndJoin.tenNguoiDung,
                              TinhTrang = hd.tinhTrang,
                              DiaChi = kh.diaChi,
                              TenKhachHang = kh.tenKhachHang,
                              SoDienThoai = kh.soDienThoai,
                              GiamGia = hd.giamGia,
                              TongTien = hd.tongTien,
                              NgayBan = hd.ngayBan,
                              NgayGiao = hd.ngayGiao,
                              GhiChu = hd.ghiChu
                          }).ToList();
            return listhd;
        }
        #endregion
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

        public bool updateStatusInvoice(int invoiceID, string note, int UserID)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(m => m.maHoaDon == invoiceID);
                hd.ghiChu = note;
                hd.maNguoiDung = UserID;
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
