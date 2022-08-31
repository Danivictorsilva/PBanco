using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal abstract class Pessoa
    {
        //Propriedades
        public Endereco Endereco { get; set; }
        public DateTime DataNasc_Registro { get; set; }
        public float FaturamentoMensal { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        //Metodos
        public Pessoa () { }

    }
}
