using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ProductDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            { 
            
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }

        // loat tất cả sản phẩm
        public List<SanPham> getAllDataProducts()
        {
            var listSP = db.SanPhams.ToList();

            return listSP;
        }

        // load sản phẩm theo danh mục ghiChu

        public List<SanPham> getDataProductByNote(string note)
        {
            var listSP = db.SanPhams.Where(m => m.DanhMuc.ghiChu == note).ToList();
            return listSP;
        }

        // load sản phẩm theo từng danh mục tên danh mục
        public List<SanPham> getDataProductByCategory(string categoryName)
        {
            var listSP = db.SanPhams.Where(m => m.DanhMuc.tenDanhMuc == categoryName).ToList();
            return listSP;
        }

        // trả về thông tin của một sản phẩm
        #region
        public SanPham productByID(int productID)
        {
            var sanPham = db.SanPhams.SingleOrDefault(m => m.maSanPham == productID);
            return sanPham;
        }

        #endregion



        // thao tác các chức năng
        public bool deletProduct(int productID)
        {
            var sp = db.SanPhams.Single(m => m.maSanPham == productID);
            if(sp !=null)
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool insertProduct(string nameProduct, int amount, double unitPrice, double unitPriceImport,string description, string descriptionDetails,
            string promotion, double discount, DateTime dateUpdate, string madeIn, string image, string imagesList, int catedoryID, bool status)
        {
            try
            {
                SanPham sp = new SanPham();
                sp.tenSanPham = nameProduct;
                sp.soLuong = amount;
                sp.donGia = (decimal)unitPrice;
                sp.donGiaNhap = (decimal)unitPriceImport;
                sp.moTa = description;
                sp.moTaChiTiet = descriptionDetails;
                sp.khuyenMai = promotion;
                sp.giamGia = (decimal)discount;
                sp.ngayCapNhat = dateUpdate;
                sp.xuatXu = madeIn;
                sp.hinhMinhHoa = image;
                sp.dsHinh = imagesList;
                sp.maDanhMuc = catedoryID;
                sp.tinhTrang = status;
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateProduct(int productID, string nameProduct, int amount, double unitPrice, double unitPriceImport, string description, string descriptionDetails,
            string promotion, double discount, DateTime dateUpdate, string madeIn, string image, string imagesList, int catedoryID, bool status)
        {
            try
            {
                var sp = db.SanPhams.SingleOrDefault(m => m.maSanPham == productID);
                if(sp == null)
                {
                    return false;
                }
                sp.tenSanPham = nameProduct;
                sp.soLuong = amount;
                sp.donGia = (decimal)unitPrice;
                sp.donGiaNhap = (decimal)unitPriceImport;
                sp.moTa = description;
                sp.moTaChiTiet = descriptionDetails;
                sp.khuyenMai = promotion;
                sp.giamGia = (decimal)discount;
                sp.ngayCapNhat = dateUpdate;
                sp.xuatXu = madeIn;
                sp.hinhMinhHoa = image;
                sp.dsHinh = imagesList;
                sp.tinhTrang = status;
                sp.maDanhMuc = catedoryID;
                db.SubmitChanges();
                return true;
            }catch
            {
                return false;
            }
        }



        
    }
}
