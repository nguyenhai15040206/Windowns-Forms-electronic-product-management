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
    public partial class frmThemSanPham : Form
    {
        public static string thongTinChiTietSP = string.Empty;
        public delegate void sendData(string value);
        public sendData maSanPham;
        public frmThemSanPham()
        {
            InitializeComponent();
            maSanPham = new sendData(getMaSanPham);

        }

        public void getMaSanPham(string maSanPham)
        {
            txtMaSP.Text = maSanPham;
        }

        private void frmThemSanPham_Load(object sender, EventArgs e)
        {
            DanhMucBUS.Instance.loadGhiChuCbo(cboDanhMuc);
            if (txtMaSP.Text != null)
            {
                try
                {
                    cboDanhMuc.Text = SanPhamBUS.Instance.sanPhamTheoDanhMuc(int.Parse(txtMaSP.Text));
                }
                catch { }
            }
        }


        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            txtTenSP.Text = SanPhamBUS.Instance.tenSanPham(int.Parse(txtMaSP.Text)).Trim() == null ? "": SanPhamBUS.Instance.tenSanPham(int.Parse(txtMaSP.Text)).Trim();
            numericUpDownSoLuong.Value = SanPhamBUS.Instance.soLuong(int.Parse(txtMaSP.Text));
            txtXuatSu.Text = SanPhamBUS.Instance.xuatXu(int.Parse(txtMaSP.Text)).Trim() == null ? "" : SanPhamBUS.Instance.xuatXu(int.Parse(txtMaSP.Text)).Trim();
            txtHinhMH.Text = SanPhamBUS.Instance.hinhMinhHoa(int.Parse(txtMaSP.Text)).Trim() == null ? "" : SanPhamBUS.Instance.hinhMinhHoa(int.Parse(txtMaSP.Text)).Trim();
            txtKhuyenMaiDiKem.Text = SanPhamBUS.Instance.khuyeMai(int.Parse(txtMaSP.Text)).Trim() == null ? "" : SanPhamBUS.Instance.khuyeMai(int.Parse(txtMaSP.Text)).Trim();
            txtDonGia.Text = Convert.ToString(SanPhamBUS.Instance.donGia(int.Parse(txtMaSP.Text))).Trim();
            txtGiamGia.Text = Convert.ToString(SanPhamBUS.Instance.giamGia(int.Parse(txtMaSP.Text))).Trim();
            txtThongTinChiTiet.Text = Convert.ToString(SanPhamBUS.Instance.thongTinChiTiet(int.Parse(txtMaSP.Text))).Trim() == null ? "" : Convert.ToString(SanPhamBUS.Instance.thongTinChiTiet(int.Parse(txtMaSP.Text))).Trim();
            txtDSHinh.Text = SanPhamBUS.Instance.dsHinh(int.Parse(txtMaSP.Text)).Trim();
            ckbTinhTrang.Checked = (SanPhamBUS.Instance.tinhTrang(int.Parse(txtMaSP.Text)));
            pickerNgayCN.Value = (DateTime)SanPhamBUS.Instance.ngayCapNhat(int.Parse(txtMaSP.Text));
            if (SanPhamBUS.Instance.hinhMinhHoa(int.Parse(txtMaSP.Text)).Trim() != "")
            {
                try
                {
                    pictureBox1.Image = new Bitmap(@"..\\..\\Resources\SanPham\\" + SanPhamBUS.Instance.hinhMinhHoa(int.Parse(txtMaSP.Text)).Trim());
                }
                catch { }
            } 
        }

        private void txtThongTinChiTiet_Click(object sender, EventArgs e)
        {
            if (cboDanhMuc.Text.Equals("DienThoai"))
            {
                frmChiTietSPDienThoai frm = new frmChiTietSPDienThoai();
                if (txtThongTinChiTiet.Text.Trim() != null)
                {
                    try
                    {
                        frm.thongtinChiTiet(txtThongTinChiTiet.Text);
                    }
                    catch { }
                }
                frm.ShowDialog();
            }
            if(cboDanhMuc.Text.Equals("Laptop"))
            {
                frmChiTietSPLaptop frm = new frmChiTietSPLaptop();
                if (txtThongTinChiTiet.Text.Trim() != null)
                {
                    try
                    {
                        frm.thongtinChiTiet(txtThongTinChiTiet.Text);
                    }
                    catch { }
                }
                frm.ShowDialog();
            }    
            if(!string.IsNullOrEmpty(thongTinChiTietSP))
            {
                this.txtThongTinChiTiet.Text = thongTinChiTietSP;
            }    
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // kiểm tra các thông tin đầu vào
            if (txtMaSP.Text.Trim() != "")
            {
                string[] thongTinChiTiet = txtThongTinChiTiet.Text.Trim().Split('&');
                string moTa = thongTinChiTiet[0].Trim().ToString();
                string motaChiTiet = thongTinChiTiet[1].Trim().ToString();
                if (SanPhamBUS.instance.capNhatSanPham(int.Parse(txtMaSP.Text.Trim()), txtTenSP.Text.Trim(), int.Parse(numericUpDownSoLuong.Value.ToString()),
                    double.Parse(txtDonGia.Text.Trim()), moTa, motaChiTiet, txtKhuyenMaiDiKem.Text.Trim(), double.Parse(txtGiamGia.Text.Trim()), pickerNgayCN.Value,
                    txtXuatSu.Text.Trim(), txtHinhMH.Text.Trim(), txtDSHinh.Text.Trim(), true, int.Parse(cboThuongHieu.SelectedValue.ToString())))
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại các thông tin");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công! vui lòng kiểm tra lại thông tin");
            }

            
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DanhMucBUS.Instance.loadDanhMucTheoGhiChu(cboThuongHieu, cboDanhMuc.SelectedItem.ToString());
            if(txtMaSP.Text.Trim() !=null)
            {
                try
                {
                    cboThuongHieu.Text = DanhMucBUS.Instance.tenDanhMucTheoMaSP(int.Parse(txtMaSP.Text));
                }
                catch { }
            }
            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string[] thongTinChiTiet = txtThongTinChiTiet.Text.Trim().Split('&');
            string moTa = thongTinChiTiet[0].Trim().ToString();
            string motaChiTiet = thongTinChiTiet[1].Trim().ToString();
            if (SanPhamBUS.instance.themSanPham(txtTenSP.Text.Trim(), int.Parse(numericUpDownSoLuong.Value.ToString()),
                double.Parse(txtDonGia.Text.Trim()), moTa, motaChiTiet, txtKhuyenMaiDiKem.Text.Trim(), double.Parse(txtGiamGia.Text.Trim()), pickerNgayCN.Value,
                txtXuatSu.Text.Trim(), txtHinhMH.Text.Trim(), txtDSHinh.Text.Trim(), true, int.Parse(cboThuongHieu.SelectedValue.ToString())))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin");
            }
        }
    }
}
