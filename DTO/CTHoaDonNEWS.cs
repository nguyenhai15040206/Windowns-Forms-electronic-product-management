using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHoaDonNEWS
    {
        private int masanPham;
        private System.Nullable<decimal> _donGia;

        private System.Nullable<double> _giamGia;

        private System.Nullable<decimal> _thanhTien;

        private string _tenSanPham;

        private System.Nullable<int> _soLuong;
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
        public int? SoLuong { get => _soLuong; set => _soLuong = value; }
        public decimal? DonGia { get => _donGia; set => _donGia = value; }
        public double? GiamGia { get => _giamGia; set => _giamGia = value; }
        public decimal? ThanhTien { get => _thanhTien; set => _thanhTien = value; }
        public int STT { get; set; }
        public int MasanPham { get => masanPham; set => masanPham = value; }
    }
}
