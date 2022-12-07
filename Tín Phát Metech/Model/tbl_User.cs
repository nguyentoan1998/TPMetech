using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF.Data.edmx.Data.Context.tt;
using Tín_Phát_Metech.EF.Data.edmx.Data.tt;

namespace Tín_Phát_Metech.Model
{
    class tbl_User
    {
        TinPhatEntities db = new TinPhatEntities();
        public User getItem(string ID)
        {
            return db.User.FirstOrDefault(x => x.Ma_User == ID);
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
                var _User = db.User.FirstOrDefault(x => x.Ma_User == User.Ma_User);
                _User.User1 = User.User1;
                _User.Pass = User.Pass;
                _User.Ma_NV = User.Ma_NV;
                _User.Permision = User.Permision;
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
                var _User = db.User.FirstOrDefault(x => x.Ma_User == id);
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
