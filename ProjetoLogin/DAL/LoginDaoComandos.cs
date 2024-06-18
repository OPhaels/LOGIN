using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.DAL
{
    class LoginDaoComandos
    {

        public bool tem = false;
        public string mensagem = ""; // tudo ok
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr; 

        public bool verificarLogin(string login, string senha)
        {
            //comando em SQL para verificar se tem no BDD

            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);


            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows) //verifica se tem ou não 
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados!";
            }

            return tem;
        }

        public string cadastrar(string email, string senha, string confirmar)
        {

            //comendos para inserir
            tem = false;
            if (senha.Equals(confirmar))
            {
                cmd.CommandText = "insert into logins values (@e, @s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso!";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Erro com o banco de Dados";
                }
            }
            else
            {
                this.mensagem = "Senhas não correspondem";


            }
            return mensagem;

        }
    }
}
