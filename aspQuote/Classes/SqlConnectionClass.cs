using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace aspQuote.Classes
{
    public class SqlConnectionClass
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TV4EI8V\\SQLEXPRESS;Initial Catalog=aspnetQuote;Integrated Security=True;Trust Server Certificate=True");
    }
}