using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    class tbl_NV
    {
        TinPhatEntities db = new TinPhatEntities();
        public NV getItem(string ID)
        {
            return db.NV.FirstOrDefault(x => x.Ma_NV == ID);
        }
        public List<NV> getList()
        {
            return db.NV.ToList();
        }
        public NV add(NV NV)
        {
            try
            {
                db.NV.Add(NV);
                db.SaveChanges();
                return NV;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public NV update(NV NV)
        {
            try
            {
                var _NV = db.NV.FirstOrDefault(x => x.Ma_NV == NV.Ma_NV);
                _NV.Ten_NV = NV.Ten_NV;
                _NV.Gioitinh_NV = NV.Gioitinh_NV;
                _NV.Image_NV = NV.Image_NV;
                _NV.Ma_To = NV.Ma_To;
                _NV.Ma_User = NV.Ma_User;
                _NV.SDT_NV = NV.SDT_NV;
                _NV.CMT_NV = NV.CMT_NV;
                _NV.Diachi_NV = NV.Diachi_NV;
                db.SaveChanges();
                return NV;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public NV delete(string id)
        {
            try
            {
                var _nv = db.NV.FirstOrDefault(x => x.Ma_NV == id);
                db.NV.Remove(_nv);
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
