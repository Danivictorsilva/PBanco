using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Cliente : Pessoa
    {
        //Propriedades

        //Metodos
        public Cliente() { }
        public Cliente(string nome, string cpf, DateTime datanasc, Endereco endereco)
            : base(nome, cpf, datanasc, endereco) { }

        public Conta CadastrarConta(Agencia agencia)
        {
            Conta conta = new Conta
                (
                    "",
                    "",
                    0,
                    false,
                    this,
                    ReadString("Digite uma nova senha: ")
                );
            return conta;
        }
        static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
    }
}
