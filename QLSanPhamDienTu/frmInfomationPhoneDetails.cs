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

namespace QLSanPhamDienTu
{
    public partial class frmInfomationPhoneDetails : Form
    {
        public delegate void sendData(string value);
        private string receiveData="";
        public string transmissionData = "";
        public sendData infomationDetails;
        public frmInfomationPhoneDetails()
        {
            InitializeComponent();
            infomationDetails = new sendData(getDataInfomationDetails);
        }

        private void frmChiTietSPDienThoai_Load(object sender, EventArgs e)
        {
               
        }
        public void getDataInfomationDetails(string thongTinCT)
        {
            receiveData = thongTinCT;
            string []deScriptionInformationDetails = receiveData.Split('&');
            string[] deScription = deScriptionInformationDetails[0].Split('|');
            string[] deScriptionDetails = deScriptionInformationDetails[1].Split('|');
            txtScreen.Text = deScription[0].ToString().Trim();
            txtRearCamera.Text = deScription[1].ToString().Trim();
            txtCameraSelfie.Text = deScription[2].ToString().Trim();
            txtCPU.Text = deScription[3].ToString().Trim();
            string a = "";
            a = deScription[4].ToString().Trim().Substring(0, deScription[4].ToString().Trim().LastIndexOf("GB"));
            numRAM.Value = int.Parse(a);
            string b = "";
            b= deScription[5].ToString().Trim().Substring(0, deScription[5].ToString().Trim().LastIndexOf("GB"));
            numInternalMemory.Value = int.Parse(b);
            txtGPU.Text = deScriptionDetails[0].ToString().Trim();
            txtBatteries.Text = deScriptionDetails[1].ToString().Trim();
            txtSim.Text = deScriptionDetails[2].ToString().Trim();
            txtOparatingSystem.Text = deScriptionDetails[3].ToString().Trim();
        }

        private void btnHoatTat_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Trim().Length > 0 && txtRearCamera.Text.Trim().Length > 0 && txtCameraSelfie.Text.Trim().Length > 0
                && txtCPU.Text.Trim().Length > 0 && txtBatteries.Text.Trim().Length > 0 && txtGPU.Text.Trim().Length > 0
                && txtOparatingSystem.Text.Trim().Length > 0 && txtSim.Text.Trim().Length > 0 && numInternalMemory.Value > 0 && numRAM.Value > 0)
            {
                transmissionData = txtScreen.Text.Trim() + " | " + txtRearCamera.Text.Trim() + " | " + txtCameraSelfie.Text.Trim() + " | " +
                txtCPU.Text.Trim() + " | " + numRAM.Value.ToString() + " GB" + " | " + numInternalMemory.Value.ToString() + " GB" + " & " +
                txtGPU.Text.Trim() + " | " + txtBatteries.Text.Trim() + " | " + txtSim.Text.Trim() + " | " +
                txtOparatingSystem.Text.Trim();
                frmInsertProduct.infomationDetailsProduct = transmissionData;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }    
                
        }
    }
}
