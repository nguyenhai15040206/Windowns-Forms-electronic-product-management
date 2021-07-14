using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SupplierDAO
    {
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SupplierDAO();
                }
                return instance;
            }
        }

        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        // load tất cả nhà cung cấp
        public List<NhaCungCap> loadTatCaNhaCungCap()
        {
            var nhaCC = db.NhaCungCaps.ToList();
            if (nhaCC.Count == 0)
            {
                return null;
            }
            return nhaCC;
        }

        public NhaCungCap nhaCungCap_SDT(string sdt)
        {
            return db.NhaCungCaps.SingleOrDefault(m => m.soDienThoai == sdt);
        }

    }
}
