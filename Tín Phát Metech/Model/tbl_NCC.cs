using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    class tbl_NCC
    {
        TinPhatEntities db = new TinPhatEntities();
        public NCC getItem(string ID)
        {
            return db.NCC.FirstOrDefault(x => x.Ma_NCC == ID);
        }
        public List<NCC> getList()
        {
            return db.NCC.ToList();
        }
        public NCC add(NCC NCC)
        {
            try
            {
                db.NCC.Add(NCC);
                db.SaveChanges();
                return NCC;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public NCC update(NCC NCC)
        {
            try
            {
                var _NCC = db.NCC.FirstOrDefault(x => x.Ma_NCC == NCC.Ma_NCC);
                _NCC.Ten_NCC = NCC.Ten_NCC;
                _NCC.Diachi_NCC = NCC.Diachi_NCC;
                _NCC.Note_NCC = NCC.Note_NCC;
                _NCC.Is_KH = NCC.Is_KH;
                db.SaveChanges();
                return NCC;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public NCC delete(string id)
        {
            try
            {
                var _NCC = db.NCC.FirstOrDefault(x => x.Ma_NCC == id);
                db.NCC.Remove(_NCC);
                db.SaveChanges();
                return _NCC;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
    }
}
