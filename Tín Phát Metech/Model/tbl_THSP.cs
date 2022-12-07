using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    public class tbl_THSP
    {
        TinPhatEntities db = new TinPhatEntities();
        public THSP getItem(string ID)
        {
            return db.THSP.FirstOrDefault(x => x.MaTHSP == ID);
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
                var _To = db.THSP.FirstOrDefault(x => x.MaTHSP == to.MaTHSP);
                _To.Date = to.Date;
                _To.MaBTP= to.MaBTP;
                _To.MaDG = to.MaDG;
                _To.MaDV = to.MaDV;
                _To.MaKho = to.MaKho;
                _To.MaNV = to.MaNV;
                _To.MaTP = to.MaTP;
                _To.MaVL = to.MaVL;
                _To.Note = to.Note;
                _To.SL = to.SL;
                _To.Tien = to.Tien;
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public THSP delete(string id)
        {
            try
            {
                var _To = db.THSP.FirstOrDefault(x => x.MaTHSP == id);
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
