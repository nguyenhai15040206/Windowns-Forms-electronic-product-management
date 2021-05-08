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
    public partial class frmQLSanPham : Form
    {
        
        public frmQLSanPham()
        {
            InitializeComponent();
            
        }
        int row = 0;

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.loadTatCaSanPham(gridControl1);
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
            SanPhamBUS.instance.loadSanPhamFillter(gridControl1, treeViewDanhMucSP);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            row = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, maSP).ToString());
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if(SanPhamBUS.Instance.xoaSanPham(row))
                {
                    MessageBox.Show("Xóa thành công");
                    SanPhamBUS.instance.loadTatCaSanPham(gridControl1);
                }    
            }    
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            row = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, maSP).ToString());
            frmThemSanPham frm = new frmThemSanPham();
            frm.maSanPham(row.ToString());
            frm.btnThemMoi.Visible = false;
            frm.ShowDialog();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmThemSanPham frm = new frmThemSanPham();
            frm.btnThemMoi.Visible = true;
            frm.ShowDialog();
        }
    }

}
