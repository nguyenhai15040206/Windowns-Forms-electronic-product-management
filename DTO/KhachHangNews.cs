using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangNews
    {
		private int _maKhachHang;

		private string _tenKhachHang;

		private string _soDienThoai;

		private string _email;

		private string _diaChi;

        public int MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public string Email { get => _email; set => _email = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
    }
}
