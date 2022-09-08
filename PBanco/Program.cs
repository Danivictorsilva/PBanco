using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace PBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaracoes
            Agencia agencia = new Agencia();
            //Alterar os caminhos para os corretos antes de rodar!
            string pathListaDeContas = "C:\\Users\\5BY5\\source\\repos\\PBanco\\PBanco\\ListaContas.txt";
            string pathListaDeFuncionarios = "C:\\Users\\5BY5\\source\\repos\\PBanco\\PBanco\\ListaFuncionarios.txt";
            string pathGerente = "C:\\Users\\5BY5\\source\\repos\\PBanco\\PBanco\\Gerente.txt";

            //Programa Principal
            CarregarListaDeContas(agencia.ListaContas, pathListaDeContas);
            CarregarListaDeFuncionarios(agencia.ListaFuncionarios, pathListaDeFuncionarios);
            CarregarGerente(agencia.Gerente, pathGerente);
            Console.WriteLine(agencia.Gerente);
            Conta conta = new Conta();
            if (agencia.ListaFuncionarios.Count == 0) ExibirMenuInicializacao(agencia);
            switch ("0")
            {
                case "0":
                    int aux1 = TelaInicial();
                    if (aux1 == 1) goto case "1";
                    else if (aux1 == 2) goto case "2";
                    break;
                case "1":
                    if (agencia.ListaContas.Count == 0)
                    {
                        ReadString("A agencia ainda nao possui contas cadastradas\nPressione qualquer tecla para continuar...");
                        goto case "0";
                    }
                    conta = TelaLogin(agencia, conta);
                    goto case "3";
                case "2":
                    if (TelaCadastro(agencia)) goto case "1";
                    break;
                case "3":
                    if (MenuConta(conta)) goto case "0";
                    break;
            }
            DescarregarListaDeContas(agencia.ListaContas, pathListaDeContas);
            DescarregarListaDeFuncionarios(agencia.ListaFuncionarios, pathListaDeFuncionarios);
            DescarregarGerente(agencia.Gerente, pathGerente);
            Console.WriteLine("Saindo do programa...");
        }
        static void ExibirMenuInicializacao(Agencia agencia)
        {
            Console.Clear();
            Console.WriteLine("*********BEM VINDO AO BANCO MORANGAO*********");
            Console.WriteLine("Antes de iniciar, cadastre um gerente e um funcionario:");
            Console.WriteLine(">>> Cadastro do Gerente:");
            Gerente gerente = new Gerente();
            gerente.CadastrarFuncionario();
            agencia.Gerente = gerente;
            Console.WriteLine(">>> Cadastro do Funcionario:");
            Escriturario escriturario = new Escriturario();
            escriturario.CadastrarFuncionario();
            agencia.ListaFuncionarios.Add(escriturario);
        }
        static int TelaInicial()
        {
            string op = "-1";
            string msg = "";
            string[] options = new string[] { "1", "2", "0" };
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********TELA INICIAL*********");
                Console.WriteLine("Informe a operacao desejada: ");
                Console.WriteLine("1. Ja possuo cadastro");
                Console.WriteLine("2. Nao possuo cadastro");
                Console.WriteLine("0. Sair do Programa");
                Console.WriteLine("{0}{1}", msg == "" ? "" : ">>> ", msg);
                op = ReadString("Opcao: ");
                if (!BuscarNaLista(op, options))
                {
                    msg = String.Format("Opcao invalida! Digite novamente...");
                    continue;
                }
                switch (op)
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    case "0":
                        return 0;
                }
            }
            return -1;
        }
        static Conta TelaLogin(Agencia agencia, Conta conta)
        {
            conta = new Conta();
            if (agencia.ListaContas.Count == 0)
            {
                
                return null;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*********MENU LOGIN*********");
                string user = ReadString("Digite o numero da conta: ");
                if (!agencia.EfetuarLogin(user, ReadString("Digite a senha: ")))
                {
                    Console.WriteLine("Usuario ou senha incorreta, por favor refaca o login!");
                    ReadString("Pressione qualquer tecla para continuar...");
                    continue;
                }
                conta = agencia.BuscarConta(user);

                return conta;
            }
        }
        static bool TelaCadastro(Agencia agencia)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*********MENU CADASTRO*********");

                Cliente cliente = new Cliente();
                cliente.CadastrarPessoa();
                Conta conta = cliente.CadastrarConta(agencia);
                agencia.ListaFuncionarios[0].AbrirConta(conta);
                agencia.Gerente.AprovarConta(conta);
                agencia.ListaContas.Add(conta);
                Console.WriteLine("Conta criada com sucesso. O numero da sua nova conta é {0}, ANOTE ESTE NUMERO!", conta.IDConta);
                ReadString("Pressione qualquer tecla para continuar...");
                return true;
            }
        }
        static bool MenuConta(Conta conta)
        {
            string op = "-1";
            string msg = "";
            string[] options = new string[] { "1", "2", "3", "0" };
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MENU CONTA*********");
                Console.WriteLine("Informe a operacao desejada: ");
                Console.WriteLine("1. Sacar");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Consultar Saldo");

                Console.WriteLine("0. Voltar Para a Tela Inicial");
                Console.WriteLine("{0}{1}", msg == "" ? "" : ">>> ", msg);

                op = ReadString("Opcao: ");
                if (!BuscarNaLista(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }

                switch (op)
                {
                    case "1":
                        msg = conta.Sacar(ReadFloat("Digite o valor que deseja sacar: "));
                        break;
                    case "2":
                        conta.Depositar(ReadFloat("Digite o valor que deseja depositar: "));
                        msg = "Deposito realizado com sucesso!";
                        break;
                    case "3":
                        msg = String.Format("Saldo: R${0:0.00}", conta.ConsultarSaldo());
                        break;
                    case "0":
                        return true;
                }
            }
            return false;
        }
        static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        static float ReadFloat(string text)
        {
            Console.Write(text);
            return float.Parse(Console.ReadLine());
        }
        static bool BuscarNaLista(string c, string[] list)
        {
            for (int i = 0; i < list.Length; i++)
                if (list[i] == c) return true;
            return false;
        }
        static void CarregarListaDeContas(List<Conta> list, string arq)
        {
            using StreamReader sr = new StreamReader(arq);
            {
                string line = sr.ReadLine();
                string[] aux;
                while (line != null && line != "")
                {
                    aux = line.Split(';');
                    list.Add(new Conta
                    (
                        aux[0],
                        aux[1],
                        float.Parse(aux[2]),
                        bool.Parse(aux[3]),
                        new Cliente
                        (
                            aux[5],
                            aux[6],
                            DateTime.Parse(aux[7]),
                            new Endereco(aux[8], aux[9], aux[10], aux[11], aux[12], aux[13], aux[14])),
                            aux[15]
                    )

                    );
                    line = sr.ReadLine();
                }
            }
        }

        static void DescarregarListaDeContas(List<Conta> list, string arq)
        {
            using (StreamWriter sw = new StreamWriter(arq))
            {
                foreach (Conta conta in list) sw.WriteLine(conta);
            }
        }
        static void CarregarListaDeFuncionarios(List<Escriturario> list, string arq)
        {
            using StreamReader sr = new StreamReader(arq);
            {
                string line = sr.ReadLine();
                string[] aux;
                while (line != null && line != "")
                {
                    aux = line.Split(';');

                    list.Add(
                        new Escriturario
                        (
                            aux[0],
                            aux[1],
                            DateTime.Parse(aux[2]),
                            new Endereco(aux[3], aux[4], aux[5], aux[6], aux[7], aux[8], aux[9]),
                            aux[10]
                        )
                    );
                    line = sr.ReadLine();
                }
            }
        }
        static void DescarregarListaDeFuncionarios(List<Escriturario> list, string arq)
        {
            using (StreamWriter sw = new StreamWriter(arq))
            {
                foreach (Escriturario func in list) sw.WriteLine(func);
            }
        }
        static void CarregarGerente(Gerente gerente, string arq)
        {
            using StreamReader sr = new StreamReader(arq);
            {
                string line = sr.ReadLine();
                if (line == "" || line == null) return;
                string[] aux;
                aux = line.Split(';');
                gerente.Nome = aux[0];
                gerente.CPF = aux[1];
                gerente.DataNasc = DateTime.Parse(aux[2]);
                gerente.Endereco = new Endereco(aux[3], aux[4], aux[5], aux[6], aux[7], aux[8], aux[9]);
                gerente.Matricula = aux[10];
            }
        }
        static void DescarregarGerente(Gerente gerente, string arq)
        {
            using (StreamWriter sw = new StreamWriter(arq)) sw.WriteLine(gerente);
        }
    }
}
