using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("                                                  ");
            Console.WriteLine("                Digite a Opção desejada:          ");
            Console.WriteLine("               =============================      ");
            Console.WriteLine("                1 - Criar Conta:                  ");
            Console.WriteLine("               =============================      ");
            Console.WriteLine("                2 - Entrar com CPF e Senha:       ");
            Console.WriteLine("               =============================      ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaDeLogin();
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }

        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                  ");
            Console.WriteLine("                Digite seu nome:                  ");
            var nome = Console.ReadLine();
            Console.WriteLine("               =============================      ");
            Console.WriteLine("                Digite o CPF:                     ");
            var cpf = Console.ReadLine();
            Console.WriteLine("               =============================      ");
            Console.WriteLine("                Digite sua senha:                 ");
            var senha = Console.ReadLine();
            Console.WriteLine("               =============================      ");
           
            //Criar uma conta
        }

        private static void TelaDeLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                  ");
            Console.WriteLine("                Digite o CPF:                     ");
            var cpf = Console.ReadLine();
            Console.WriteLine("               =============================      ");
            Console.WriteLine("                Digite sua senha:                 ");
            var senha = Console.ReadLine();
            Console.WriteLine("               =============================      ");

            //Logar no sistema

        }
    }
}
