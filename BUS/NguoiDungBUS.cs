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
            TreeListNode parentForRootNodes = null;
            for(int i =0; i < NguoiDungDAO.Instance.loadNhomNguoiDung().Rows.Count; i++)
            {
                TreeListNode node =
                    tv.Nodes.Add(NguoiDungDAO.Instance.loadNhomNguoiDung().Rows[i][0], parentForRootNodes);
            }
            tv.EndUnboundLoad();
        }


        // load tất cả người dùng
        public void loadNguoiDung(GridControl gv)
        {
            gv.DataSource = NguoiDungDAO.Instance.loadNguoiDung();
        }

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

        // đăng nhập
        public bool dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            try
            {
                var nguoiDung = NguoiDungDAO.Instance.dangNhapHeThong(tenDangNhap, Encryptor.MD5Hash(matKhau));
                if (nguoiDung == null)
                {
                    return false;
                }
                if (nguoiDung.hoatDong == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }catch
            {
                return false;
            }
        }
    }
}
