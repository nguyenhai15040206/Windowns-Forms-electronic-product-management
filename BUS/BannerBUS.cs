using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class BannerBUS
    {
        private static BannerBUS instance;

        public static BannerBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new BannerBUS();
                }
                return instance;
            }
        }

        public void loadBannerToGirdView(GridControl gv)
        {
            gv.DataSource = BannerDAO.Instance.loadBanner();
        }

        public bool insertBanner(string fileBanner, bool active)
        {
            return BannerDAO.Instance.insertBanner(fileBanner, active);
        }
        public bool updateBanner(string fileBanner, bool active, int bannerID)
        {
            return BannerDAO.Instance.updateBanner(fileBanner, active, bannerID);
        }

        public bool deleteBanner(int bannerID)
        {
            return BannerDAO.Instance.deleteBanner(bannerID);
        }
    }
}
