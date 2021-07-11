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
    public partial class frmChiTietSPLaptop : Form
    {
        public delegate void sendData(string value);
        private string nhanDuLieu = "";
        public string truyenDuLieu = "";
        public sendData thongtinChiTiet;
        public frmChiTietSPLaptop()
        {
            InitializeComponent();
            thongtinChiTiet = new sendData(getTTCT);
        }

        public void getTTCT(string thongTinCT)
        {
            nhanDuLieu = thongTinCT;
            string[] moTaTongTin = nhanDuLieu.Trim().Split('&');
            string[] moTa = moTaTongTin[0].Trim().Split('|');
            string[] moTaChiTiet = moTaTongTin[1].Trim().Split('|');
            txtManHinh.Text = moTa[0].Trim().ToString();
            txtCPU.Text = moTa[1].Trim().ToString();
            string ram = "";
            ram = moTa[2].Trim().Substring(0, moTa[2].Trim().LastIndexOf("GB"));
            numRAM.Value = int.Parse(ram.Trim());
            string[] temp = moTa[2].Trim().Split(',');
            for(int i=1; i < temp.Length; i++)
            {
                txtTTRam.Text += temp[i].Trim() +", ";
            }
            txtTTRam.Text= txtTTRam.Text.Substring(0, txtTTRam.Text.Trim().Length-1);
            txtTTOCung.Text = moTa[3].Trim().ToString();
            txtCardDoHoa.Text = moTa[4].Trim().ToString();
            txtHeDieuHanh.Text = moTaChiTiet[0].Trim().ToString();
            txtTrongLuong.Text = moTaChiTiet[1].Trim().ToString();
            txtKichThuoc.Text = moTaChiTiet[2].Trim().ToString();
        }

        private void frmChiTietSPLaptop_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHoatTat_Click(object sender, EventArgs e)
        {
            if(txtCardDoHoa.Text.Trim().Length>0&& txtCPU.Text.Trim().Length>0&& txtHeDieuHanh.Text.Trim().Length>0
                &&txtKichThuoc.Text.Trim().Length>0&&txtManHinh.Text.Trim().Length>0&&txtTrongLuong.Text.Trim().Length>0&&
                txtTTOCung.Text.Trim().Length>0&&txtTTRam.Text.Trim().Length>0&&numRAM.Value>0)
            {
                truyenDuLieu = txtManHinh.Text.Trim() + " | " + txtCPU.Text.Trim() + " | " + numRAM.Value.ToString() + " GB" + ", " + txtTTRam.Text.Trim()
                + " | " + txtTTOCung.Text.Trim() + " | " + txtCardDoHoa.Text.Trim() + " & " + txtHeDieuHanh.Text.Trim() + " | " + txtTrongLuong.Text.Trim() + " | "
                + txtKichThuoc.Text.Trim();
                frmThemSanPham.thongTinChiTietSP = truyenDuLieu;
                this.Close();
            }    
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }    
        }
    }
}
