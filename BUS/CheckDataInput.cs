using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{
    public class CheckDataInput
    {
        // private static 
        
        private static CheckDataInput instance;
        public static CheckDataInput Instances
        {
            get
            {
                if (instance == null)
                {
                    instance = new CheckDataInput();
                }
                return instance;
            }
        }



        ///Kiểm tra số điện thoại
        ///

        public bool isPhoneNumber(string input)
        {
            if (input[0] == '0' && input.Trim().Length == 10 && regex(input))
                return true;
            return false;
        }

        public bool regex(string input)
        {
            foreach(char c in input)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        public bool isInteger(string input)
        {
            try
            {
                int.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool isDouble(string input)
        {
            try
            {
                double.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }



        //Ktra email
        public bool isEmail( String input)
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
