using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_BTP
    {
        TinPhatEntities db = new TinPhatEntities();
        private static tbl_BTP instance;

        public static tbl_BTP Instance
        {
            get { if (instance == null) instance = new tbl_BTP(); return tbl_BTP.instance; }
            private set { tbl_BTP.instance = value; }
        }

        private tbl_BTP() { }
        public BTP getItem(string ID)
        {
            return db.BTP.FirstOrDefault(x => x.MaBTP == ID);
        }
        public List<BTP> getList()
        {
            return db.BTP.ToList();
        }
        public BTP add(BTP to)
        {
            try
            {
                db.BTP.Add(to);
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public BTP update(BTP to)
        {
            try
            {
                var _To = db.BTP.FirstOrDefault(x => x.MaBTP == to.MaBTP);
                _To.HaBTP = to.HaBTP;
                _To.MaDV = to.MaDV;
                _To.MaCP = to.MaCP;
                _To.MaKho = to.MaKho;
                _To.Mota = to.Mota;
                _To.TenBTP = to.TenBTP;
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public BTP delete(string id)
        {
            try
            {
                var _To = db.BTP.FirstOrDefault(x => x.MaBTP == id);
                db.BTP.Remove(_To);
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
