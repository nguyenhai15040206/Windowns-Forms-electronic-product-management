using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SupplierDAO
    {
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SupplierDAO();
                }
                return instance;
            }
        }

        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        // load tất cả nhà cung cấp
        public List<NhaCungCap> getAllDataSupplier()
        {
            var nhaCC = db.NhaCungCaps.ToList();
            if (nhaCC.Count == 0)
            {
                return null;
            }
            return nhaCC;
        }

        public NhaCungCap supplierByPhoneNumber(string phoneNumber)
        {
            return db.NhaCungCaps.SingleOrDefault(m => m.soDienThoai == phoneNumber);
        }

        public bool insertSupplier(string name, string address, string phonenumber, string email)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.tenNhaCungCap = name;
                ncc.diaChi = address;
                ncc.soDienThoai = phonenumber;
                ncc.email = email;
                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteSupplierID(int id)
        {
            try
            {
                var supp = db.NhaCungCaps.SingleOrDefault(m => m.maNhaCungCap == id);
                db.NhaCungCaps.DeleteOnSubmit(supp);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool updateSupplier(int id,string name, string address, string phonenumber, string email)
        {
            try
            {
                var ncc = db.NhaCungCaps.SingleOrDefault(m => m.maNhaCungCap== id);
                var nccByPhone = supplierByPhoneNumber(phonenumber);
                if(nccByPhone == null)
                {
                    ncc.tenNhaCungCap = name;
                    ncc.diaChi = address;
                    ncc.soDienThoai = phonenumber;
                    ncc.email = email;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    if(ncc.maNhaCungCap == nccByPhone.maNhaCungCap)
                    {
                        ncc.tenNhaCungCap = name;
                        ncc.diaChi = address;
                        ncc.email = email;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
