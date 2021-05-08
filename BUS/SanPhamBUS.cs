using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;
using DTO;

namespace BUS
{
    public class SanPhamBUS
    {
        public static SanPhamBUS instance;

        public static SanPhamBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SanPhamBUS();
                }
                return instance;
            }
        }


        // load sản phẩm lên gridView
        public void loadTatCaSanPham(GridControl gv)
        {
            gv.DataSource = SanPhamDAO.Instance.loadTatCaSanPham();
        }



        // load sản phẩm theo ...
        public void loadSanPhamFillter(GridControl gv, TreeView tv)
        {
            TreeNode node = tv.SelectedNode;
            List<SanPham> listSP = (List<SanPham>)gv.DataSource;
            if(listSP !=null)
            {
                listSP.Clear();
            }
            if(tv.Nodes[0].Text == "Tất cả")
            {
                gv.DataSource = SanPhamDAO.instance.loadTatCaSanPham();
            }    
            if(node.Tag=="1")
            {
                gv.DataSource = SanPhamDAO.instance.loadSanPhamTheoGhiChu(node.Text);
            }
            if (node.Tag == "2")
            {
                gv.DataSource = SanPhamDAO.instance.loadSanPhamTheoTenDanhMuc(node.Text);
            }
        }

        // trẩ về một sản phẩm theo mã sản phẩm
        #region
        // tên sản phẩm
        public string tenSanPham(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).tenSanPham == null)
                return "";
            return SanPhamDAO.instance.sanPham(maSanPham).tenSanPham;
        }

        public int soLuong(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).soLuong == null)
                return 0;
            return (int)SanPhamDAO.instance.sanPham(maSanPham).soLuong;
        }

        public decimal donGia(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).donGia == null)
                return 0;
            return (decimal)SanPhamDAO.instance.sanPham(maSanPham).donGia;
        }

        public string moTa(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).moTa == null)
                return "";
            return SanPhamDAO.instance.sanPham(maSanPham).moTa;
        }
        public string moTaChiTiet(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).moTaChiTiet == null)
                return "";
            return SanPhamDAO.instance.sanPham(maSanPham).moTaChiTiet;
        }
        public decimal giamGia(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).giamGia == null)
                return 0;
            return (decimal)SanPhamDAO.instance.sanPham(maSanPham).giamGia;
        }
        public string khuyeMai(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).khuyenMai == null)
                return "";
            return SanPhamDAO.instance.sanPham(maSanPham).khuyenMai;
        }
        public DateTime? ngayCapNhat(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).ngayCapNhat == null)
                return DateTime.Now;
            return SanPhamDAO.instance.sanPham(maSanPham).ngayCapNhat;
        }
        public string xuatXu(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).xuatXu == null)
                return "";    
            return SanPhamDAO.instance.sanPham(maSanPham).xuatXu;
        }
        public string hinhMinhHoa(int maSanPham)
        {
            if (SanPhamDAO.instance.sanPham(maSanPham).hinhMinhHoa == null)
                return "";
            return SanPhamDAO.instance.sanPham(maSanPham).hinhMinhHoa;
        }

        public string sanPhamTheoDanhMuc(int maSanPham)
        {
            if(SanPhamDAO.Instance.sanPham(maSanPham).DanhMuc.ghiChu == null)
            {
                return "";
            }
            else
                return SanPhamDAO.Instance.sanPham(maSanPham).DanhMuc.ghiChu;
        }
        public string dsHinh(int maSanPham)
        {
            if(SanPhamDAO.Instance.sanPham(maSanPham).dsHinh==null)
            {
                return "";
            }  
            else
                return SanPhamDAO.Instance.sanPham(maSanPham).dsHinh;
        }
        public string thongTinChiTiet(int maSanPham)
        {
            return moTa(maSanPham) +" & "+ moTaChiTiet(maSanPham);
        }

        public bool tinhTrang(int maSanPham)
        {
            if(SanPhamDAO.Instance.sanPham(maSanPham).tinhTrang ==null )
            {
                return false;
            }
            if (SanPhamDAO.Instance.sanPham(maSanPham).tinhTrang == false)
                return false;
            else
                return true;
        }
        #endregion





        // xóa sản phẩm
        public bool xoaSanPham(int maSP)
        {
            return SanPhamDAO.Instance.xoaSanPham(maSP);
        }

        // cập nhật sản phẩm
        public bool capNhatSanPham(int maSanPham, string tenSanPham, int soLuong, double donGia, string moTa, string moTaChiTiet,
            string khuyenMai, double giamGia, DateTime ngayCapNhat, string xuatXu, string hinhMinhHoa, string dsHinh, bool tinhTrang, int maDanhMuc)
        {
            return SanPhamDAO.Instance.capNhatSanPham(maSanPham, tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc);
        }

        // thêm sản phẩm
        public bool themSanPham( string tenSanPham, int soLuong, double donGia, string moTa, string moTaChiTiet,
            string khuyenMai, double giamGia, DateTime ngayCapNhat, string xuatXu, string hinhMinhHoa, string dsHinh, bool tinhTrang, int maDanhMuc)
        {
            return SanPhamDAO.Instance.themSanPham(tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc);
        }
    }
}
