using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    
    public class NguoiDungDAO
    {
        public static NguoiDungDAO instance;

        public static NguoiDungDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NguoiDungDAO();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        public DataTable loadNhomNguoiDung()
        {
            DataTable table = new DataTable();
            var listNguoiDung = db.QL_NhomNguoiDungs.Select(m=>m.tenNhom).ToList();
            table.Columns.Add("tenNhom");
            foreach(string item in listNguoiDung)
            {
                DataRow row = table.NewRow();
                row["tenNhom"] = item;
                table.Rows.Add(row);
            }    
            return table;

        }



        public List<NguoiDung> loadNguoiDung()
        {
            var listNguoiDung = db.NguoiDungs.ToList();
            return listNguoiDung;
        }

        public DataTable loadDanhMucManHinh(string maNhomNguoiDung)
        {
            DataTable table = new DataTable();
            var listDM = (from mh in db.DanhMucManHinhs
                         join qlpq in db.QL_PhanQuyens on mh.maManHinh equals qlpq.maManHinh into aGroup
                         from a in aGroup.DefaultIfEmpty()
                         select new { mh,  coQuyen= a==null
                         ?false:a.coQuyen}).ToList();
            table.Columns.Add("maManHinh");
            table.Columns.Add("tenManHinh");
            table.Columns.Add("coQuyen");
            foreach (var item in listDM)
                
            {
                DataRow row = table.NewRow();
                
                row["maManHinh"] = item.mh.maManHinh;
                row["tenManHinh"] = item.mh.tenManHinh;
                row["coQuyen"] = item.coQuyen;
            }
            return table;
        }

        // lấy được mã nhóm người dùng với maNguoiDung
        public List<int> getMaNhomNguoiDung(int maNguoiDung)
        {
            var nguoiDung = db.QL_NguoiDungNhomNguoiDungs.Where(m => m.maNguoiDung == maNguoiDung).Select(m=>m.maNhom).ToList();
            return nguoiDung;
        }

        // lấy được danh sách phân quyền từ maNhom
        public List<QL_PhanQuyen> getMaManHinh(int maNhom)
        {
            var phanQuyen = db.QL_PhanQuyens.Where(m => m.maNhom == maNhom).ToList();
            return phanQuyen;
        }

        // các chức năng

        // thêm người dùng
        public bool themNguoiDung(string tenNguoiDung, string tenDangNhap, string matKhau, string diaChi, string soDienThoai, 
            string email, DateTime ngayVaoLam, bool hoatDong )
        {
            try
            {
                NguoiDung nd = new NguoiDung();
                nd.tenNguoiDung = tenNguoiDung;
                nd.tenDangNhap = tenDangNhap;
                nd.matKhau = matKhau;
                nd.diaChi = diaChi;
                nd.soDienThoai = soDienThoai;
                nd.email = email;
                nd.ngayVaoLam = ngayVaoLam;
                nd.hoatDong = hoatDong;
                db.NguoiDungs.InsertOnSubmit(nd);
                db.SubmitChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        // đăng nhập
        public NguoiDung dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            var nguoiDung = db.NguoiDungs.SingleOrDefault(m => m.tenDangNhap == tenDangNhap && m.matKhau == matKhau);
            return nguoiDung;
        }





    }
}
