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
using DevExpress.XtraReports.UI;
using QLSanPhamDienTu.Report;

namespace QLSanPhamDienTu
{
    public partial class frmInvocieManager : DevExpress.XtraEditors.XtraForm
    {
        bool tinhtrang = true;
        int maHD = 0;
        public frmInvocieManager()
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


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            XtraReportInvoiceDetails rpt = new XtraReportInvoiceDetails();
            XRLabel xRLabel = rpt.xrLabelSumMoney;
            double sumMoney = InvoiceBUS.Instance.sumMoney(maHD);
            xRLabel.Text = CheckDataInput.Instances.formatMoneyToString((double)sumMoney);
            rpt.DataSource = ReportBUS.Instance.printInvoice(maHD);
            rpt.ShowPreviewDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtTenKH.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenKH).ToString();
                txtSDT.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSDT).ToString();
                dateTimePickerNgayDat.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNgayLap).ToString();
                txtGiamGia.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGIamGia).ToString();
                txtThanhTien.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTongTien).ToString();
                maHD = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaHD).ToString());

                checkBox.Checked = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTinhTrang).ToString());
                InvoiceDetailsBUS.Instance.getALLCTHoaDon(gridContrrolCTHD, maHD);
            }

            catch
            {
                return;
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (tinhtrang == true)
            {
                if (e.Column.Name == "gridColumn1")
                {
                    maHD = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaHD).ToString().Trim());
                    if (tinhtrang == true)
                    {
                        if (XtraMessageBox.Show("Bạn có chắc muốn hủy hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (InvoiceBUS.Instance.deleteInvoice(maHD))
                            {

                                XtraMessageBox.Show("Hóa đơn này đã được hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int i = 0; i < gridViewHD.RowCount; i++)
                                {
                                    int maSP = int.Parse(gridViewHD.GetRowCellValue(i, gridColumn4).ToString());
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

        private void checkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox.Checked==true)
            {
                tinhtrang = true;
                InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
            }
            else
            {
                tinhtrang = false;
                InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
            }
        }
    }
}