using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Endereco
    {
        //Propriedades
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        //Metodos
        public Endereco(string rua,
            string numero, 
            string complemento, 
            string bairro, 
            string cidade, 
            string uf, 
            string cep)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            CEP = cep;

        }

        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6}",
                Rua, Numero, Complemento, Bairro, Cidade, UF, CEP);
        }


    }
}
