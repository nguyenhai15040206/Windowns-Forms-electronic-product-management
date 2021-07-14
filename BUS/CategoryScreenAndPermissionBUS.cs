using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DTO;

namespace BUS
{
   public class CategoryScreenAndPermissionBUS
    {
        private static CategoryScreenAndPermissionBUS instance;

        public static CategoryScreenAndPermissionBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryScreenAndPermissionBUS();
                }
                return instance;
            }

        }

        // load danh mục màn hình lên GridControl
        public void loadDanhMucManHinh(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<DanhMucManHinh> nd = ScreenAndPermissionDAO.Instance.loadTatCaDanhMucManHinh();
            for (int i = 0; i < nd.Count; i++)
            {
                TreeListNode nodes = tv.AppendNode(null, null);
                nodes.SetValue("name", nd[i].tenManHinh.ToString());
                nodes.Tag = (nd[i].maManHinh.ToString()).ToString();
            }
            tv.EndUnboundLoad();
        }

        // load danh sách quyền chức năng
        public void loadDanhSachQuyenChucNang(GridControl gv, int maNhom)
        {
            gv.DataSource = ScreenAndPermissionDAO.Instance.danhSachQuyenChucNang(maNhom);
        }


        public void phanQuyen(MenuStrip menuStrip1, int maNguoiDung)
        {
            List<int> nhomND = UserBUS.Instance.getMaNhomNguoiDung(maNguoiDung);

            foreach (int item in nhomND)
            {
                List<QL_PhanQuyen> dsQuyen = UserBUS.Instance.getMaManHinh(item);
                for (int i = 0; i < dsQuyen.Count; i++)
                {
                    FindMenuPhanQuyen(menuStrip1.Items, dsQuyen[i].maManHinh.ToString(), (bool)dsQuyen[i].coQuyen);
                }

            }
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {

                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, pScreenName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable; menu.Visible = pEnable;
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;
                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }
            return false;
        }
    }
}
