using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DTO;
using DAO;

namespace BUS
{
    public class CategoryBUS
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static CategoryBUS instance;

        public static CategoryBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryBUS();
                }
                return instance;
            }

        }


        // load danh mục lên treeView 
        public void loadDataCategoriesInTreView(TreeView tv)
        {
            tv.Nodes.Add("Tất cả");
            List<string> nodeCha = CategoryDAO.Instance.getNoteInCategory();
            for(int i=0; i < nodeCha.Count; i++)
            {
                tv.Nodes[0].Nodes.Add(nodeCha[i].ToString());
                tv.Nodes[0].Nodes[i].Tag = "1";
                List<string> nodeCon = CategoryDAO.Instance.getAllDatCategorisByNote(nodeCha[i].ToString());
                for(int j=0; j< nodeCon.Count; j++)
                {
                    tv.Nodes[0].Nodes[i].Nodes.Add(""+nodeCon[j].ToString());
                    tv.Nodes[0].Nodes[i].Nodes[j].Tag = "2";
                }
                nodeCon.Clear();
            }    
        }

        


        public void loadDataCategoriesInGridControl(GridControl gv )
        {
            gv.DataSource = CategoryDAO.Instance.getAllDataCategories();
        }

        public void loadDataCatgoriesNodeInCbo(ComboBox cbo)
        {
            cbo.DataSource = CategoryDAO.Instance.getNoteInCategory();
            cbo.DisplayMember = "ghiChu";
        }

        public void loadDataCategoriesByNoteInCbo(ComboBox cbo, string ghiChu)
        {
            List<DanhMuc> listDM= CategoryDAO.Instance.getAllDataCategoriesByNote(ghiChu);
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
            
            return CategoryDAO.Instance.traVeDanhMucVoiMaSP(maSP).tenDanhMuc;
        }


        // cập nhật
        public bool updateCategory(int categoryID, string CategoryName, int producerID, string note, string logo)
        {
            return CategoryDAO.Instance.updateCategory(categoryID, CategoryName, producerID, note, logo);
        }

        // thêm danh mục
        public bool insertCategory(string CategoryName, int producerID, string note, string logo)
        {
            return CategoryDAO.Instance.insertCategory(CategoryName, producerID, note, logo);
        }

        // xuát danh mục
        public bool deleteCategory(int categoryID)
        {
            return CategoryDAO.Instance.deleteCategory(categoryID);
        }
    }
}
