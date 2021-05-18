using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DTO;

namespace BUS
{
   public class DanhMucManHinhPhanQuyenBUS
    {
        private static DanhMucManHinhPhanQuyenBUS instance;

        public static DanhMucManHinhPhanQuyenBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DanhMucManHinhPhanQuyenBUS();
                }
                return instance;
            }

        }

        // load danh mục màn hình lên GridControl
        public void loadDanhMucManHinh(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<DanhMucManHinh> nd = DanhMucManHinhPhanQuyenDAO.Instance.loadTatCaDanhMucManHinh();
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
            gv.DataSource = DanhMucManHinhPhanQuyenDAO.Instance.danhSachQuyenChucNang(maNhom);
        }   
    }
}
