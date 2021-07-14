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
using DevExpress.XtraReports.UI;
using QLSanPhamDienTu.Report;

namespace QLSanPhamDienTu
{
    public partial class frmInsertProductBySupplier : Form
    {

        private int dongChon = 0;
        double tongTien = 0;
        int maPhieuNhap = 0, maThucUong = 0, soLuong = 0;
        double giaNhap = 0, thanhTien = 0;
         bool tinhTrang = true;
        int row = 0;
        public frmInsertProductBySupplier()
        {
            InitializeComponent();
        }

        private void frmInsertProductBySupplier_Load(object sender, EventArgs e)
        {
            // load nhà cung cấp
            SupplierBUS.Instance.loadNCC_LookUpEdit(lookUpEditSupplier);

            // load Thức uống
            ProductBUS.Instance.getAllProductToLooUpEdit(repositoryItemLookUpEditProducts);
            GoodsReceivedNoteBUS.Instance.loadTatCaPhieuNhap(gridContrrolPN);
            GoodsRecivedNoteDetailsBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            gridViewCTPN.OptionsBehavior.Editable = true;
            toolStripButtonInPhieu.Enabled = false;
            toolStripButtonLuuPN.Enabled = true;
            GoodsRecivedNoteDetailsBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
            lamMoiDuLieu();
        }

