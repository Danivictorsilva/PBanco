using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class PoupancaPF : Conta
    {
        //Propriedades
        public PessoaJuridica PessoaJuridica { get; set; }

        //Metodos
        public PoupancaPF() { }
    }
}
