using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    class tbl_KH
    {
        TinPhatEntities db = new TinPhatEntities();
        public KH getItem(string ID)
        {
            return db.KH.FirstOrDefault(x => x.Ma_KH == ID);
        }
        public List<KH> getList()
        {
            return db.KH.ToList();
        }
        public KH add(KH KH)
        {
            try
            {
                db.KH.Add(KH);
                db.SaveChanges();
                return KH;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public KH update(KH KH)
        {
            try
            {
                var _KH = db.KH.FirstOrDefault(x => x.Ma_KH == KH.Ma_KH);
                _KH.Ten_KH = KH.Ten_KH;
                _KH.Diachi_KH = KH.Diachi_KH;
                _KH.Note_KH = KH.Note_KH;
                _KH.Is_NCC = KH.Is_NCC;
                db.SaveChanges();
                return KH;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public KH delete(string id)
        {
            try
            {
                var _KH = db.KH.FirstOrDefault(x => x.Ma_KH == id);
                db.KH.Remove(_KH);
                db.SaveChanges();
                return _KH;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
    }
}
