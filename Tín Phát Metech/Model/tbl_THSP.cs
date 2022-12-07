using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    public class tbl_THSP
    {
        TinPhatEntities db = new TinPhatEntities();
        public THSP getItem(decimal ID)
        {
            return db.THSP.FirstOrDefault(x => x.Ma_THSP == ID);
        }
        public List<THSP> getList()
        {
            return db.THSP.ToList();
        }
        public THSP add(THSP to)
        {
            try
            {
                db.THSP.Add(to);
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public THSP update(THSP to)
        {
            try
            {
                var _To = db.THSP.FirstOrDefault(x => x.Ma_THSP == to.Ma_THSP);
                _To.Date_THSP = to.Date_THSP;
                _To.DVT = to.DVT;
                _To.Gia = to.Gia;
                _To.Ma_Kho = to.Ma_Kho;
                _To.Ma_NV = to.Ma_NV;
                _To.Note = to.Note;
                _To.SL = to.SL;
                _To.TenSP = to.TenSP;
                _To.Tien = to.Tien;
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public THSP delete(decimal id)
        {
            try
            {
                var _To = db.THSP.FirstOrDefault(x => x.Ma_THSP == id);
                db.THSP.Remove(_To);
                db.SaveChanges();
                return _To;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
    }
}
