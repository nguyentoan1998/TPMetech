using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_NV
    {
        TinPhatEntities db = new TinPhatEntities();
        public Nhanvien getItem(string ID)
        {
            return db.Nhanvien.FirstOrDefault(x => x.MaNV == ID);
        }
        public List<Nhanvien> getList()
        {
            return db.Nhanvien.ToList();
        }
        public Nhanvien add(Nhanvien NV)
        {
            try
            {
                db.Nhanvien.Add(NV);
                db.SaveChanges();
                return NV;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Nhanvien update(Nhanvien NV)
        {
            try
            {
                var _NV = db.Nhanvien.FirstOrDefault(x => x.MaNV == NV.MaNV);
                _NV.Address = NV.Address;
                _NV.ByDate = NV.ByDate;
                _NV.CCCD = NV.CCCD;
                _NV.HaNV = NV.HaNV;
                _NV.MaCV = NV.MaCV;
                _NV.SDT = NV.SDT;
                _NV.Sex = NV.Sex;
                _NV.TenNV = NV.TenNV;
                db.SaveChanges();
                return NV;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Nhanvien delete(string id)
        {
            try
            {
                var _nv = db.Nhanvien.FirstOrDefault(x => x.MaNV == id);
                db.Nhanvien.Remove(_nv);
                db.SaveChanges();
                return _nv;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
    }
}
