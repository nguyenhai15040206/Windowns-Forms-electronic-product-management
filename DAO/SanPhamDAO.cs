using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SanPhamDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get
            { 
            
                if (instance == null)
                {
                    instance = new SanPhamDAO();
                }
                return instance;
            }
        }

        // loat tất cả sản phẩm
        public List<SanPham> loadTatCaSanPham()
        {
            var listSP = db.SanPhams.ToList();

            return listSP;
        }

        // load sản phẩm theo danh mục ghiChu

        public List<SanPham> loadSanPhamTheoGhiChu(string _ghiChu)
        {
            var listSP = db.SanPhams.Where(m => m.DanhMuc.ghiChu == _ghiChu).ToList();
            return listSP;
        }

        // load sản phẩm theo từng danh mục tên danh mục
        public List<SanPham> loadSanPhamTheoTenDanhMuc(string tenDanhMuc)
        {
            var listSP = db.SanPhams.Where(m => m.DanhMuc.tenDanhMuc == tenDanhMuc).ToList();
            return listSP;
        }

        // trả về thông tin của một sản phẩm
        #region
        public SanPham sanPham(int maSP)
        {
            var sanPham = db.SanPhams.SingleOrDefault(m => m.maSanPham == maSP);
            return sanPham;
        }

        #endregion



        // thao tác các chức năng
        public bool xoaSanPham(int maSP)
        {
            var sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            if(sp !=null)
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool themSanPham(string tenSanPham, int soLuong, double donGia, string moTa, string moTaChiTiet,
            string khuyenMai, double giamGia, DateTime ngayCapNhat, string xuatXu, string hinhMinhHoa, string dsHinh, bool tinhTrang, int maDanhMuc)
        {
            try
            {
                SanPham sp = new SanPham();
                sp.tenSanPham = tenSanPham;
                sp.soLuong = soLuong;
                sp.donGia = (decimal)donGia;
                sp.moTa = moTa;
                sp.moTaChiTiet = moTaChiTiet;
                sp.khuyenMai = khuyenMai;
                sp.giamGia = (decimal)giamGia;
                sp.ngayCapNhat = ngayCapNhat;
                sp.xuatXu = xuatXu;
                sp.hinhMinhHoa = hinhMinhHoa;
                sp.dsHinh = dsHinh;
                sp.tinhTrang = tinhTrang;
                sp.maDanhMuc = maDanhMuc;
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatSanPham(int maSanPham,string tenSanPham, int soLuong, double donGia, string moTa, string moTaChiTiet,
            string khuyenMai, double giamGia, DateTime ngayCapNhat, string xuatXu, string hinhMinhHoa, string dsHinh, bool tinhTrang, int maDanhMuc)
        {
            try
            {
                var sp = db.SanPhams.SingleOrDefault(m => m.maSanPham == maSanPham);
                if(sp == null)
                {
                    return false;
                }
                sp.tenSanPham = tenSanPham;
                sp.soLuong = soLuong;
                sp.donGia = (decimal)donGia;
                sp.moTa = moTa;
                sp.moTaChiTiet = moTaChiTiet;
                sp.khuyenMai = khuyenMai;
                sp.giamGia = (decimal)giamGia;
                sp.ngayCapNhat = ngayCapNhat;
                sp.xuatXu = xuatXu;
                sp.hinhMinhHoa = hinhMinhHoa;
                sp.dsHinh = dsHinh;
                sp.tinhTrang = tinhTrang;
                sp.maDanhMuc = maDanhMuc;
                db.SubmitChanges();
                return true;
            }catch
            {
                return false;
            }
        }



        
    }
}
