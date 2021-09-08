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


namespace Testfrm
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        string tenSP = "Iphone 12 promax";
        string xuatsu = "Trung Quốc";
        //int soluong = 120;
        //int giamgia = 2;
        int dongia = 25000000;
        string dsHinh = "timthumb.jfif";
        string manHinh = "6.7 inch Super Retina XDR OLED";
        string cameraSau = "6GB";
        string cameraSelfi = "6GB";
        int Ram = 6;
        int BoNhoTrong = 128;
        string CPU = "A14 Bionic";
        string GPU = "Apple GPU 4 nhân";
        string dungLuongPin = "3687 mAh";
        string sim = "2, 1 eSIM, 1 Nano SIM";
        string hdh = "iOS 14";
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void ThanhCong()
        {
            this.UIMap.RecordedMethod2Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod2Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod2Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = Ram.ToString();
            this.UIMap.RecordedMethod2Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod2Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtOparatingSystemEditText = hdh;
             //this.UIMap.RecordedMethod2();
             this.UIMap.RecordedMethod2();

            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuTen()
        {
            this.UIMap.RecordedMethod2Params.UITxtProductNameEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod2Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod2Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = Ram.ToString();
            this.UIMap.RecordedMethod2Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod2Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtOparatingSystemEditText = hdh;
            //this.UIMap.RecordedMethod2();
            this.UIMap.RecordedMethod2();

            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuXuatSu()
        {
            this.UIMap.RecordedMethod2Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtMadeInEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod2Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = Ram.ToString();
            this.UIMap.RecordedMethod2Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod2Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtOparatingSystemEditText = hdh;
            //this.UIMap.RecordedMethod2();
            this.UIMap.RecordedMethod2();

            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuDonGia()
        {
            this.UIMap.RecordedMethod2Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod2Params.UITxtUnitPriceImportEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod2Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = Ram.ToString();
            this.UIMap.RecordedMethod2Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod2Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtOparatingSystemEditText = hdh;
            //this.UIMap.RecordedMethod2();
            this.UIMap.RecordedMethod2();

            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuHinhMinhHoa()
        {
            this.UIMap.RecordedMethod5Params.UITxtProductNameEditText1 = tenSP;
            this.UIMap.RecordedMethod5Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod5Params.UITxtUnitPriceImportEditText =dongia.ToString();
            this.UIMap.RecordedMethod5Params.UITxtScreenEditText1 = manHinh;
            this.UIMap.RecordedMethod5Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod5Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod5Params.UINumericUpDownEditSendKeys = Ram.ToString();
            this.UIMap.RecordedMethod5Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod5Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod5Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod5Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod5Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod5Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod5();

            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }


        [TestMethod]
        public void ThatBai_ThieuManHinh()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ThatBai_ThieuCameraRear()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuCamereSelfi()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = "";
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ThatBai_ThieuRam()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 0.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ThatBai_ThieuBoNhoTrong()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = 0.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ThatBai_ThieuCPU()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ThatBai_ThieuGPU()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ThatBai_ThieuPin()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuSim()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = hdh;
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        public void ThatBai_ThieuHeDieuHanh()
        {
            this.UIMap.RecordedMethod4Params.UITxtProductNameEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtMadeInEditText = xuatsu;
            this.UIMap.RecordedMethod4Params.UITxtUnitPriceImportEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtScreenEditText = manHinh;
            this.UIMap.RecordedMethod4Params.UITxtRearCameraEditText = cameraSau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfieEditText = cameraSelfi;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = 7.ToString();
            this.UIMap.RecordedMethod4Params.UICPUEditSendKeys = BoNhoTrong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtBatteriesEditText = dungLuongPin;
            this.UIMap.RecordedMethod4Params.UITxtSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtOparatingSystemEditText = "";
            this.UIMap.RecordedMethod4();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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
