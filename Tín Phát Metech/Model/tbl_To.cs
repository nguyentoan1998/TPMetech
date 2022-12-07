using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    public class tbl_To
    {
        TinPhatEntities db = new TinPhatEntities();
        public To getItem(string ID)
        {
            return db.To.FirstOrDefault(x => x.Ma_To == ID);
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
                var _To = db.To.FirstOrDefault(x => x.Ma_To == to.Ma_To);
                _To.Ten_To = to.Ten_To;
                _To.Note_To = to.Note_To;
                _To.Theodoi_To = to.Theodoi_To;
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
                var _To = db.To.FirstOrDefault(x => x.Ma_To == id);
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
