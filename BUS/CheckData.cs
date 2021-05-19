using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{
    public class CheckData
    {
        // private static 
        
        private static CheckData instance;
        public static CheckData Instances
        {
            get
            {
                if (instance == null)
                {
                    instance = new CheckData();
                }
                return instance;
            }
        }



        ///Kiểm tra số điện thoại
        ///

        public bool KtraSoDienThoai(string input)
        {
            if (input[0] == '0' && input.Trim().Length == 10 && KtraDuLieu(input))
                return true;
            return false;
        }
        bool KtraDuLieu(string input)
        {
            foreach(char c in input)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }



        //Ktra email
        public bool KtraEmail( String input)
        {
            input = input ?? string.Empty;
            string strRegex= @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if(re.IsMatch(input))
                return true;
            return false;
        }


    }
}
