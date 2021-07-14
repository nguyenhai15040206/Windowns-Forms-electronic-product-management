using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    
    public class UserDAO
    {
        public static UserDAO instance;

        public static UserDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();


        // load nhóm người dùng
        public List<QL_NhomNguoiDung> loadNhomNguoiDung()
        {
            var listNguoiDung = db.QL_NhomNguoiDungs.ToList();   
            return listNguoiDung;

        }





        // load người dùng
        public List<NguoiDung> loadNguoiDung()
        {
            var listNguoiDung = db.NguoiDungs.ToList();
            return listNguoiDung;
        }
        // load người dùng theo mã nhóm người dùng
        public List<NguoiDung> loadNguoiDungTheoNhom(int maNhom)
        {
            var listNguoiDung = (from nd in db.NguoiDungs
                                 join nhom in db.QL_NguoiDungNhomNguoiDungs on nd.maNguoiDung equals nhom.maNguoiDung
                                 where nhom.maNhom == maNhom
                                 select (nd)).ToList();
            return listNguoiDung;
        }

        // load người dùng chưa có trong nhóm
        public List<NguoiDung> loadNguoiDungChuaCoNhom()
        {
            var listNguoiDung = (from nd in db.NguoiDungs
                                where
                                  !
                                    (from QL_NguoiDungNhomNguoiDung in db.QL_NguoiDungNhomNguoiDungs
                                     select new
                                     {
                                         MaNguoiDung = (int)QL_NguoiDungNhomNguoiDung.NguoiDung.maNguoiDung
                                     }).Contains(new { MaNguoiDung = nd.maNguoiDung })
                                select nd).ToList();
            return listNguoiDung;
        }

        // lấy Nhóm người dùng có mã đầu tiền
        public int maNhomNguoiDungDauTien()
        {
            var maNhom = db.QL_NhomNguoiDungs.Take(1).OrderByDescending(m => m.maNhom).Single();
            return maNhom.maNhom;
        }


        // load danh mục màn hình
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
        // thêm người dùng vào nhóm người dùng
        public bool themNguoiDungVaoNhom(int maNguoiDung, int maNhom, string ghiChu)
        {
            try
            {
                QL_NguoiDungNhomNguoiDung nd = new QL_NguoiDungNhomNguoiDung();
                nd.maNguoiDung = maNguoiDung;
                nd.maNhom = maNhom;
                nd.ghiChu = ghiChu;
                db.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(nd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaNguoiDungRaKhoiNhom(int maNguoiDung, int maNhom)
        {
            try
            {
                var nguoiDung = db.QL_NguoiDungNhomNguoiDungs.SingleOrDefault(m => m.maNguoiDung == maNguoiDung && m.maNhom == maNhom);
                db.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(nguoiDung);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

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

        // check config
        public int checConfig()
        {
            return CheckConfig.Instance.checConfig();
        }

        public  DataTable getServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public  DataTable getDatabaseName(string server, string user, string pass)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select name from sys.databases", "Data Source=" + server + ";Initial Catalog=master;User ID=" + user + ";Password=" + pass + "");
            adapter.Fill(table);
            return table;
        }

        public void saveConfig(string pServer, string pUser, string pPass, string pDatabaseName)
        {
            CheckConfig.Instance.saveConfig(pServer, pUser, pPass, pDatabaseName);
        }
        public NguoiDung dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            var nguoiDung = db.NguoiDungs.SingleOrDefault(m => m.tenDangNhap == tenDangNhap && m.matKhau == matKhau);
            return nguoiDung;
        }
        public bool LayNguoiDungCoSoDienThoaiTonTai(string input)
        {
            try
            {
                var sdt = db.NguoiDungs.Where(m => m.soDienThoai == input).ToList();
                if(sdt.Count>0)
                {
                    return false;
                }    
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhatThongTinNguoiDung(int ma, string tenNguoiDung, string tenDangNhap, string matKhau, string diaChi, string soDienThoai,
            string email, DateTime ngayVaoLam, bool hoatDong)
        {
            try
            {
                var nv = db.NguoiDungs.SingleOrDefault(m => m.maNguoiDung == ma);
                if(nv==null)
                {
                    return false;
                } 
                if(soDienThoai==nv.soDienThoai)
                {
                    nv.tenNguoiDung = tenNguoiDung;
                    nv.tenDangNhap = tenDangNhap;
                    nv.matKhau = matKhau;
                    nv.email = email;
                    nv.diaChi = diaChi;
                    nv.ngayVaoLam = ngayVaoLam;
                    nv.hoatDong = hoatDong;
                    db.SubmitChanges();
                    return true;
                }   
                else
                {
                    if(LayNguoiDungCoSoDienThoaiTonTai(soDienThoai))
                    {
                        nv.tenNguoiDung = tenNguoiDung;
                        nv.tenDangNhap = tenDangNhap;
                        nv.matKhau = matKhau;
                        nv.soDienThoai = soDienThoai;
                        nv.email = email;
                        nv.diaChi = diaChi;
                        nv.ngayVaoLam = ngayVaoLam;
                        nv.hoatDong = hoatDong;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }    

                }    
            }
            catch
            {
                return false;
            }
        }


        public bool KtraTenNguoiDung(string tenNguoiDung)
        {
            try
            {
                var nd = db.NguoiDungs.Where(m => m.tenDangNhap == tenNguoiDung).ToList();
                if(nd.Count>0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool XoaNguoiDung(int maNgDung)
        {
            try
            {
                NguoiDung nd = db.NguoiDungs.SingleOrDefault(m => m.maNguoiDung == maNgDung);
                db.NguoiDungs.DeleteOnSubmit(nd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public NguoiDung ttNguoiDung(string tenDangNhap)
        {
            return db.NguoiDungs.AsEnumerable().FirstOrDefault(m => m.tenDangNhap == tenDangNhap && m.hoatDong == true);
        }

        //
        public NguoiDung ttNguoiDung_tenND(int maND)
        {
            return db.NguoiDungs.SingleOrDefault(m => m.maNguoiDung == maND && m.hoatDong == true);
        }

        // kiểm tra số điện thoại
        public NguoiDung ttNguoiDung_SoDienThoai(string soDienThoai)
        {
            return db.NguoiDungs.SingleOrDefault(m => m.soDienThoai == soDienThoai && m.hoatDong == true);
        }

        // load người dùng theo tình trạng
        public List<NguoiDung> loadNguoiDung_TinhTrang(bool tinhTrang)
        {
            var listNguoiDung = db.NguoiDungs.Where(m => m.hoatDong == tinhTrang).ToList();
            return listNguoiDung;
        }

        //
        // load danh mục màn hình
        public List<DanhMucManHinh> loadTatCaDanhMucManHinh()
        {
            var listManHinh = db.DanhMucManHinhs.ToList();
            return listManHinh;
        }
        //
        // load danh sách cách quyền chức năng
        public List<NewPermission> danhSachQuyenChucNang(int maNhom)
        {
            var quyenChucNang = (from DanhMucManHinh in db.DanhMucManHinhs
                                 join QL_PhanQuyen in db.QL_PhanQuyens
                                 on new { DanhMucManHinh.maManHinh, maNhom = maNhom }
                                 equals new { QL_PhanQuyen.maManHinh, QL_PhanQuyen.maNhom } into QL_PhanQuyen_join
                                 from QL_PhanQuyen in QL_PhanQuyen_join.DefaultIfEmpty()
                                 select new NewPermission
                                 {
                                     MaManHinh = DanhMucManHinh.maManHinh,
                                     TenManHinh = DanhMucManHinh.tenManHinh,
                                     CoQuyen = (bool?)QL_PhanQuyen.coQuyen
                                 }).ToList();
            return quyenChucNang;
        }

        // xóa người dùng, thực ra là tài khoản và thông tin nhân viên này không còn khả dụng nữa
        public bool xoaNhanVien(int maNguoiDung, bool hoatDong)
        {
            try
            {
                NguoiDung nd = db.NguoiDungs.SingleOrDefault(m => m.maNguoiDung == maNguoiDung);
                nd.hoatDong = hoatDong;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // cập nhật nhân viên
        public bool capNhatNhanVien(int maNhanVien, string tenNguoiDung, string diaChi, string soDienThoai,
            string email, bool hoatDong)
        {
            try
            {
                NguoiDung nd = db.NguoiDungs.SingleOrDefault(m => m.maNguoiDung == maNhanVien);
                if (nd == null)
                {
                    return false;
                }
                if (soDienThoai == nd.soDienThoai)
                {
                    nd.tenNguoiDung = tenNguoiDung;
                    nd.diaChi = diaChi;
                    nd.email = email;
                    nd.hoatDong = hoatDong;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    if (ttNguoiDung_SoDienThoai(soDienThoai) == null)
                    {
                        nd.tenNguoiDung = tenNguoiDung;
                        nd.diaChi = diaChi;
                        nd.email = email;
                        nd.soDienThoai = soDienThoai;
                        nd.hoatDong = hoatDong;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        //
        // phân quyền
        public bool phanQuyen(int maNhom, int maaManHinh, bool coQuyen)
        {
            try
            {
                var phanQuyen = db.QL_PhanQuyens.SingleOrDefault(m => m.maManHinh == maaManHinh && m.maNhom == maNhom);
                phanQuyen.coQuyen = coQuyen;
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
