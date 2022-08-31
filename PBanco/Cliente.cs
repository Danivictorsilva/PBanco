using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal abstract class Cliente : Pessoa
    {
        //Propriedades

        //Metodos
        public Cliente() { }
        public void PedirEmprestimo() { }
    }
}