        private void toolStripButtonLuuPN_Click(object sender, EventArgs e)
        {
            if (lookUpEditSupplier.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (tongTien != 0)
                {
                    if (GoodsReceivedNoteBUS.Instance.themPhieuNhap(tongTien, int.Parse(lookUpEditSupplier.EditValue.ToString()), 1))
                    {
                        maPhieuNhap = GoodsReceivedNoteBUS.Instance.maPhieuNhapMoiNhat();
                        for (int i = 0; i < gridViewCTPN.RowCount - 1; i++)
                        {
                            int maThucUong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnProductID).ToString());
                            int soLuong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnSL).ToString());
                            double donGia = double.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnDonGia).ToString());
                            double thanhTien = soLuong * donGia;
                            GoodsRecivedNoteDetailsBUS.Instance.themCTPhieuNhap(maPhieuNhap, maThucUong, soLuong, donGia, thanhTien);
                            ProductBUS.Instance.updateAmouny_Delete(maThucUong, soLuong);
                        }
                        toolStripButtonLuuPN.Enabled = false;
                        if (XtraMessageBox.Show("Thêm thành công! Bạn có muốn in phiếu nhập này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            XtraReportPN rpt = new XtraReportPN();
                            XRLabel xRLabel = rpt.xrLabelTienChu;
                            decimal tongTien = GoodsReceivedNoteBUS.Instance.tongTien_MaPhieu(maPhieuNhap);
                            xRLabel.Text = CheckDataInput.Instances.formatMoneyToString((double)tongTien);
                            rpt.xrLabel10.Text = string.Format("{0:0,0} vnđ", tongTien);
                            rpt.DataSource = ReportBUS.Instance.printGoodsReceiveNote(maPhieuNhap);
                            rpt.ShowPreviewDialog();
                        }
                        lamMoiDuLieu();
                        GoodsRecivedNoteDetailsBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn sản phẩm cần nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void gridViewCTPN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            maThucUong = 0;
            if (gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnProductID) != null)
            {
                maThucUong = int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnProductID).ToString());
                soLuong = int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString());
                giaNhap = double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString());
                thanhTien = soLuong * giaNhap;
                dongChon = e.RowHandle;
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maPhieuNhap = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString().Trim());
                row = maPhieuNhap;
                GoodsRecivedNoteDetailsBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, maPhieuNhap);
                txtUserName.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNguoiNhap).ToString();
                txtSumMoney.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTongTien).ToString()));
                toolStripButtonInPhieu.Enabled = true;
                toolStripButtonLuuPN.Enabled = false;
                int maNCC = SupplierBUS.Instance.maNCC_soDT((gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn4).ToString()));
                lookUpEditSupplier.EditValue = maNCC;
                tinhTrang = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTinhTrang).ToString());
                ckbStatus.Checked = tinhTrang;
                gridViewCTPN.OptionsBehavior.Editable = false;
            }
            catch
            {
                return;
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1")
            {
                maPhieuNhap = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString().Trim());
                if (tinhTrang == true)
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn hủy có đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (GoodsReceivedNoteBUS.Instance.xoaPhieuNhap(maPhieuNhap))
                        {
                            XtraMessageBox.Show("Phiếu nhập này đã được hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int i = 0; i < gridViewCTPN.RowCount - 1; i++)
                            {
                                int maSanPham = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnProductID).ToString());
                                int soLuong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnSL).ToString());
                                ProductBUS.Instance.updateAmount_Buy(maSanPham, soLuong);
                            }
                            lamMoiDuLieu();
                            GoodsRecivedNoteDetailsBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Phiếu nhập không khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void C(object sender, DevExpress.XtraGrid.Views.Printing.PrintRowEventArgs e)
        {

        }

        private void gridViewCTPN_Click(object sender, EventArgs e)
        {
            tinhTienTong();
        }

        private void gridViewCTPN_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumnXoa")
            {
                if (maThucUong > 0)
                {
                    if (gridViewCTPN.DataRowCount != 0)
                    {
                        if (GoodsRecivedNoteDetailsBUS.Instance.CTPhieuNhap(maPhieuNhap, maThucUong) == false)
                        {
                            gridViewCTPN.DeleteRow(dongChon);
                            tinhTienTong();
                        }
                    }
                }
            }
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbStatus.Checked == true)
            {
                tinhTrang = true;
                ckbStatus.Text = "Đơn đã nhập";
                lamMoiDuLieu();
                GoodsReceivedNoteBUS.Instance.loadTatCaPhieuNhap(gridContrrolPN);

            }
            else
            {
                tinhTrang = false;
                ckbStatus.Text = "Đơn đã hủy";
                lamMoiDuLieu();
                GoodsReceivedNoteBUS.Instance.loadTatCaPhieuNhap_TinhTrangHuy(gridContrrolPN);

            }
        }

        private void toolStripButtonInPhieu_Click(object sender, EventArgs e)
        {
            XtraReportPN rpt = new XtraReportPN();
            XRLabel xRLabel = rpt.xrLabelTienChu;
            decimal tongTien = GoodsReceivedNoteBUS.Instance.tongTien_MaPhieu(row);
            xRLabel.Text = CheckDataInput.Instances.formatMoneyToString((double)tongTien);
            rpt.xrLabel10.Text = string.Format("{0:0,0} vnđ", tongTien);
            rpt.DataSource = ReportBUS.Instance.printGoodsReceiveNote(row);
            rpt.ShowPreviewDialog();
        }

        private void gridViewCTPN_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "gridColumnProductID")
            {
                var maTU = gridViewCTPN.GetRowCellValue(e.RowHandle, e.Column);
                gridViewCTPN.SetRowCellValue(e.RowHandle, "DVT", "Cái");
                gridViewCTPN.SetRowCellValue(e.RowHandle, "DonGia", ProductBUS.Instance.productUnitPriceImport((int)maTU));
                if (int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) == 0 || gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL) == null)
                {
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "SoLuong", 1);
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", 1 * (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                    tinhTienTong();
                }
                else
                {
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) *
                        (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                    tinhTienTong();
                }
            }
            if (e.Column.Name == "gridColumnSL")
            {
                gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) *
                        (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                tinhTienTong();
            }
        }

        public void tinhTienTong()
        {
            double pTienNuoc = 0;
            //int soDong = int.Parse(gridColumnProductID.SummaryItem.SummaryValue.ToString());
            for (int i = 0; i < gridViewCTPN.RowCount - 1; i++)
            {
                pTienNuoc += double.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnThanhTien).ToString());
            }
            tongTien = pTienNuoc;
            txtSumMoney.Text = string.Format("{0:0,0} vnđ", tongTien);
        }

        public void lamMoiDuLieu()
        {
            maPhieuNhap = 0;
            tongTien = 0;
            txtUserName.Text = "";
            txtSumMoney.Text = "";
            lookUpEditSupplier.EditValue = null;

            GoodsReceivedNoteBUS.Instance.loadTatCaPhieuNhap(gridContrrolPN);
        }
    }
}
