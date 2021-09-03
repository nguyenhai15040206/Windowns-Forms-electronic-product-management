using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLSanPhamDienTu.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSanPhamDienTu
{
    public partial class frmInvoice : Form
    {
        bool tinhtrang = true;
        private string xacNhanDonHang = string.Empty;
        int maHD = 0;
        private int? maNguoiDung= 0;
        public frmInvoice()
        {
            InitializeComponent();
            dateTimePickerNgayDat.Value = DateTime.Now;
            //dateTimePickerNgayGiao.Value = DateTime.Now;
            foreach (Control item in panel5.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            checkBox.Checked = true;
            InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
            btnCapNhat.Visible = false;
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            XtraReportInvoiceDetails rpt = new XtraReportInvoiceDetails();
            XRLabel xRLabel = rpt.xrLabelSumMoney;
            double sumMoney = InvoiceBUS.Instance.sumMoney(maHD);
            xRLabel.Text = CheckDataInput.Instances.formatMoneyToString((double)sumMoney);
            rpt.DataSource = ReportBUS.Instance.printInvoice(maHD);
            rpt.ShowPreviewDialog();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtTenKH.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenKH).ToString();
                txtSDT.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSDT).ToString();
                dateTimePickerNgayDat.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNgayLap).ToString();
                txtGiamGia.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGIamGia).ToString();
                txtThanhTien.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTongTien).ToString()));
                maHD = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaHD).ToString());
                maNguoiDung = InvoiceBUS.Instance.UserIDByInvoiceID(maHD);
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
                                    int maSP = int.Parse(gridViewHD.GetRowCellValue(i, gridColumnMaSPCTHD).ToString());
                                    int soLuong = int.Parse(gridViewHD.GetRowCellValue(i, gridColumnSoLuongCTHD).ToString());
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            maHD = 0;
            if(comboBox1.SelectedIndex ==0)
            {
                InvoiceBUS.Instance.getALLHoaDon(gridControlHD, tinhtrang);
                btnCapNhat.Visible = false;
            }
            else
            {
                if(comboBox1.SelectedItem.ToString().Trim()== "Chờ xác nhận")
                {
                    btnCapNhat.Text = "Xác nhận đơn hàng";
                    btnCapNhat.Visible = true;
                }
                else if(comboBox1.SelectedItem.ToString().Trim() == "Đã xác nhận")
                {
                    btnCapNhat.Text = "Xác nhận giao hàng";
                    btnCapNhat.Visible = true;
                }    
                else
                {
                    btnCapNhat.Visible = false;
                }
                InvoiceBUS.Instance.getDataInvoiceByNote(gridControlHD, comboBox1.SelectedItem.ToString().Trim());
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(maHD !=0)
            {
                if (btnCapNhat.Text.Equals("Xác nhận đơn hàng"))
                {
                    if (XtraMessageBox.Show("Bạn đã xác nhận đơn này với khách hàng chưa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (InvoiceBUS.Instance.updateStatusInvoice(maHD, "Đã xác nhận", frmMainForm.maND))
                        {
                            XtraMessageBox.Show("Xác nhận đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            InvoiceBUS.Instance.getDataInvoiceByNote(gridControlHD, comboBox1.SelectedItem.ToString().Trim());
                            for (int i = 0; i < gridViewHD.RowCount; i++)
                            {
                                int maSP = int.Parse(gridViewHD.GetRowCellValue(i, gridColumnMaSPCTHD).ToString());
                                int soLuong = int.Parse(gridViewHD.GetRowCellValue(i, gridColumnSoLuongCTHD).ToString());
                                ProductBUS.Instance.updateAmount_Buy(maSP, soLuong);
                            }
                            LamMoiDuLieu();
                            maHD = 0;
                        }
                    }
                }
                if(btnCapNhat.Text.Equals("Xác nhận giao hàng"))
                {
                    if (InvoiceBUS.Instance.updateStatusInvoice(maHD, "Đang giao", (int)maNguoiDung))
                    {
                        XtraMessageBox.Show("Chuyển sang bộ phận giao hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InvoiceBUS.Instance.getDataInvoiceByNote(gridControlHD, comboBox1.SelectedItem.ToString().Trim());
                        maHD = 0;
                    }
                }    
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn đơn hàng xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
