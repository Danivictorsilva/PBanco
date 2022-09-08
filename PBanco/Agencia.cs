using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Agencia
    {
        //Propriedades
        public int IDAgencia { get; set; }
        public List<Conta> ListaContas { get; set; }
        public List<Escriturario> ListaFuncionarios { get; set; }
        public Gerente Gerente { get; set; }

        //Metodos
        public Agencia()
        {
            IDAgencia = 1234;
            ListaContas = new List<Conta>();
            ListaFuncionarios = new List<Escriturario>();
            Gerente = new Gerente();
        }
        public bool EfetuarLogin(string idAgencia, string senha)
        {
            bool user = false;
            bool psswrd = false;
            foreach(Conta conta in ListaContas)
            {
                if (conta.IDConta == idAgencia)
                {
                    user = true;
                    if (conta.Senha == senha) {
                        psswrd = true;
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }
        public Conta BuscarConta(string idAgencia)
        {
            foreach (Conta conta in ListaContas)
            {
                if (conta.IDConta == idAgencia) return conta;

            }
            return null;
        }

    }
}
