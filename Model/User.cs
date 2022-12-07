using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public string Ma_User { get; set; }
        public string Ma_NV { get; set; }
        public string User1 { get; set; }
        public string Pass { get; set; }
        public string Permision { get; set; }
        public System.DateTime Creat_Date { get; set; }
        public User(string id, string name, string user, string pass, string quyen)
        {
            this.Ma_User = id;
            this.Ma_User = name;
            this.User1 = user;
            this.Pass = pass;
            this.Permision = quyen;
            this.Creat_Date = DateTime.Now;
        }
    }
}
