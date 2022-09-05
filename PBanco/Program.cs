using System;

namespace PBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            switch ("0")
            {
                case "0":
                    int aux1 = TelaInicial();
                    if (aux1 == 1) goto case "1";
                    else if (aux1 == 2) goto case "2";
                    break;
                case "1":
                    if (TelaLogin()) goto case "3";
                    break;
                case "2":
                    if (TelaCadastro()) goto case "3";
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
            string[] options = new string[] { "1", "2", "0"};
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("Informe a operacao desejada: ");
                Console.WriteLine("1. Ja possuo cadastro");
                Console.WriteLine("2. Nao possuo cadastro");
                Console.WriteLine("0. Sair");
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

        static bool TelaLogin() => true;
        static bool TelaCadastro() => true;
        static bool MenuConta() => false;
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
