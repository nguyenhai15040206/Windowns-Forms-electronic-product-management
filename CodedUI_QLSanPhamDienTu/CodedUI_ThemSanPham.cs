using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUI_QLSanPhamDienTu
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUI_ThemSanPham
    {
        public CodedUI_ThemSanPham()
        {
        }

        [TestMethod]
        public void ThemSP_ThieuTenSP()
        {
            string xuatSu = "Trung Quốc";
            DateTime ncc = DateTime.Now;
            int soLuong = 100;
            double donGia = 29990000;
            string hinhMH = "png";
            double giamGia = 0;
            string DsHinh = "png";
            string KM = "không";
            string manHinh = " 6.7, Super Retina XDR, AMOLED, 2778 x 1284 Pixel";
            string cameraSau = "12.0 MP + 12.0";
            string cameraTruoc = "12.0 MP";
            int Ram = 6;
            int boNhoTrong = 128;
            string CPU = "A14 Bionic";
            string GPU = "Apple GPU 4 nhân";
            string dungLuongPin = "3687 mAh";
            string theSim = "1 eSIM, 1 Nano SIM";
            string heDieuHanh = "ios 14";


           // this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = "";
            //this.UIMap.RecordedMethod2Params.
            //this.UIMap.RecordedMethod1Params
            this.UIMap.RecordedMethod2();




        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
