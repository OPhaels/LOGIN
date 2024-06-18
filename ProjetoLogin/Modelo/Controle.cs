using ProjetoLogin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.Modelo
{
    public class Controle
    {
        public bool tem;
        public string mensagem = "";

        public bool acessar (string login, string senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            tem = loginDao.verificarLogin(login, senha);
            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;                                  
            }
            return tem;
        }

        public string cadastrar(string email, string senha, string confirmar)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.cadastrar(email, senha, confirmar);
            if (loginDao.tem) //a mensagem que vai vir é sucesso e que ocorreu tudo certo!
            {
                this.tem = true;
            }
            return mensagem;
        }

      
    }
}
