using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_THSPTN
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_THSPTN instance;

        public static tbl_THSPTN Instance
        {
            get { if (instance == null) instance = new tbl_THSPTN(); return tbl_THSPTN.instance; }
            private set { tbl_THSPTN.instance = value; }
        }

        private tbl_THSPTN() { }
        public THSPTN getItem(string ID)
        {
            return db.THSPTN.FirstOrDefault(x => x.MaTHSPTN  == ID);
        }
        public THSPTN getItemTo(string ID)
        {
            return db.THSPTN.FirstOrDefault(x => x.MaTo == ID);
        }
        public List<THSPTN> getList()
        {
            return db.THSPTN.ToList();
        }
        public THSPTN add(THSPTN to)
        {
            try
            {
                db.THSPTN.Add(to);
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public THSPTN update(THSPTN to)
        {
            try
            {
                var _To = db.THSPTN.FirstOrDefault(x => x.MaTHSPTN == to.MaTHSPTN);
                _To.Date = to.Date;
                _To.MaBTP = to.MaBTP;
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
        public THSPTN delete(string id)
        {
            try
            {
                var _To = db.THSPTN.FirstOrDefault(x => x.MaTHSPTN == id);
                db.THSPTN.Remove(_To);
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
