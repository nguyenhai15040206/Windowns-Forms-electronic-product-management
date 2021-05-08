using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    
    public class NguoiDungDAO
    {
        public static NguoiDungDAO instance;

        public static NguoiDungDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NguoiDungDAO();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        public DataTable loadNhomNguoiDung()
        {
            DataTable table = new DataTable();
            var listNguoiDung = db.QL_NhomNguoiDungs.Select(m=>m.tenNhom).ToList();
            table.Columns.Add("tenNhom");
            foreach(string item in listNguoiDung)
            {
                DataRow row = table.NewRow();
                row["tenNhom"] = item;
                table.Rows.Add(row);
            }    
            return table;

        }

        public List<NguoiDung> loadNguoiDung()
        {
            var listNguoiDung = db.NguoiDungs.ToList();
            return listNguoiDung;
        }

        public DataTable loadDanhMucManHinh(string maNhomNguoiDung)
        {
            DataTable table = new DataTable();
            var listDM = (from mh in db.DanhMucManHinhs
                         join qlpq in db.QL_PhanQuyens on mh.maManHinh equals qlpq.maManHinh into aGroup
                         from a in aGroup.DefaultIfEmpty()
                         select new { mh,  coQuyen= a==null
                         ?false:a.coQuyen}).ToList();
            table.Columns.Add("maManHinh");
            table.Columns.Add("tenManHinh");
            table.Columns.Add("coQuyen");
            foreach (var item in listDM)
                
            {
                DataRow row = table.NewRow();
                
                row["maManHinh"] = item.mh.maManHinh;
                row["tenManHinh"] = item.mh.tenManHinh;
                row["coQuyen"] = item.coQuyen;
            }
            return table;
        }





    }
}
