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
    public class NguoiDungBUS
    {
        public static NguoiDungBUS instance;

        public static NguoiDungBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NguoiDungBUS();
                }
                return instance;
            }
        }

        // load nhóm người dùng lên TreeList
        public void loadNhomNguoiDung(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<QL_NhomNguoiDung> nd = NguoiDungDAO.Instance.loadNhomNguoiDung();
            for (int i = 0; i < nd.Count; i++)
            {
                TreeListNode nodes = tv.AppendNode(null, null);
                nodes.SetValue("name", nd[i].tenNhom.ToString());
                nodes.Tag = (nd[i].maNhom.ToString()).ToString();
                string maNhom = (string)nodes.Tag;
                List<NguoiDung> ndNhomND = NguoiDungDAO.Instance.loadNguoiDungTheoNhom(int.Parse(maNhom.ToString()));
                for(int j=0;j < ndNhomND.Count; j++)
                {
                    TreeListNode childNodes = null;
                    childNodes = tv.AppendNode(null, nodes);
                    childNodes.SetValue("name", "Tài khoản: "+ndNhomND[j].tenDangNhap);
                }    


            }
            tv.EndUnboundLoad();
        }

        // load dười dùng chưa có nhóm
        public void loadNguoiDungChuaCoNhom(GridControl dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = NguoiDungDAO.Instance.loadNguoiDungChuaCoNhom();
        }    


        // load tất cả người dùng
        public void loadNguoiDung(GridControl gv)
        {
            gv.DataSource = NguoiDungDAO.Instance.loadNguoiDung();
        }


        //load danh sách Nhóm người dùng
        public void loadDSNhomNguoiDungComboBox(ComboBox cbo)
        {
            cbo.DataSource = NguoiDungDAO.Instance.loadNhomNguoiDung();
            cbo.DisplayMember = "tenNhom";
            cbo.ValueMember = "maNhom";
        }

        public void loadDSNhomNguoiDungTheoMaNhom(int maNhom, GridControl gv)
        {
            gv.DataSource = null;
            gv.DataSource = NguoiDungDAO.Instance.loadNguoiDungTheoNhom(maNhom);
        }
        // load màn hình
        public void loadDMManHinh(GridControl gv)
        {
            gv.DataSource = NguoiDungDAO.Instance.loadDanhMucManHinh("admin");
        }




        // get mã nhóm người dùng
        public List<int> getMaNhomNguoiDung(int maNguoiDung)
        {
            return NguoiDungDAO.Instance.getMaNhomNguoiDung(maNguoiDung);
        }

        // get ma ManHinh
        public List<QL_PhanQuyen> getMaManHinh(int maNhom)
        {
            return NguoiDungDAO.Instance.getMaManHinh(maNhom);
        }


        // chức năng
        // thêm người dùng
        public bool themNguoiDung(string tenNguoiDung, string tenDangNhap, string matKhau, string diaChi, string soDienThoai,
            string email, DateTime ngayVaoLam, bool hoatDong)
        {
            return NguoiDungDAO.Instance.themNguoiDung(tenNguoiDung, tenDangNhap, Encryptor.MD5Hash(matKhau), diaChi, soDienThoai, email, ngayVaoLam, hoatDong);
        }

        // thêm người dùng vào nhóm
        public bool themNguoiDungVaoNhom(int maNguoiDung, int maNhom, string ghiChu)
        {
            return NguoiDungDAO.Instance.themNguoiDungVaoNhom(maNguoiDung, maNhom, ghiChu);
        }

        // xóa người dùng ra khỏi nhóm
        public bool xoaNguoiDungRaKhoiNhom(int maNguoiDung, int maNhom)
        {
            return NguoiDungDAO.Instance.xoaNguoiDungRaKhoiNhom(maNguoiDung, maNhom);
        }

        // đăng nhập

        // checkConfig
        public int checkConfig()
        {
            return NguoiDungDAO.Instance.checConfig();
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
                cbo.DataSource = NguoiDungDAO.Instance.getDatabaseName(server, user, pass);
                cbo.DisplayMember = "name";
            }
            catch
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        public void saveConfig(string pServer, string pUser, string pPass, string pDatabaseName)
        {
            NguoiDungDAO.Instance.saveConfig(pServer, pUser, pPass, pDatabaseName);
        }
        public int dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            var nguoiDung = NguoiDungDAO.Instance.dangNhapHeThong(tenDangNhap, Encryptor.MD5Hash(matKhau));
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
    }
}
