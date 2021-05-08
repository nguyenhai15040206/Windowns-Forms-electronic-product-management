using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public class NhaSanXuatBUS
    {
        private static NhaSanXuatBUS instance;
        public static NhaSanXuatBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhaSanXuatBUS();
                }
                return instance;
            }

        }


        public void loadNhaSanXuatCbo(ComboBox cbo)
        {
            cbo.DataSource = NhaSanXuatDAO.Instance.loadTatCaNSX();
            cbo.DisplayMember = "tenNhaSanXuat";
            cbo.ValueMember = "maNhaSanXuat";
        }
    }
}
