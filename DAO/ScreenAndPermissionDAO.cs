using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ScreenAndPermissionDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static ScreenAndPermissionDAO instance;

        public static ScreenAndPermissionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenAndPermissionDAO();
                }
                return instance;
            }

        }


        // load danh mục màn hình
        public List<DanhMucManHinh> loadTatCaDanhMucManHinh()
        {
            var listManHinh = db.DanhMucManHinhs.ToList();
            return listManHinh;
        }

        // load danh sách cách quyền chức năng
        public List<QL_PhanQuyenJoin> danhSachQuyenChucNang(int maNhom)
        {
            var quyenChucNang = (from DanhMucManHinh in db.DanhMucManHinhs
                                 join QL_PhanQuyen in db.QL_PhanQuyens 
                                 on new { DanhMucManHinh.maManHinh, maNhom = maNhom } 
                                 equals new { QL_PhanQuyen.maManHinh, QL_PhanQuyen.maNhom} into QL_PhanQuyen_join
                                 from QL_PhanQuyen in QL_PhanQuyen_join.DefaultIfEmpty()
                                 select new QL_PhanQuyenJoin
                                 {
                                     MaManHinh = DanhMucManHinh.maManHinh,
                                     TenManHinh = DanhMucManHinh.tenManHinh,
                                     CoQuyen = (bool?) QL_PhanQuyen.coQuyen
                                 }).ToList();
            return quyenChucNang;
        }


        // thêm quyền cho nhóm người dùng
        public bool capNhat(bool coQuyen, int maNhom, int maManHinh )
        {
            try
            {

                return true;
            }catch
            {
                return false;
            }
        }


    }
}
