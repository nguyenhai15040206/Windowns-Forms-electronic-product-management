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
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;
        public static KhachHangBUS Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new KhachHangBUS();
                }
                return instance;
            }
           
        }

        public void LoadTatCaKhachHang(GridControl grv)
        {
            grv.DataSource = KhachHangDAOcs.Instance.LoadTatCaKhachHang();
        }

        public bool ThemMotKhachHang(string tenKH, string sdt, string email, string diaChi)
        {
            return KhachHangDAOcs.Instance.ThemMotKhachHang(tenKH, sdt, email, diaChi);
        }

        public bool KtraSoDienThoaiTonTai(string input)
        {
            return KhachHangDAOcs.Instance.KtraSoDienThoaiTonTai(input);
        }


        public bool capNhatThongTinKH(int maKH, string tenKH, string sdt, string email, string diaChi)
        {
            return KhachHangDAOcs.Instance.capNhatThongTinKH(maKH, tenKH, sdt, email, diaChi);
        }

        public bool xoaKhachHang(int maKH)
        {
            return KhachHangDAOcs.Instance.xoaKhachHang(maKH);
        }
    }
}
