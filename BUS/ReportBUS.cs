using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ReportBUS
    {
        private static ReportBUS instance;

        public static ReportBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ReportBUS();
                }
                return instance;
            }
        }

        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public DataTable printInvoice(int invoiceID)
        {
            DataTable table = new DataTable();
            var query = (from hd in db.HoaDons
                         join cthd in db.CTHoaDons on hd.maHoaDon equals cthd.maHoaDon
                         join tu in db.SanPhams on cthd.maSanPham equals tu.maSanPham
                         join kh in db.KhachHangs on hd.maKhachHang equals kh.maKhachHang
                         where hd.maHoaDon == invoiceID
                         select new
                         {
                             hd.maHoaDon,
                             hd.ngayBan,
                             hd.tienBan,
                             hd.giamGia,
                             hd.tongTien,
                             kh.tenKhachHang,
                             tu.tenSanPham,
                             cthd.soLuong,
                             cthd.donGia,
                             cthd.thanhTien
                         }).ToList();
            table = ToDataTable(query);
            return table;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {//inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


    }
}
