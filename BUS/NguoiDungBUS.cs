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
    }
}
