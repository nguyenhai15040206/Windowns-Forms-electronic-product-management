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
    public partial class frmChiTietSPDienThoai : Form
    {
        public delegate void sendData(string value);
        private string nhanDuLieu="";
        public string tryenDuLieu="";
        public sendData thongtinChiTiet;
        public frmChiTietSPDienThoai()
        {
            InitializeComponent();
            thongtinChiTiet = new sendData(getTTCT);
        }

        private void frmChiTietSPDienThoai_Load(object sender, EventArgs e)
        {
               
        }
        public void getTTCT(string thongTinCT)
        {
            nhanDuLieu= thongTinCT;
            string []moTaTTCT = nhanDuLieu.Split('&');
            string[] moTa = moTaTTCT[0].Split('|');
            string[] moTaChiTiet = moTaTTCT[1].Split('|');
            txtManHinh.Text = moTa[0].ToString().Trim();
            txtCameraSau.Text = moTa[1].ToString().Trim();
            txtCameraSelfi.Text = moTa[2].ToString().Trim();
            txtCPU.Text = moTa[3].ToString().Trim();
            string a = "";
            a = moTa[4].ToString().Trim().Substring(0,moTa[4].ToString().Trim().LastIndexOf("GB"));
            numRAM.Value = int.Parse(a);
            string b = "";
            b= moTa[5].ToString().Trim().Substring(0, moTa[5].ToString().Trim().LastIndexOf("GB"));
            numBoNhoTrong.Value = int.Parse(b);
            txtGPU.Text = moTaChiTiet[0].ToString().Trim();
            txtDungLuongPin.Text = moTaChiTiet[1].ToString().Trim();
            txtTheSim.Text = moTaChiTiet[2].ToString().Trim();
            txtHeDieuHanh.Text = moTaChiTiet[3].ToString().Trim();
        }

        private void btnHoatTat_Click(object sender, EventArgs e)
        {
            tryenDuLieu = txtManHinh.Text.Trim() + " | " + txtCameraSau.Text.Trim() + " | " + txtCameraSelfi.Text.Trim() + " | " +
                txtCPU.Text.Trim() + " | " + numRAM.Value.ToString()+" GB" + " | " + numBoNhoTrong.Value.ToString() + " GB" + " & " +
                txtGPU.Text.Trim() + " | " + txtDungLuongPin.Text.Trim() + " | " + txtTheSim.Text.Trim() + " | " +
                txtHeDieuHanh.Text.Trim();
            frmThemSanPham.thongTinChiTietSP = tryenDuLieu;
            this.Close();
                
        }
    }
}
