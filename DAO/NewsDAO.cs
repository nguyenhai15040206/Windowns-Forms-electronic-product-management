using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NewsDAO
    {
        public static NewsDAO instance;

        public static NewsDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NewsDAO();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        //
        public List<TinTuc> getDataNews(bool status)
        {
            var listNews = db.TinTucs.Where(m => m.kichHoat == status).ToList();
            return listNews;
        }

        public List<TinTuc> getDataNewsByKindOfNewsID(int ID,bool status)
        {
            var listNews = db.TinTucs.Where(m => m.kichHoat == status && m.maLoaiTin==ID).ToList();
            return listNews;
        }

        //
        public List<LoaiTinTuc> getDataFindOfNews()
        {
            var list = db.LoaiTinTucs.ToList();
            return list;
        }

        public bool insertNews(string name, string description, string img,bool active, string note, int KindOfNewID)
        {
            try
            {
                TinTuc tinTuc = new TinTuc();
                tinTuc.tenTinTuc = name;
                tinTuc.noiDung = description;
                tinTuc.ngayDang = DateTime.Parse(DateTime.Now.Date.ToString("dd-MM-yyy"));
                tinTuc.anhMinhHoa = img;
                tinTuc.kichHoat = active;
                tinTuc.ghiChu = note;
                tinTuc.maLoaiTin = KindOfNewID;
                db.TinTucs.InsertOnSubmit(tinTuc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateNews(string name, string description, string img, bool active, string note, int KindOfNewID, int id)
        {
            try
            {
                var tinTuc = db.TinTucs.SingleOrDefault(m => m.maTinTuc == id);
                tinTuc.tenTinTuc = name;
                tinTuc.noiDung = description;
                tinTuc.ngayDang = DateTime.Parse(DateTime.Now.Date.ToString("dd-MM-yyy"));
                tinTuc.anhMinhHoa = img;
                tinTuc.kichHoat = active;
                tinTuc.ghiChu = note;
                tinTuc.maLoaiTin = KindOfNewID;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool removeNews(int ID)
        {
            try
            {
                var tin = db.TinTucs.SingleOrDefault(m => m.maTinTuc == ID);
                db.TinTucs.DeleteOnSubmit(tin);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
