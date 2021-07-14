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
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            
        }

        private void cboServername_DropDown(object sender, EventArgs e)
        {
            UserBUS.Instance.getServerName(cboServername);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(cboServername.Text.Trim() !="" && cboDatabase.Text.Trim()!="" && txtPass.Text.Trim()!=""
                && txtUsername.Text.Trim() !="")
            {
                UserBUS.Instance.saveConfig(cboServername.Text, txtUsername.Text, txtPass.Text, cboDatabase.Text);
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Hide();
            }   
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }    
        }

        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            UserBUS.Instance.getDatabaseName(cboServername.Text, txtUsername.Text.Trim(), txtPass.Text.Trim(),cboDatabase);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
