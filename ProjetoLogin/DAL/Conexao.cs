using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.DAL
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();
        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-B2ROADQ;Initial Catalog=acesso;Integrated Security=True;Encrypt=False";
        }

        public SqlConnection conectar()
        {
            if (con.State != System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;

        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();

            }
        }
    }
}
