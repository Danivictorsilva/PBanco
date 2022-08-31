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
        public int QtdFuncionarios { get; set; }
        public List<Conta> ListaContas { get; set; }
        public List<Funcionario> ListaFuncionarios { get; set; }
        public CaixaEletronico Caixa { get; set; }

        //Metodos
        public Agencia() { }
        public void EfetuarLogin() { }

    }
}
