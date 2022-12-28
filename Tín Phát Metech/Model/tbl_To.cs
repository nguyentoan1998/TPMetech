using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    public class tbl_To
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_To instance;

        public static tbl_To Instance
        {
            get { if (instance == null) instance = new tbl_To(); return tbl_To.instance; }
            private set { tbl_To.instance = value; }
        }

        private tbl_To() { }
        public To getItem(string ID)
        {
            return db.To.FirstOrDefault(x => x.MaTo == ID);
        }
        public To getItemTo(string ID)
        {
            return db.To.FirstOrDefault(x => x.TenTo == ID);
        }
        public List<To> getList()
        {
            return db.To.ToList();
        }
        public To add(To to)
        {
            try
            {
                db.To.Add(to);
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public To update(To to)
        {
            try
            {
                var _To = db.To.FirstOrDefault(x => x.MaTo == to.MaTo);
                _To.TenTo = to.TenTo;
                _To.Note = to.Note;
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public To delete(string id)
        {
            try
            {
                var _To = db.To.FirstOrDefault(x => x.MaTo == id);
                db.To.Remove(_To);
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
