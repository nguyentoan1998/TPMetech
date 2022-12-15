using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_NCC
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_NCC instance;

        public static tbl_NCC Instance
        {
            get { if (instance == null) instance = new tbl_NCC(); return tbl_NCC.instance; }
            private set { tbl_NCC.instance = value; }
        }

        private tbl_NCC() { }
        public NCC getItem(string ID)
        {
            return db.NCC.FirstOrDefault(x => x.MaNCC == ID);
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
                var _NCC = db.NCC.FirstOrDefault(x => x.MaNCC == NCC.MaNCC);
                _NCC.TenNCC = NCC.TenNCC;
                _NCC.Note = NCC.Note;
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
                var _NCC = db.NCC.FirstOrDefault(x => x.MaNCC == id);
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
