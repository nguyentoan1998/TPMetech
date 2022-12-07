using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_User
    {
        TinPhatEntities db = new TinPhatEntities();
        public User getItem(string ID)
        {
            return db.User.FirstOrDefault(x => x.MaTK == ID);
        }
        public List<User> getList()
        {
            return db.User.ToList();
        }
        public User add(User User)
        {
            try
            {
                db.User.Add(User);
                db.SaveChanges();
                return User;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public User update(User User)
        {
            try
            {
                var _User = db.User.FirstOrDefault(x => x.MaTK == User.MaTK);
                _User.TK = User.TK;
                _User.MK = User.MK;
                _User.MaNV = User.MaNV;
                _User.Quyen = User.Quyen;
                db.SaveChanges();
                return User;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
        public User delete(string id)
        {
            try
            {
                var _User = db.User.FirstOrDefault(x => x.MaTK == id);
                db.User.Remove(_User);
                db.SaveChanges();
                return _User;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu : " + e.Message);
            }
        }
    }
}
