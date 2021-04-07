using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA1
{
    class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8L9JC76E\OBJEKTINIS;Initial Catalog=RSA;Integrated Security=True");

        //string con = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.OBJEKTINIS\\MSSQL";
        public void insert(string text, BigInteger e, BigInteger n)
        {
            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO rsaData (chypherText, e, n) VALUES (@text, @e, @n)",con);
            com.Parameters.AddWithValue("@text",text);
            com.Parameters.AddWithValue("@e",e.ToString());
            com.Parameters.AddWithValue("@n", n.ToString());
            com.ExecuteNonQuery();
            //MessageBox.Show("ok");
            con.Close();
        }

    }
}
