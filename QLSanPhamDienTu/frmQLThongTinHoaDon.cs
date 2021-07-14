using DevExpress.XtraEditors;
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

namespace QLSanPhamDienTu
{
    public partial class frmQLThongTinHoaDon : DevExpress.XtraEditors.XtraForm
    {
        bool tinhtrang = true;
        int maHD = 0;
        public frmQLThongTinHoaDon()
        {
            InitializeComponent();
        }
        public void LamMoiDuLieu()
        {
            dateTimePickerNgayDat.Value = DateTime.Now;
            //dateTimePickerNgayGiao.Value = DateTime.Now;
            foreach (Control item in panel5.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }

        }
        private void frmQLThongTinHoaDon_Load(object sender, EventArgs e)
        {
            checkBox.Checked = true;
            InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtTenKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn4).ToString();
                txtSDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn10).ToString();
                dateTimePickerNgayDat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn9).ToString();
                  
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn13).ToString();
                txtGiamGia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn12).ToString();
                txtThanhTien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumn8).ToString();
                maHD = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaHD).ToString());


                InvoiceDetailsBUS.Instance.getALLCTHoaDon(gridContrrolCTHD, maHD);
            }

            catch
            {
                return;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                tinhtrang = true;
                checkBox.Text = "Khả dụng";
                InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
                LamMoiDuLieu();
            }
            else
            {
                tinhtrang = false;
                checkBox.Text = "Không khả dụng";
                InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
                LamMoiDuLieu();
            }
        }

        private void gridViewHD_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1")
            {
                maHD = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaHD).ToString().Trim());
                if (tinhtrang == true)
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn hủy hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (InvoiceBUS.Instance.deleteInvoice(maHD))
                        {

                            XtraMessageBox.Show("Hóa đơn này đã được hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                int maSP = int.Parse(gridViewHD.GetRowCellValue(i, gridColumn2).ToString());
                                int soLuong = int.Parse(gridViewHD.GetRowCellValue(i, gridColumn3).ToString());
                                ProductBUS.Instance.updateAmouny_Delete(maSP, soLuong);
                            }
                            LamMoiDuLieu();
                            InvoiceBUS.Instance.getALLHoaDon(gridControlHD, true);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Hóa đơn này không khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}