using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Connecting
    {
        private SqlConnection OpenConnect()
        {
            SqlConnection sqlConnection;
            string Connect = @"Data Source=DESKTOP-9UB1AIQ\TINPHAT;Initial Catalog=TinPhat;Persist Security Info=True;User ID=sa;Password=123456";
            using (sqlConnection = new SqlConnection(Connect))
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
            }
            return sqlConnection;
        }
        public getlist()    
    }
}
