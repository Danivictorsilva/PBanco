using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Cartao
    {
        //Propriedades
        public bool FuncaoCredito { get; set; }
        public bool FuncaoDebito { get; set; }
        public float Fatura { get; set; }
        public float Limite { get; set; }
        public string Senha { get; set; }
        public string NrCartao { get; set; }
        public string CodVerificacao { get; set; }
        public DateTime Datavalidade { get; set; }
        public List<string> Extrato { get; set; }

        //Metodos
        public Cartao () { }
        public void GerarFatura() { }

    }
}
