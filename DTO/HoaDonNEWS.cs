using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNews
    {
        private int _maHoaDon;

        private string _diaChi;

        private string _tenNguoiDung;

        private string _soDienThoai;

        private string _tenKhachHang;

        private System.Nullable<double> _giamGia;

        private System.Nullable<System.DateTime> _ngayBan;

        private System.Nullable<System.DateTime> _ngayGiao;

        private System.Nullable<decimal> _tongTien;

        private System.Nullable<bool> _tinhTrang;

        public int MaHoaDon { get => _maHoaDon; set => _maHoaDon = value; }
        public string TenNguoiDung { get => _tenNguoiDung; set => _tenNguoiDung = value; }
        public DateTime? NgayBan { get => _ngayBan; set => _ngayBan = value; }
        public DateTime? NgayGiao { get => _ngayGiao; set => _ngayGiao = value; }
        public decimal? TongTien { get => _tongTien; set => _tongTien = value; }
        public bool? TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public double? GiamGia { get => _giamGia; set => _giamGia = value; }
        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
    }
}
