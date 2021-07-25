using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class NewsBUS
    {
        public static NewsBUS instance;

        public static NewsBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NewsBUS();
                }
                return instance;
            }
        }

        public void loadDataToGirdView(GridControl gridControl,bool status)
        {
            gridControl.DataSource = NewsDAO.Instance.getDataNews(status);
        }

        public void loadDataToComBoBox(ComboBox cbo)
        {
            cbo.DataSource = NewsDAO.Instance.getDataFindOfNews();
            cbo.ValueMember = "maLoaiTin";
            cbo.DisplayMember = "tenLoaiTin";
        }

        public void loadDataByKindOfNewsID(GridControl gridControl,int id, bool status)
        {
            gridControl.DataSource = NewsDAO.Instance.getDataNewsByKindOfNewsID(id, status);
        }

        public bool insertNews(string name, string description, string img, bool active, string note, int KindOfNewID)
        {
            return NewsDAO.Instance.insertNews(name, description, img, active, note, KindOfNewID);
        }

        public bool UpdateNews(string name, string description, string img, bool active, string note, int KindOfNewID, int id)
        {
            return NewsDAO.Instance.UpdateNews(name, description, img, active, note, KindOfNewID, id);
        }

        public bool deleteNews(int ID)
        {
            return NewsDAO.Instance.removeNews(ID);
        }
    }
}
