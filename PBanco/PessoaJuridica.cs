using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class PessoaJuridica : Cliente
    {
        //Propriedades
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }

        //Metodos
        public PessoaJuridica() { }
        public void CadastrarContaPJ() { }
    }
}
