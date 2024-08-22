using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class DB
    {
        public SqlConnection DBconnect()
        {
            string con_string = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=Game;Integrated Security=True";
            SqlConnection con = new SqlConnection(con_string);
            return con;
        }
    }
}
