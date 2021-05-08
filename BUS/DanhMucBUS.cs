using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
    public class DanhMucBUS
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static DanhMucBUS instance;

        public static DanhMucBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DanhMucBUS();
                }
                return instance;
            }

        }


        // load danh mục lên treeView 
        public void loadDanhMucTreeView(TreeView tv)
        {
            tv.Nodes.Add("Tất cả");
            List<string> nodeCha = DanhMucSanPhamDAO.Instance.loadDanhMuc();
            for(int i=0; i < nodeCha.Count; i++)
            {
                tv.Nodes[0].Nodes.Add(nodeCha[i].ToString());
                tv.Nodes[0].Nodes[i].Tag = "1";
                List<string> nodeCon = DanhMucSanPhamDAO.Instance.loadDMTheoTungLoai(nodeCha[i].ToString());
                for(int j=0; j< nodeCon.Count; j++)
                {
                    tv.Nodes[0].Nodes[i].Nodes.Add(""+nodeCon[j].ToString());
                    tv.Nodes[0].Nodes[i].Nodes[j].Tag = "2";
                }
                nodeCon.Clear();
            }    
        }

        


        public void loadTaCaDMGridView(GridControl gv )
        {
            gv.DataSource = DanhMucSanPhamDAO.Instance.loadTatCaDanhMuc();
        }

        public void loadGhiChuCbo(ComboBox cbo)
        {
            cbo.DataSource = DanhMucSanPhamDAO.Instance.loadDanhMuc();
            cbo.DisplayMember = "ghiChu";
        }

        public void loadDanhMucTheoGhiChu(ComboBox cbo, string ghiChu)
        {
            List<DanhMuc> listDM= DanhMucSanPhamDAO.Instance.loadDanhMucTheoGhiChu(ghiChu);
            if (listDM.Count == 0)
            {
                listDM.Clear();
            }
            cbo.DataSource = listDM;
            cbo.DisplayMember = "tenDanhMuc";
            cbo.ValueMember = "maDanhMuc";
        }

        // trả về mã danh mục tương ứng với sản phẩm
        public string tenDanhMucTheoMaSP(int maSP)
        {
            
            return DanhMucSanPhamDAO.Instance.traVeDanhMucVoiMaSP(maSP).tenDanhMuc;
        }


        // cập nhật
        public bool capNhatDanhMuc(int maDM, string tenDM, int maNSX, string ghiChu, string logo)
        {
            return DanhMucSanPhamDAO.Instance.capNhat(maDM, tenDM, maNSX, ghiChu, logo);
        }

        // thêm danh mục
        public bool themDanhMuc(string tenDM, int maNSX, string ghiChu, string logo)
        {
            return DanhMucSanPhamDAO.Instance.themDanhMuc(tenDM, maNSX, ghiChu, logo);
        }

        // xuát danh mục
        public bool xoaDanhMuc(int maDM)
        {
            return DanhMucSanPhamDAO.Instance.xoaDanhMuc(maDM);
        }
    }
}
