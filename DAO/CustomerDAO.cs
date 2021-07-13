using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();


        #region load tất cả khách hàng
        public List<KhachHangNews> getAllDataCustomer()
        {
            var listKH = (from kh in db.KhachHangs
                          select new KhachHangNews
                          {
                              MaKhachHang = kh.maKhachHang,
                              TenKhachHang = kh.tenKhachHang,
                              SoDienThoai = kh.soDienThoai,
                              Email = kh.email,
                              DiaChi = kh.diaChi,
                          }).ToList();
            if (listKH.Count == 0)
            {
                return null;
            }
            return listKH;

        }

        public KhachHang customerByID(int customerId)
        {
            KhachHang kh = new KhachHang();
            kh = db.KhachHangs.Single(m => m.maKhachHang == customerId);
            if (kh == null)
                return null;
            return kh;
        }
        #endregion

        #region thêm một khách hàng mới
        public bool insertCustomer(string customerName, string customerPhoneNumber, string customerEmail, string customerAddress)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.tenKhachHang = customerName;
                kh.soDienThoai = customerPhoneNumber;
                kh.email = customerEmail;
                kh.diaChi = customerAddress;
                kh.tenDangNhap = "";
                kh.matKhau = "";
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool checkCustomerPhoneIsExist(string input)
        {
            try
            {
                var sdt = db.KhachHangs.Where(m => m.soDienThoai == input).ToList();
                if(sdt.Count>0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region cập nhật thông tin một khách hàng
        public bool updateCustomer(int customerID, string customerName, string customerPhoneNumber, string customerEmail, string customerAddress)
        {
            try
            {
                var kh = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == customerID);
                if (kh == null)
                {
                    return false;
                }
                kh.soDienThoai = customerPhoneNumber;
                kh.tenKhachHang = customerName;
                kh.email = customerEmail;
                kh.diaChi = customerAddress;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region xóa một khách hàng
        public bool deleteCustomer(int customerID)
        {
            try
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == customerID);
                db.KhachHangs.DeleteOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
