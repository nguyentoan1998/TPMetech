using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    public class tbl_DongiaSP
    {
        TinPhatEntities db = new TinPhatEntities();
        public DongiaSP getItem(string ID)
        {
            return db.DongiaSP.FirstOrDefault(x => x.Ma_DG == ID);
        }
        public List<DongiaSP> getList()
        {
            return db.DongiaSP.ToList();
        }
        public DongiaSP add(DongiaSP to)
        {
            try
            {
                db.DongiaSP.Add(to);
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public DongiaSP update(DongiaSP to)
        {
            try
            {
                var _To = db.DongiaSP.FirstOrDefault(x => x.Ma_DG == to.Ma_DG);
                _To.Ma_SP = to.Ma_SP;
                _To.Ten_SP = to.Ten_SP;
                _To.DVT = to.DVT;
                _To.SL = to.SL;
                _To.Gia = to.Gia;
                _To.Note = to.Note;
                db.SaveChanges();
                return to;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public DongiaSP delete(string id)
        {
            try
            {
                var _To = db.DongiaSP.FirstOrDefault(x => x.Ma_DG == id);
                db.DongiaSP.Remove(_To);
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
