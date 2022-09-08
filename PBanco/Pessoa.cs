using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal abstract class Pessoa
    {
        //Propriedades
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public Endereco Endereco { get; set; }

        //Metodos
        public Pessoa() { }
        public Pessoa (string nome, string cpf, DateTime datanasc, Endereco endereco)
        {
            Nome = nome;
            CPF = cpf;
            DataNasc = datanasc;
            Endereco = endereco;
        }
        public void CadastrarPessoa()
        {
            Nome = ReadString("Nome: ");
            CPF = ReadString("CPF: ");
            DataNasc = ReadDate("Data de Nascimento: ");
            Endereco = new Endereco
                        (
                            ReadString("Rua: "),
                            ReadString("Numero: "),
                            ReadString("Complemento: "),
                            ReadString("Bairro: "),
                            ReadString("Cidade: "),
                            ReadString("UF: "),
                            ReadString("CEP: ")
                         );
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3}", Nome, CPF, DataNasc, Endereco);
        }
        static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        static DateTime ReadDate(string text)
        {
            Console.Write(text);
            return DateTime.Parse(Console.ReadLine());
        }
    }
}
