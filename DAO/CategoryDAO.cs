using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CategoryDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
            
        }

        public List<DanhMuc> getAllDataCategories()
        {
            var listDM = db.DanhMucs.ToList();
            return listDM;
        }    

        public List<string> getNoteInCategory()
        {
            var listDM = db.DanhMucs.Select(m => m.ghiChu).Distinct().ToList();
            return listDM;
        }

        public List<DanhMuc> getAllDataCategoriesByNote(string ghiChu)
        {
            var listSPDM = db.DanhMucs.Where(m => m.ghiChu == ghiChu).ToList();
            return listSPDM;
        }

        public DanhMuc traVeDanhMucVoiMaSP(int maSanPham)
        {
            var danhMuc = (DanhMuc)(from sp in db.SanPhams
                           join dm in db.DanhMucs on sp.maDanhMuc equals dm.maDanhMuc
                           where sp.maSanPham == maSanPham
                           select dm).Single();
            return danhMuc ;
        }

        public List<string> getAllDatCategorisByNote(string nghiChu)
        {
            var listSPDM = db.DanhMucs.Where(m=>m.ghiChu== nghiChu).Select(m=>m.tenDanhMuc).ToList();
            return listSPDM;
        }


        // cập nhập danh mục
        public bool updateCategory(int categoryID, string CategoryName, int producerID, string note, string logo)
        {
            DanhMuc dm = new DanhMuc();
            dm = db.DanhMucs.SingleOrDefault(m => m.maDanhMuc == categoryID);
            if(dm !=null)
            {

                dm.tenDanhMuc = CategoryName;
                dm.maNhaSanXuat = producerID;
                dm.ghiChu = note;
                dm.logoTungDanhMucSP = logo;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        // thêm danh mục
        public bool insertCategory(string CategoryName, int producerID, string note, string logo)
        {
            try
            {
                DanhMuc dm = new DanhMuc();
                dm.tenDanhMuc = CategoryName;
                dm.maNhaSanXuat = producerID;
                dm.ghiChu = note;
                dm.logoTungDanhMucSP = logo;
                db.DanhMucs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool deleteCategory(int categoryID)
        {
            var dm = db.DanhMucs.Single(m => m.maDanhMuc == categoryID);
            if (dm != null)
            {
                db.DanhMucs.DeleteOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            return false;
        }





    }
}
