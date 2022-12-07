using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_Chucvu
    {
        TinPhatEntities db = new TinPhatEntities();
        public Chucvu getItem(string ID)
        {
            return db.Chucvu.FirstOrDefault(x => x.MaCV == ID);
        }
        public List<Chucvu> getList()
        {
            return db.Chucvu.ToList();
        }
        public Chucvu add(Chucvu Chucvu)
        {
            try
            {
                db.Chucvu.Add(Chucvu);
                db.SaveChanges();
                return Chucvu;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Chucvu update(Chucvu Chucvu)
        {
            try
            { 
                var _Chucvu = db.Chucvu.FirstOrDefault(x => x.MaCV== Chucvu.MaCV);
                _Chucvu.TenCV = Chucvu.TenCV;
                _Chucvu.Note = Chucvu.Note;
                db.SaveChanges();
                return Chucvu;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Chucvu delete(string id)
        {
            try
            {
                var _Chucvu = db.Chucvu.FirstOrDefault(x => x.MaCV == id);
                db.Chucvu.Remove(_Chucvu);
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
