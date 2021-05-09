using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DanhMucSanPhamDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static DanhMucSanPhamDAO instance;

        public static DanhMucSanPhamDAO Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new DanhMucSanPhamDAO();
                }
                return instance;
            }
            
        }

        public List<DanhMuc> loadTatCaDanhMuc()
        {
            var listDM = db.DanhMucs.ToList();
            return listDM;
        }    

        public List<string> loadDanhMuc()
        {
            var listDM = db.DanhMucs.Select(m => m.ghiChu).Distinct().ToList();
            return listDM;
        }

        public List<DanhMuc> loadDanhMucTheoGhiChu(string ghiChu)
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

        public List<string> loadDMTheoTungLoai(string nghiChu)
        {
            var listSPDM = db.DanhMucs.Where(m=>m.ghiChu== nghiChu).Select(m=>m.tenDanhMuc).ToList();
            return listSPDM;
        }


        // cập nhập danh mục
        public bool capNhat(int maDM, string tenDM, int maNSX, string ghiChu, string log)
        {
            DanhMuc dm = new DanhMuc();
            dm = db.DanhMucs.SingleOrDefault(m => m.maDanhMuc == maDM);
            if(dm !=null)
            {

                dm.tenDanhMuc =tenDM;
                dm.maNhaSanXuat = maNSX;
                dm.ghiChu = ghiChu;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        // thêm danh mục
        public bool themDanhMuc(string tenDM, int maNSX, string ghiChu, string logo)
        {
            try
            {
                DanhMuc dm = new DanhMuc();
                dm.tenDanhMuc = tenDM;
                dm.maNhaSanXuat = maNSX;
                dm.ghiChu = ghiChu;
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


        public bool xoaDanhMuc(int maDM)
        {
            var dm = db.DanhMucs.Single(m => m.maDanhMuc == maDM);
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
