using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class ContaCorrente : Conta
    {
        //Propriedades
        public string TipoDeConta { get; set; }
        public float Limite { get; set; }
        public Cartao Cartao { get; set; }



        //Metodos
        public ContaCorrente() { }
        public void Tranferir() { }
        public void Pagar() { }
    }
}
