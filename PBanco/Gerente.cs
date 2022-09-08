using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Gerente : Funcionario
    {
        //Propriedades

        //Metodos
        public Gerente() { }
        public Gerente(string nome, string cpf, DateTime datanasc, Endereco endereco, string matricula)
            :base(nome, cpf, datanasc, endereco, matricula) { }
        public void AprovarConta(Conta conta)
        {
            conta.StatusAberta = true;
        }
    }
}
