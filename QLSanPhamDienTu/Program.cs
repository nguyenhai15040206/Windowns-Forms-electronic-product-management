using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLSanPhamDienTu
{
    static class Program
    {
        public static frmLogin frm = null;
        public static frmMainForm mainForm = null;
        public static frmConfig frmConfigDatabase = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //public static frmDoiMatKhau frmDoiMatKhau = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new frmLogin();
            Application.Run(frm);
            //Application.Run(new frmNewsAndBannerManager());
        }
    }
}
