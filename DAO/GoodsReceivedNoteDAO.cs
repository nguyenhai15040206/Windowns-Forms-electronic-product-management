﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class GoodsReceivedNoteDAO
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        private static GoodsReceivedNoteDAO instance;

        public static GoodsReceivedNoteDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new GoodsReceivedNoteDAO();
                }
                return instance;
            }
        }

        // lấy Phiếu nhập với mã phiếu mới nhất
        // lấy mã hóa đơn mới nhất
        public int RecrviedIDTop1()
        {
            int id = (int)(from pn in db.PhieuNhaps
                             orderby pn.maPhieuNhap descending
                             select pn.maPhieuNhap).Take(1).Single();
            return id;
        }

        // lất Phiếu nhập với mã 
        public PhieuNhap phieuNhap(int maPhieu)
        {
            return db.PhieuNhaps.SingleOrDefault(m => m.maPhieuNhap == maPhieu);
        }

        // load tất cả các phiếu nhập với tình trạng bằng true
        public List<NewPhieuNhap> loadTatCaPhieuNhap()
        {
            var phieuNhap = (from pn in db.PhieuNhaps
                             join ncc in db.NhaCungCaps on pn.maNhaCungCap equals ncc.maNhaCungCap
                             join nd in db.NguoiDungs on pn.maNguoiDung equals nd.maNguoiDung
                             where pn.tinhTrang == true
                             select new NewPhieuNhap
                             {
                                 MaPhieuNhap = pn.maPhieuNhap,
                                 TenNguoiDung = nd.tenNguoiDung,
                                 TenNhaCungCap = ncc.tenNhaCungCap,
                                 TongTien = pn.tienNhap,
                                 NgayLap = pn.ngayNhap,
                                 SoDienThoai = ncc.soDienThoai,
                                 TinhTrang = pn.tinhTrang
                             }).ToList();
            return phieuNhap;
        }

        // load tất cả các phiếu nhập với tình trạng bằng false
        public List<NewPhieuNhap> loadTatCaPhieuNhap_Huy()
        {
            var phieuNhap = (from pn in db.PhieuNhaps
                             join ncc in db.NhaCungCaps on pn.maNhaCungCap equals ncc.maNhaCungCap
                             join nd in db.NguoiDungs on pn.maNguoiDung equals nd.maNguoiDung
                             where pn.tinhTrang == false
                             select new NewPhieuNhap
                             {
                                 MaPhieuNhap = pn.maPhieuNhap,
                                 TenNguoiDung = nd.tenNguoiDung,
                                 TenNhaCungCap = ncc.tenNhaCungCap,
                                 TongTien = pn.tienNhap,
                                 NgayLap = pn.ngayNhap,
                                 SoDienThoai = ncc.soDienThoai,
                                 TinhTrang = pn.tinhTrang
                             }).ToList();
            return phieuNhap;
        }

        // thêm phiếu nhập
        public bool themPhieuNhap(double tongTien, int maNCC, int maNguoiDung)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.ngayNhap = DateTime.Parse(DateTime.Now.Date.ToString("dd-MM-yyy"));
                pn.tienNhap = (decimal?)tongTien;
                pn.maNhaCungCap = maNCC;
                pn.maNguoiDung = maNguoiDung;
                pn.tinhTrang = true;
                db.PhieuNhaps.InsertOnSubmit(pn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        // xóa phiếu nhập (làm cho phiếu nhập hàng đó không còn hiệu lực)
        public bool xoaPhieuNhap(int maPhieuNhap)
        {
            try
            {
                PhieuNhap pn = db.PhieuNhaps.SingleOrDefault(m => m.maPhieuNhap == maPhieuNhap);
                pn.tinhTrang = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // cập nhật phiếu nhập
        public bool capNhatPhieuNhap(int suppID)
        {
            try
            {
                var pn = db.PhieuNhaps.Where(m => m.maNhaCungCap == suppID).ToList();
                if (pn != null)
                {
                    for(int i=0; i < pn.Count(); i++)
                    {
                        pn[i].maNhaCungCap = null;
                    }    
                    db.SubmitChanges();
                } 
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
