using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_Kyhieucong
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_Kyhieucong instance;

        public static tbl_Kyhieucong Instance
        {
            get { if (instance == null) instance = new tbl_Kyhieucong(); return tbl_Kyhieucong.instance; }
            private set { tbl_Kyhieucong.instance = value; }
        }

        private tbl_Kyhieucong() { }
        public Kyhieucong getItem(string ID)
        {
            return db.Kyhieucong.FirstOrDefault(x => x.MaKyhieu == ID);
        }
        public List<Kyhieucong> getList()
        {
            return db.Kyhieucong.ToList();
        }
        public Kyhieucong add(Kyhieucong Chucvu)
        {
            try
            {
                db.Kyhieucong.Add(Chucvu);
                db.SaveChanges();
                return Chucvu;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Kyhieucong update(Kyhieucong Chucvu)
        {
            try
            {
                var _Chucvu = db.Kyhieucong.FirstOrDefault(x => x.MaKyhieu == Chucvu.MaKyhieu);
                _Chucvu.Dgiai = Chucvu.Dgiai;
                _Chucvu.Note = Chucvu.Note;
                _Chucvu.Kyhieu = Chucvu.Kyhieu;
                db.SaveChanges();
                return Chucvu;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Kyhieucong delete(string id)
        {
            try
            {
                var _Chucvu = db.Kyhieucong.FirstOrDefault(x => x.MaKyhieu == id);
                db.Kyhieucong.Remove(_Chucvu);
                db.SaveChanges();
                return _Chucvu;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
    }
}
