using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
    public class GoodsReceivedNoteBUS
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static GoodsReceivedNoteBUS instance;

        public static GoodsReceivedNoteBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new GoodsReceivedNoteBUS();
                }
                return instance;
            }
        }

        public void loadTatCaPhieuNhap(GridControl dgv)
        {
            dgv.DataSource = GoodsReceivedNoteDAO.Instance.loadTatCaPhieuNhap();
        }

        public void loadTatCaPhieuNhap_TinhTrangHuy(GridControl dgv)
        {
            dgv.DataSource = GoodsReceivedNoteDAO.Instance.loadTatCaPhieuNhap_Huy();
        }

        // thêm phiếu nhập
        public bool themPhieuNhap(double tongTien, int maNCC, int maNguoiDung)
        {
            return GoodsReceivedNoteDAO.Instance.themPhieuNhap(tongTien, maNCC, maNguoiDung);
        }

        // xóa phiếu nhập
        public bool xoaPhieuNhap(int maPhieu)
        {
            return GoodsReceivedNoteDAO.Instance.xoaPhieuNhap(maPhieu);
        }

        // cập nhật phiếu nhập
        public bool capNhatPhieuNhap(int suppID)
        {
            return GoodsReceivedNoteDAO.Instance.capNhatPhieuNhap(suppID);
        }

        // mã phiếu nhập mới nhất
        public int maPhieuNhapMoiNhat()
        {
            return GoodsReceivedNoteDAO.Instance.RecrviedIDTop1();
        }

        // tổng tiền với mã phiếu
        public decimal tongTien_MaPhieu(int maPhieu)
        {
            return (decimal)GoodsReceivedNoteDAO.Instance.phieuNhap(maPhieu).tienNhap;
        }
    }
}
