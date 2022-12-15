using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_Dongia
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_Dongia instance;

        public static tbl_Dongia Instance
        {
            get { if (instance == null) instance = new tbl_Dongia(); return tbl_Dongia.instance; }
            private set { tbl_Dongia.instance = value; }
        }

        private tbl_Dongia() { }
        public Dongia getItem(string ID)
        {
            return db.Dongia.FirstOrDefault(x => x.MaDG == ID);
        }
        public List<Dongia> getList()
        {
            return db.Dongia.ToList();
        }
        public Dongia add(Dongia to)
        {
            try
            {
                db.Dongia.Add(to);
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Dongia update(Dongia to)
        {
            try
            {
                var _To = db.Dongia.FirstOrDefault(x => x.MaDG == to.MaDG);
                _To.Gia = to.Gia;
                _To.MaDV = to.MaDV;
                _To.MaSP = to.MaSP;
                _To.Note = to.Note;
                _To.TenSP = to.TenSP;
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public Dongia delete(string id)
        {
            try
            {
                var _To = db.Dongia.FirstOrDefault(x => x.MaDG == id);
                db.Dongia.Remove(_To);
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
