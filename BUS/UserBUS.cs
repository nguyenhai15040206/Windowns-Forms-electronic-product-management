using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Data;
using System.Data.Sql;

namespace BUS
{
    public class UserBUS
    {
        public static UserBUS instance;

        public static UserBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new UserBUS();
                }
                return instance;
            }
        }

        // load nhóm người dùng lên TreeList
        public void loadNhomNguoiDung(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<QL_NhomNguoiDung> nd = UserDAO.Instance.loadNhomNguoiDung();
            for (int i = 0; i < nd.Count; i++)
            {
                TreeListNode nodes = tv.AppendNode(null, null);
                nodes.SetValue("name", nd[i].tenNhom.ToString());
                nodes.Tag = (nd[i].maNhom.ToString()).ToString();
                string maNhom = (string)nodes.Tag;
                List<NguoiDung> ndNhomND = UserDAO.Instance.loadNguoiDungTheoNhom(int.Parse(maNhom.ToString()));
                for(int j=0;j < ndNhomND.Count; j++)
                {
                    TreeListNode childNodes = null;
                    childNodes = tv.AppendNode(null, nodes);
                    childNodes.SetValue("name", "Tài khoản: "+ndNhomND[j].tenDangNhap);
                }    


            }
            tv.EndUnboundLoad();
        }

        public void loadNhomNguoiDung_GridCOntrol(GridControl gv)
        {
            gv.DataSource = UserDAO.Instance.loadNhomNguoiDung();
        }

        // load dười dùng chưa có nhóm
        public void loadNguoiDungChuaCoNhom(GridControl dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = UserDAO.Instance.loadNguoiDungChuaCoNhom();
        }    


        // load tất cả người dùng
        public void loadNguoiDung(GridControl gv)
        {
            gv.DataSource = UserDAO.Instance.loadNguoiDung();
        }


        //load danh sách Nhóm người dùng
        public void loadDSNhomNguoiDungComboBox(ComboBox cbo)
        {
            cbo.DataSource = UserDAO.Instance.loadNhomNguoiDung();
            cbo.DisplayMember = "tenNhom";
            cbo.ValueMember = "maNhom";
        }

        public void loadDSNhomNguoiDungTheoMaNhom(int maNhom, GridControl gv)
        {
            gv.DataSource = null;
            gv.DataSource = UserDAO.Instance.loadNguoiDungTheoNhom(maNhom);
        }
        // load màn hình
        public void loadDMManHinh(GridControl gv)
        {
            gv.DataSource = UserDAO.Instance.loadDanhMucManHinh("admin");
        }


        public int layMaNHomNguoiDungDauTien()
        {
            return UserDAO.Instance.maNhomNguoiDungDauTien();
        }

        // get mã nhóm người dùng
        public List<int> getMaNhomNguoiDung(int maNguoiDung)
        {
            return UserDAO.Instance.getMaNhomNguoiDung(maNguoiDung);
        }

        // get ma ManHinh
        public List<QL_PhanQuyen> getMaManHinh(int maNhom)
        {
            return UserDAO.Instance.getMaManHinh(maNhom);
        }


        // chức năng
        // thêm người dùng
        public bool themNguoiDung(string tenNguoiDung, string tenDangNhap, string matKhau, string diaChi, string soDienThoai,
            string email, DateTime ngayVaoLam, bool hoatDong)
        {
            return UserDAO.Instance.themNguoiDung(tenNguoiDung, tenDangNhap, Encryptor.MD5Hash(matKhau), diaChi, soDienThoai, email, ngayVaoLam, hoatDong);
        }

        // thêm người dùng vào nhóm
        public bool themNguoiDungVaoNhom(int maNguoiDung, int maNhom, string ghiChu)
        {
            return UserDAO.Instance.themNguoiDungVaoNhom(maNguoiDung, maNhom, ghiChu);
        }

        // xóa người dùng ra khỏi nhóm
        public bool xoaNguoiDungRaKhoiNhom(int maNguoiDung, int maNhom)
        {
            return UserDAO.Instance.xoaNguoiDungRaKhoiNhom(maNguoiDung, maNhom);
        }

        // đăng nhập

        // checkConfig
        public int checkConfig()
        {
            return UserDAO.Instance.checConfig();
        }

        public void getServerName(ComboBox cbo)
        {
            cbo.Items.Clear();
            cbo.Items.Add(@".\SQLEXPRESS");
            cbo.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
        }

        public void getDatabaseName(string server, string user, string pass, ComboBox cbo)
        {
            try
            {
                cbo.DataSource = UserDAO.Instance.getDatabaseName(server, user, pass);
                cbo.DisplayMember = "name";
            }
            catch
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        public void saveConfig(string pServer, string pUser, string pPass, string pDatabaseName)
        {
            UserDAO.Instance.saveConfig(pServer, pUser, pPass, pDatabaseName);
        }
        public int dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            var nguoiDung = UserDAO.Instance.dangNhapHeThong(tenDangNhap, (matKhau));
            if (nguoiDung == null)
            {
                return 100;
            }
            if (nguoiDung.hoatDong == false)
            {
                return 200;
            }
            else
            {
                return 300;
            }
        }

        // láy ra mã người dùng khi đăng nhập
        public int maNguoiDung(string tenDangNhap)
        {
            return UserDAO.Instance.ttNguoiDung(tenDangNhap).maNguoiDung;
        }

        // lấy ra Tên người dùng và số điện thoại người dùng khi đăng nhập
        public string thongTinNguoiDung(string tenDangNhap)
        {

            var nd = UserDAO.Instance.ttNguoiDung(tenDangNhap);
            return nd.tenNguoiDung + " - " +
                nd.soDienThoai;
        }

        public string ttNguoiDung_tenND(int maND)
        {
            var nd = UserDAO.Instance.ttNguoiDung_tenND(maND);
            return nd.tenNguoiDung + " - " + nd.soDienThoai;
        }


        ///Kiểm tra số điện thoại tồn tại
        ///
        public bool KTraSoDienThoaiTonTai(string input)
        {
            return UserDAO.Instance.LayNguoiDungCoSoDienThoaiTonTai(input);
        }


        public bool CapNhatThongTinNguoiDung(int ma, string tenNguoiDung, string tenDangNhap, string matKhau, string diaChi, string soDienThoai,
            string email, DateTime ngayVaoLam, bool hoatDong)
        {
            return UserDAO.Instance.CapNhatThongTinNguoiDung(ma, tenNguoiDung, tenDangNhap, matKhau, diaChi, soDienThoai, email, ngayVaoLam, hoatDong);
        }

        public bool KtraTenNguoiDung(string tenNguoiDung)
        {
            return UserDAO.instance.KtraTenNguoiDung(tenNguoiDung);
        }

        public bool XoaNguoiDung( int ma)
        {
            return UserDAO.instance.XoaNguoiDung(ma);
        }

    }
}
