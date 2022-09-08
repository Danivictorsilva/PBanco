using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Escriturario : Funcionario
    {
        //Propriedades

        //Metodos
        public Escriturario() { }
        public Escriturario(string nome, string cpf, DateTime datanasc, Endereco endereco, string matricula)
            :base(nome, cpf, datanasc, endereco, matricula) { }

    }
}
