using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class GoodsReceivedNoteDetailsDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static GoodsReceivedNoteDetailsDAO instance;

        public static GoodsReceivedNoteDetailsDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new GoodsReceivedNoteDetailsDAO();
                }
                return instance;
            }
        }

        public List<NewChiTietPN> loadChiTietPN_maPhieuNhap(int maPhieu)
        {
            var ctpnList = (from pn in db.PhieuNhaps
                            join ctpn in db.CTPhieuNhaps on pn.maPhieuNhap equals ctpn.maPhieuNhap
                            join sp in db.SanPhams on ctpn.maSanPham equals sp.maSanPham
                            where pn.maPhieuNhap == maPhieu
                            select new NewChiTietPN
                            {
                                MaSanPham = sp.maSanPham,
                                DVT = "Cái",
                                SoLuong = (int)ctpn.soLuong,
                                DonGia = (double)ctpn.giaNhap,
                                ThanhTien = (double)ctpn.ThanhTien
                            }).ToList();

            return ctpnList;
        }

        // tìm phiếu nhập với mã và sản phẩm
        public CTPhieuNhap timPhieuNhap_maPNMaTU(int maPhieu, int maSP)
        {
            var pn = db.CTPhieuNhaps.SingleOrDefault(m => m.maPhieuNhap == maPhieu && m.maSanPham == maSP);
            if (pn == null)
            {
                return null;
            }
            return pn;
        }


        public bool themCTPhieuNhap(int maPhieuNhap, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            db = new QLSanPhamDienTuDataContext();
            db.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, db.CTPhieuNhaps);
            try
            {
                CTPhieuNhap ctpn = new CTPhieuNhap();
                ctpn.maPhieuNhap = maPhieuNhap;
                ctpn.maSanPham = maThucUong;
                ctpn.soLuong = soLuong;
                ctpn.giaNhap = (decimal?)giaBan;
                ctpn.ThanhTien = (decimal?)thanhTien;
                db.CTPhieuNhaps.InsertOnSubmit(ctpn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }
        }


        // xóa chi tiết phiếu nhập khi phiếu nhập đó được hủy
        public bool xoaCTPhieuNhap_phieuNhapHuy(int maPhieuNhap)
        {
            try
            {
                var ctpn = db.CTPhieuNhaps.Where(m => m.maPhieuNhap == maPhieuNhap).ToList();
                if (ctpn.Count == 0)
                {
                    return false;
                }
                else
                {
                    db.CTPhieuNhaps.DeleteAllOnSubmit(ctpn);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // xóa từng ctpn
        public bool xoaCTPhieuNhap(int maPhieuNhap, int maThucUong)
        {
            try
            {
                var ctpn = db.CTPhieuNhaps.SingleOrDefault(m => m.maPhieuNhap == maPhieuNhap && m.maSanPham == maThucUong);
                db.CTPhieuNhaps.DeleteOnSubmit(ctpn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // cập nhật chi tiết hóa đơn
        public bool capNhatCTPhieuNhap(int maPhieu, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            try
            {
                CTPhieuNhap ctpn = db.CTPhieuNhaps.SingleOrDefault(m => m.maPhieuNhap == maPhieu && m.maSanPham == maThucUong);
                ctpn.soLuong = soLuong;
                ctpn.giaNhap = (decimal?)giaBan;
                ctpn.ThanhTien = (decimal?)thanhTien;
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
