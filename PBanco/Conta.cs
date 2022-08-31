using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal abstract class Conta
    {
        //Propriedades
        public int IDAgencia { get; set; }
        public int IDConta { get; set; }
        public string Senha { get; set; }
        public List<string> Extrato { get; set; }
        public float Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool StatusAberta { get; set; }

        //Metodos
        public Conta () { }
        public void Sacar() { }
        public void Depositar() { }
        public void ConsultarSaldo() { }
        public void ExibirExtrato() { }
    }
}
