using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KhachHangDAOcs
    {
        private static KhachHangDAOcs instance;
        public static KhachHangDAOcs Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new KhachHangDAOcs();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();


        #region load tất cả khách hàng
        public List<KhachHangNews> LoadTatCaKhachHang()
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
        #endregion

        #region thêm một khách hàng mới
        public bool ThemMotKhachHang(string tenKH, string sdt, string email, string diaChi)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.tenDangNhap = tenKH;
                kh.soDienThoai = sdt;
                kh.email = email;
                kh.diaChi = diaChi;
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


        public bool KtraSoDienThoaiTonTai(string input)
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
        public bool capNhatThongTinKH(int maKH, string tenKH, string sdt, string email, string diaChi)
        {
            try
            {
                var kh = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == maKH);
                if(kh==null)
                {
                    return false;
                }    
                
                if(sdt==kh.soDienThoai)
                {
                    kh.tenKhachHang = tenKH;
                    kh.email = email;
                    kh.diaChi = diaChi;
                    db.SubmitChanges();
                    return true;
                }   
                else
                {
                    if(KtraSoDienThoaiTonTai(sdt))
                    {
                        kh.tenKhachHang = tenKH;
                        kh.email = email;
                        kh.soDienThoai = sdt;
                        kh.diaChi = diaChi;
                        db.SubmitChanges();
                        return true;
                    }    
                    else
                    {
                        return false;
                    }    
                }    
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region xóa một khách hàng
        public bool xoaKhachHang(int maKH)
        {
            try
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == maKH);
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
