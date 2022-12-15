using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_KH
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_KH instance;

        public static tbl_KH Instance
        {
            get { if (instance == null) instance = new tbl_KH(); return tbl_KH.instance; }
            private set { tbl_KH.instance = value; }
        }

        private tbl_KH() { }
        public KH getItem(string ID)
        {
            return db.KH.FirstOrDefault(x => x.MaKH == ID);
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
                var _KH = db.KH.FirstOrDefault(x => x.MaKH == KH.MaKH);
                _KH.TenKH = KH.TenKH;
                _KH.Note = KH.Note;
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
                var _KH = db.KH.FirstOrDefault(x => x.MaKH == id);
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
