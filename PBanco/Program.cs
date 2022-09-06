using System;
using System.Collections.Generic;

namespace PBanco
{
    internal class Program
    {
        const int MAX_CLIENTES = 10;
        static void Main(string[] args)
        {
            //string[,] accessDict = new string[2, MAX_CLIENTES];
            Dictionary<string, string> accessDict = new Dictionary<string, string>();

            switch ("0")
            {
                case "0":
                    int aux1 = TelaInicial();
                    if (aux1 == 1) goto case "1";
                    else if (aux1 == 2) goto case "2";
                    break;
                case "1":
                    if (TelaLogin(accessDict)) goto case "3";
                    break;
                case "2":
                    if (TelaCadastro(accessDict)) goto case "3";
                    break;
                case "3":
                    if (MenuConta()) goto case "0";
                    break;
            }

            Console.WriteLine("Saindo do programa...");
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

        static bool TelaLogin(Dictionary<string, string> accessDict)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*********MENU LOGIN*********");
                string user = ReadString("Digite o e-mail de usuario: ");
                string password = ReadString("Digite a senha: ");
                if (accessDict[user] != password || !accessDict.ContainsKey(user))
                {
                    Console.WriteLine("Usuario ou senha incorreta");
                    continue;
                }
                else
                    ReadString(">>> Cadastro feito com sucesso! Pressione qualquer tecla para continuar...");
                return true;
            }
            return false;
        }
        static bool TelaCadastro(Dictionary<string, string> accessDict, )
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*********MENU CADASTRO*********");
                new 
                string user = ReadString("Digite o novo e-mail de usuario: ");
                string password = ReadString("Digite a nova senha: ");
                accessDict.Add(user, password);
                /*
                try
                {
                    accessDict.Add(user,password);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("O e-mail já foi cadastrado!");
                    continue;
                }*/
                return true;
            }
            return false;
        }
        static bool MenuConta()
        {
            string op = "-1";
            string msg = "";
            string[] options = new string[] { "1", "2", "3", "4", "0" };
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MENU CONTA*********");
                Console.WriteLine("Informe a operacao desejada: ");
                Console.WriteLine("1. Sacar");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Consultar Saldo");
                Console.WriteLine("4. Consultar Extrato");

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
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        return true;
                }
            }
            return true;
        }
        static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        static bool BuscarNaLista(string c, string[] list)
        {
            for (int i = 0; i < list.Length; i++)
                if (list[i] == c) return true;
            return false;
        }
    }
}
