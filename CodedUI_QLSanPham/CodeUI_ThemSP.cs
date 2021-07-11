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
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodeUI_ThemSP
    {
        string tenSP = "iPhone 12 Pro 128GB";
        DateTime ncc = DateTime.Now;
        string xuatSu = "Trung Quốc";
        int soLuong = 120;
        double dongia = 29990000;
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
        public CodeUI_ThemSP()
        {
            
        }

        [TestMethod]
        public void ThatBai_ThieuTenSP()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();

        }

        [TestMethod]
        public void ThatBai_ThieuXuatSu()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = "";
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }


        [TestMethod]
        public void ThatBai_ThieuSoLuong()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = 0.ToString();
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }


        [TestMethod]
        public void ThatBai_ThieuDonGia()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }

        [TestMethod]
        public void ThatBai_SaiDinhDangDonGia()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = "ba mươi triệu đồng";
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }

        [TestMethod]
        public void ThatBai_ThieuHinhMinhHoa()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }


        [TestMethod]
        public void ThatBai_ThieuGiamGia()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }

        [TestMethod]
        public void ThatBai_SaiDinhDangGiamGia()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = "không";
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }

        [TestMethod]
        public void ThatBai_ThieuKhuyenMaiDiKem()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = "không";
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = "";
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod2();


        }

        [TestMethod]
        public void ThatBai_ThieuManHinh()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }

        [TestMethod]
        public void ThatBai_ThieuCameraSau()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }
        [TestMethod]
        public void ThatBai_ThieuCamareSelfi()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = "";
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }


        [TestMethod]
        public void ThatBai_ThieuRam()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = 0.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }

        [TestMethod]
        public void ThatBai_ThieuGB()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = 0.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }


        [TestMethod]
        public void ThatBai_ThieuCPUh()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }


        [TestMethod]
        public void ThatBai_ThieuGPU()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }

        [TestMethod]
        public void ThatBai_ThieuDungLuongPin()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }


        [TestMethod]
        public void ThatBai_ThieuTheSim()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = "";
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = hdt;


            this.UIMap.RecordedMethod4();


        }


        [TestMethod]
        public void ThatBai_ThieuHeDieuHanh()
        {
            this.UIMap.RecordedMethod4Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod4Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod4Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod4Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod4Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod4Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod4Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod4Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod4Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod4Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod4Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod4Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod4Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod4Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod4Params.UITxtHeDieuHanhEditText = "";


            this.UIMap.RecordedMethod4();


        }



        [TestMethod]
        public void ThemSanPhamThanhCong()
        {
            this.UIMap.RecordedMethod2Params.UITxtTenSPEditText = tenSP;
            this.UIMap.RecordedMethod2Params.UITxtXuatSuEditText = xuatSu;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys = soLuong.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDonGiaEditText = dongia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtHinhMHEditText = hinhMH;
            this.UIMap.RecordedMethod2Params.UITxtGiamGiaEditText = giamGia.ToString();
            this.UIMap.RecordedMethod2Params.UITxtDSHinhEditText = Ds;
            this.UIMap.RecordedMethod2Params.UITxtKhuyenMaiDiKemEditText = KM;
            this.UIMap.RecordedMethod2Params.UITxtManHinhEditText = manhinh;
            this.UIMap.RecordedMethod2Params.UITxtCameraSauEditText = Camerasau;
            this.UIMap.RecordedMethod2Params.UITxtCameraSelfiEditText = Cameraselife;
            this.UIMap.RecordedMethod2Params.UINumericUpDownEditSendKeys1 = ram.ToString();
            this.UIMap.RecordedMethod2Params.UIGBEditSendKeys = bnt.ToString();
            this.UIMap.RecordedMethod2Params.UITxtCPUEditText = CPU;
            this.UIMap.RecordedMethod2Params.UITxtGPUEditText = GPU;
            this.UIMap.RecordedMethod2Params.UITxtDungLuongPinEditText = pin;
            this.UIMap.RecordedMethod2Params.UITxtTheSimEditText = sim;
            this.UIMap.RecordedMethod2Params.UITxtHeDieuHanhEditText = hdt;


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
