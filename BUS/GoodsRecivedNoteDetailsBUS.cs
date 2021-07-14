using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using DevExpress.XtraGrid;
using System.ComponentModel;

namespace BUS
{
    public class GoodsRecivedNoteDetailsBUS
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static GoodsRecivedNoteDetailsBUS instance;

        public static GoodsRecivedNoteDetailsBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new GoodsRecivedNoteDetailsBUS();
                }
                return instance;
            }
        }

        // load chi tiết phiếu nhập theo mã phiếu
        public void loadCTPN_maPhieuNhap(GridControl dgv, int maPhieu)
        {
            List<NewChiTietPN> ctpn = GoodsReceivedNoteDetailsDAO.Instance.loadChiTietPN_maPhieuNhap(maPhieu);
            dgv.DataSource = new BindingList<NewChiTietPN>(ctpn);
        }

        // thêm chi tiết phiếu nhập
        public bool themCTPhieuNhap(int maPhieuNhap, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            return GoodsReceivedNoteDetailsDAO.Instance.themCTPhieuNhap(maPhieuNhap, maThucUong, soLuong, giaBan, thanhTien);
        }

        // xóa từng chi tiết phiếu nhập
        public bool xoaChiTietPN(int maPhieu, int maThucUong)
        {
            return GoodsReceivedNoteDetailsDAO.Instance.xoaCTPhieuNhap(maPhieu, maThucUong);
        }

        // xóa tất cả chi tiết phiếu nhập khi Phiếu nhập này được hủy
        public bool xoaCTPN_PhieuNhapHuy(int maPhieu)
        {
            return GoodsReceivedNoteDetailsDAO.Instance.xoaCTPhieuNhap_phieuNhapHuy(maPhieu);
        }

        // cập nhật thức uống
        public bool capNhatCTPhieuNhap(int maPhieu, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            return GoodsReceivedNoteDetailsDAO.Instance.capNhatCTPhieuNhap(maPhieu, maThucUong, soLuong, giaBan, thanhTien);
        }

        // trả về tìm thấy hay không tìm thaays CTPN
        public bool CTPhieuNhap(int maPhieu, int maSP)
        {
            var ctpn = GoodsReceivedNoteDetailsDAO.Instance.timPhieuNhap_maPNMaTU(maPhieu, maSP);
            if (ctpn == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
