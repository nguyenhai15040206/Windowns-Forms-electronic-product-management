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


namespace CodedUI_QLSanPham
{
    /// <summary>
    /// Summary description for CodedUI_CapNhatSP
    /// </summary>
    [CodedUITest]
    public class CodedUI_CapNhatSP
    {
        //int maSP = 1;
        string tenSP = "iPhone 12 Pro 64GB";
        DateTime ncc = DateTime.Now;
        string xuatSu = "Trung Quốc";
        int soLuong = 120;
        double dongia = 27990000;
        string hinhMH = "png";
        double giamGia = 0;
        string Ds = "png";
        string KM = "không";
        string manhinh = " 6.7, Super Retina XDR, AMOLED";
        string Camerasau = "12.0 MP + 12.0";
        string Cameraselife = "12.0 MP";
        int ram = 6;
        int bnt = 128;
        string CPU = "A14 Bionic";
        string GPU = "Apple GPU 4 nhân";
        string pin = "3687 mAh";
        string sim = "1 eSIM, 1 Nano SIM";
        string hdt = "iOS 14";
        public CodedUI_CapNhatSP()
        {
            
        }

        [TestMethod]
        public void ThatBai_ThieuTen()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = "";
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;
            this.UIMap.RecordedMethod12();

            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }


        [TestMethod]
        public void ThatBai_ThieuXuatSu()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = "";
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


        }


        [TestMethod]
        public void ThatBai_ThieuSoLuong()
        {
            //this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            //this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            //this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = 0.ToString();
            //this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            ////this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            //this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            //this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = giamGia.ToString();
            //this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            //this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            //this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            //this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            //this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            //this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            //this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            //this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            //this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            //this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            //this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            //this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            //this.UIMap.RecordedMethod12();
            this.UIMap.RecordedMethod13();


        }


        [TestMethod]
        public void ThatBai_ThieuDonGia()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = "";
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys2 = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


        }

        [TestMethod]
        public void ThatBai_SaiDinhDangDonGia()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = "ba mươi triệu đồng";
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


        }

        [TestMethod]
        public void ThatBai_ThieuHinhMinhHoa()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = "";
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


        }


        [TestMethod]
        public void ThatBai_ThieuGiamGia()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = "";
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


        }

        [TestMethod]
        public void ThatBai_SaiDinhDangGiamGia()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = "không";
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


        }

        [TestMethod]
        public void ThatBai_ThieuKhuyenMaiDiKem()
        {
            this.UIMap.RecordedMethod12Params.UIRow0ColumnmaSPEditValueAsString = 1.ToString();
            this.UIMap.RecordedMethod12Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod12Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod12Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod12Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod12Params.UITxtGiamGiaEditText = "không";
            this.UIMap.RecordedMethod12Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod12Params.UITxtKhuyenMaiDiKemEditText = "";
            this.UIMap.RecordedMethod12Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod12Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod12Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod12Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod12Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod12Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod12Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod12Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod12Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod12Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod12();


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
