using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class SupplierBUS
    {
        private static SupplierBUS instance;

        public static SupplierBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SupplierBUS();
                }
                return instance;
            }
        }

        // load tất cả nahf cung cấp lên LookUpEdit
        public void loadNCC_LookUpEdit(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.DataSource = SupplierDAO.Instance.loadTatCaNhaCungCap();
            lookUpEdit.Properties.ValueMember = "maNhaCungCap";
            lookUpEdit.CustomDisplayText += LookUpEdit_CustomDisplayText;
        }

        public int maNCC_soDT(string sdt)
        {
            return SupplierDAO.Instance.nhaCungCap_SDT(sdt).maNhaCungCap;
        }

        private void LookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            NhaCungCap ncc = lookUpEdit.Properties.GetDataSourceRowByKeyValue(e.Value) as NhaCungCap;
            if (ncc != null)
            {
                e.DisplayText = ncc.tenNhaCungCap + " - " + ncc.soDienThoai;

            }
        }

        //public void loadTatCaPhieuNhap(GridControl dgv)
        //{
        //    dgv.DataSource = PhieuNhapDAO.Instance.loadTatCaPhieuNhap();
        //}
    }
}
