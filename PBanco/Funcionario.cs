using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal abstract class Funcionario : Pessoa
    {
        //Propriedades
        public string Matricula { get; set; }

        //Metodos
        public Funcionario() { }
        public Funcionario(string nome, string cpf, DateTime datanasc, Endereco endereco, string matricula)
            :base(nome, cpf, datanasc, endereco)
        {
            Matricula = matricula;
        }
        public void AbrirConta(Conta conta)
        {
            Random random = new Random();
            conta.IDAgencia = "0001";
            conta.IDConta = random.Next(10000).ToString() + "-" + random.Next(10).ToString();
        }
        public void CadastrarFuncionario()
        {
            base.CadastrarPessoa();
            Matricula = ReadString("Matricula no Banco (XXXX-X): ");
        }
        static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public override string ToString()
        {
            return String.Format("{0};{1}", base.ToString(), Matricula);
        }
    }
}
