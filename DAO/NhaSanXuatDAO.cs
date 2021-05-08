using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhaSanXuatDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static NhaSanXuatDAO instance;

        public static NhaSanXuatDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhaSanXuatDAO();
                }
                return instance;
            }

        }

        // load tất cả nhà sản xuất
        public List<NhaSanXuat> loadTatCaNSX()
        {
            var listNSX = db.NhaSanXuats.ToList();
            return listNSX;
        }
    }
}
