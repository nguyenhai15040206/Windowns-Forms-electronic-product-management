using BUS;
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
    public partial class frmInfomationLaptopDetails : Form
    {
        public delegate void sendData(string value);
        private string receiveData = "";
        public string transmissionData = "";
        public sendData infomationDetails;
        public frmInfomationLaptopDetails()
        {
            InitializeComponent();
            infomationDetails = new sendData(getDataInfomationDetails);
        }

        public void getDataInfomationDetails(string infomationDetails)
        {
            receiveData = infomationDetails;
            string[] deScriptionInfomationDetails = receiveData.Trim().Split('&');
            string[] deScription = deScriptionInfomationDetails[0].Trim().Split('|');
            string[] deScriptionDetails = deScriptionInfomationDetails[1].Trim().Split('|');
            txtScreen.Text = deScription[0].Trim().ToString();
            txtCPU.Text = deScription[1].Trim().ToString();
            string ram = "";
            ram = deScription[2].Trim().Substring(0, deScription[2].Trim().LastIndexOf("GB"));
            numRAM.Value = int.Parse(ram.Trim());
            string[] temp = deScription[2].Trim().Split(',');
            for(int i=1; i < temp.Length; i++)
            {
                txtInfomationRam.Text += temp[i].Trim() +", ";
            }
            txtInfomationRam.Text= txtInfomationRam.Text.Substring(0, txtInfomationRam.Text.Trim().Length-1);
            txtHardDriver.Text = deScription[3].Trim().ToString();
            txtGraphicsCard.Text = deScription[4].Trim().ToString();
            txtOperatingSystem.Text = deScriptionDetails[0].Trim().ToString();
            txtWeight.Text = deScriptionDetails[1].Trim().ToString();
            txtSize.Text = deScriptionDetails[2].Trim().ToString();
        }



        private void btnHoatTat_Click(object sender, EventArgs e)
        {
            if (txtGraphicsCard.Text.Trim().Length > 0 && txtCPU.Text.Trim().Length > 0 && txtOperatingSystem.Text.Trim().Length > 0
                && txtSize.Text.Trim().Length > 0 && txtScreen.Text.Trim().Length > 0 && txtWeight.Text.Trim().Length > 0 &&
                txtHardDriver.Text.Trim().Length > 0 && txtInfomationRam.Text.Trim().Length > 0 && numRAM.Value > 0)
            {
                if (CheckDataInput.Instances.isDouble(txtWeight.Text.Trim()))
                {
                    transmissionData = txtScreen.Text.Trim() + " | " + txtCPU.Text.Trim() + " | " + numRAM.Value.ToString() + " GB" + ", " + txtInfomationRam.Text.Trim()
                                    + " | " + txtHardDriver.Text.Trim() + " | " + txtGraphicsCard.Text.Trim() + " & " + txtOperatingSystem.Text.Trim() + " | " + txtWeight.Text.Trim() + " | "
                                    + txtSize.Text.Trim();
                    frmInsertProduct.infomationDetailsProduct = transmissionData;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Trọng lượng không đúng địng dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWeight.Focus();
                }   
                
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }    
        }
    }
}
