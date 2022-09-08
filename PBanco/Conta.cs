using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PBanco
{
    internal class Conta
    {
        //Propriedades
        public string IDAgencia { get; set; }
        public string IDConta { get; set; }
        public float Saldo { get; set; }
        public bool StatusAberta { get; set; }
        public DateTime DataAbertura { get; set; }
        public Cliente Cliente { get; set; }
        public string Senha { get; set; }

        //Metodos 
        public Conta() { }
        public Conta(string idAgencia, string idConta, float saldo, bool statusAberta, Cliente cliente, string senha)
        {
            IDAgencia = idAgencia;
            IDConta = idConta;
            Saldo = saldo;
            StatusAberta = statusAberta;
            DataAbertura = DateTime.Now;
            Cliente = cliente;
            Senha = senha;
        }
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6}",
                IDAgencia, IDConta, Saldo, StatusAberta, DataAbertura, Cliente, Senha);
        }
        public string Sacar(float saque)
        {
            string msg = "";
            if (Saldo < saque) msg = "Impossivel realizar o saque, saldo insuficiente!";
            else
            {
                Saldo -= saque;
                msg = "Saque Realizado com sucesso!";
            }
            return msg;
        }
        public void Depositar(float deposito)
        {
            Saldo += deposito;
        }
        public float ConsultarSaldo() => Saldo;
    }
}
