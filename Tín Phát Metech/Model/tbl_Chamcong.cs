using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tín_Phát_Metech.EF;

namespace Tín_Phát_Metech.Model
{
    class tbl_Chamcong
    {

        TinPhatEntities db = new TinPhatEntities();
        private static tbl_Chamcong instance;

        public static tbl_Chamcong Instance
        {
            get { if (instance == null) instance = new tbl_Chamcong(); return tbl_Chamcong.instance; }
            private set { tbl_Chamcong.instance = value; }
        }

        private tbl_Chamcong() { }
    }
}
