using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class BannerDAO
    {
        private static BannerDAO instance;

        public static BannerDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new BannerDAO();
                }
                return instance;
            }
        }
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        public List<Banner> loadBanner()
        {
            var listBanner = db.Banners.ToList();
            return listBanner;
        }

        public bool insertBanner(string fileBanner, bool active)
        {
            try
            {
                Banner banner = new Banner();
                banner.fileBanner = fileBanner;
                banner.kichHoat = active;
                banner.ghiChu = "new";
                db.Banners.InsertOnSubmit(banner);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateBanner(string fileBanner, bool active, int bannerID)
        {
            try
            {
                Banner banner = db.Banners.SingleOrDefault(m => m.maBanner == bannerID);
                banner.fileBanner = fileBanner;
                banner.kichHoat = active;
                banner.ghiChu = "new";
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteBanner(int BannerID)
        {
            try
            {
                Banner banner = db.Banners.SingleOrDefault(m => m.maBanner == BannerID);
                db.Banners.DeleteOnSubmit(banner);
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
