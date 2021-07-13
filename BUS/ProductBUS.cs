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
    public class ProductBUS
    {
        public static ProductBUS instance;

        public static ProductBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ProductBUS();
                }
                return instance;
            }
        }


        // load sản phẩm lên gridView
        public void getAllDataProducts(GridControl gv)
        {
            gv.DataSource = ProductDAO.Instance.getAllDataProducts();
        }



        // load sản phẩm theo ...
        public void getDataProductFilter(GridControl gv, TreeView tv)
        {
            TreeNode node = tv.SelectedNode;
            List<SanPham> listSP = (List<SanPham>)gv.DataSource;
            if(listSP !=null)
            {
                listSP.Clear();
            }
            if(tv.Nodes[0].Text == "Tất cả")
            {
                gv.DataSource = ProductDAO.instance.getAllDataProducts();
            }    
            if(node.Tag=="1")
            {
                gv.DataSource = ProductDAO.instance.getDataProductByNote(node.Text);
            }
            if (node.Tag == "2")
            {
                gv.DataSource = ProductDAO.instance.getDataProductByCategory(node.Text);
            }
        }

        // trẩ về một sản phẩm theo mã sản phẩm
        #region
        // tên sản phẩm
        public string productName(int productID)
        {
            if (ProductDAO.instance.productByID(productID).tenSanPham == null)
                return "";
            return ProductDAO.instance.productByID(productID).tenSanPham;
        }

        public int productAmount(int productID)
        {
            if (ProductDAO.instance.productByID(productID).soLuong == null)
                return 0;
            return (int)ProductDAO.instance.productByID(productID).soLuong;
        }

        public decimal productUnitPrice(int productID)
        {
            if (ProductDAO.instance.productByID(productID).donGia == null)
                return 0;
            return (decimal)ProductDAO.instance.productByID(productID).donGia;
        }

        public decimal productUnitPriceImport(int productID)
        {
            if (ProductDAO.instance.productByID(productID).donGiaNhap == null)
                return 0;
            return (decimal)ProductDAO.instance.productByID(productID).donGiaNhap;
        }

        public string deScription(int productID)
        {
            if (ProductDAO.instance.productByID(productID).moTa == null)
                return "";
            return ProductDAO.instance.productByID(productID).moTa;
        }
        public string deScriptionDetails(int productID)
        {
            if (ProductDAO.instance.productByID(productID).moTaChiTiet == null)
                return "";
            return ProductDAO.instance.productByID(productID).moTaChiTiet;
        }
        public decimal productDiscount(int productID)
        {
            if (ProductDAO.instance.productByID(productID).giamGia == null)
                return 0;
            return (decimal)ProductDAO.instance.productByID(productID).giamGia;
        }
        public string productPromotion(int productID)
        {
            if (ProductDAO.instance.productByID(productID).khuyenMai == null)
                return "";
            return ProductDAO.instance.productByID(productID).khuyenMai;
        }
        public DateTime? productDateUpdate(int productID)
        {
            if (ProductDAO.instance.productByID(productID).ngayCapNhat == null)
                return DateTime.Now;
            return ProductDAO.instance.productByID(productID).ngayCapNhat;
        }
        public string productMadeIn(int productID)
        {
            if (ProductDAO.instance.productByID(productID).xuatXu == null)
                return "";    
            return ProductDAO.instance.productByID(productID).xuatXu;
        }
        public string productImage(int productID)
        {
            if (ProductDAO.instance.productByID(productID).hinhMinhHoa == null)
                return "";
            return ProductDAO.instance.productByID(productID).hinhMinhHoa;
        }

        public string productByCategory(int productID)
        {
            if(ProductDAO.Instance.productByID(productID).DanhMuc.ghiChu == null)
            {
                return "";
            }
            else
                return ProductDAO.Instance.productByID(productID).DanhMuc.ghiChu;
        }
        public string imageListProduct(int productID)
        {
            if(ProductDAO.Instance.productByID(productID).dsHinh==null)
            {
                return "";
            }  
            else
                return ProductDAO.Instance.productByID(productID).dsHinh;
        }
        public string informationDetails(int productID)
        {
            return deScription(productID) +" & "+ deScriptionDetails(productID);
        }

        public bool productStatus(int productID)
        {
            if(ProductDAO.Instance.productByID(productID).tinhTrang ==null )
            {
                return false;
            }
            if (ProductDAO.Instance.productByID(productID).tinhTrang == false)
                return false;
            else
                return true;
        }
        #endregion





        // xóa sản phẩm
        public bool deleteProduct(int productID)
        {
            return ProductDAO.Instance.deletProduct(productID);
        }

        // cập nhật sản phẩm
        public bool updateProduct(int productID,string nameProduct, int amount, double unitPrice, double unitPriceImport, string description, string descriptionDetails,
            string promotion, double discount, DateTime dateUpdate, string madeIn, string image, string imagesList, int catedoryID, bool status)
        {
            return ProductDAO.Instance.updateProduct(productID, nameProduct, amount, unitPrice, unitPriceImport, description, descriptionDetails, promotion, discount, dateUpdate, madeIn, image, imagesList, catedoryID, status);
        }

        // thêm sản phẩm
        public bool insertProduct(string nameProduct, int amount, double unitPrice, double unitPriceImport, string description, string descriptionDetails,
            string promotion, double discount, DateTime dateUpdate, string madeIn, string image, string imagesList, int catedoryID, bool status)
        {
            return ProductDAO.Instance.insertProduct(nameProduct, amount, unitPrice, unitPriceImport, description, descriptionDetails, promotion, discount, dateUpdate, madeIn, image, imagesList, catedoryID, status);
        }

    }
}
