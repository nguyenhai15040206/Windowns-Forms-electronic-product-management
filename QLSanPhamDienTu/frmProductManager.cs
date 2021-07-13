using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;

namespace QLSanPhamDienTu
{
    public partial class frmProductManager : Form
    {
        
        public frmProductManager()
        {
            InitializeComponent();
            
        }
        int row = 0;

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ProductBUS.Instance.getAllDataProducts(gridControl1);
            DanhMucBUS.Instance.loadDanhMucTreeView(treeViewDanhMucSP);
            treeViewDanhMucSP.ImageIndex = 0;
            for(int i = 0; i < treeViewDanhMucSP.Nodes[0].Nodes.Count; i ++)
            {
                treeViewDanhMucSP.Nodes[0].Nodes[i].ImageIndex = 1;
                for (int j = 0; j < treeViewDanhMucSP.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    treeViewDanhMucSP.Nodes[0].Nodes[i].Nodes[j].ImageIndex = 2;
                }
            }

        }

        private void treeViewDanhMucSP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ProductBUS.instance.getDataProductFilter(gridControl1, treeViewDanhMucSP);
        }


        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }



        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            frmInsertProduct frm = new frmInsertProduct();
            frm.btnAddNew.Enabled = true;
            frm.btnUpdateProduct.Enabled = false;
            frm.btnResetData.Enabled = true;
            frm.ShowDialog();
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            frmThemDanhMuc frm = new frmThemDanhMuc();
            frm.ShowDialog();
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            row = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, maSP).ToString());
            frmInsertProduct frm = new frmInsertProduct();
            frm.productID(row.ToString());
            frm.btnAddNew.Enabled = false;
            frm.btnResetData.Enabled = false;
            frm.ShowDialog();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            row = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, maSP).ToString());
            DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (ProductBUS.Instance.deleteProduct(row))
                {
                    XtraMessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductBUS.instance.getAllDataProducts(gridControl1);
                }
            }
        }
    }

}
