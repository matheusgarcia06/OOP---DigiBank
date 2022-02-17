using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
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

            Console.WriteLine("                                              ");
            Console.Write("                Digite seu nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("               =============================  ");
            Console.Write("                Digite o CPF: ");
            var cpf = Console.ReadLine();
            Console.WriteLine("               =============================  ");
            Console.Write("                Digite sua senha: ");
            var senha = Console.ReadLine();
            Console.WriteLine("               =============================  ");

            //Criar uma conta

            var contaCorrente = new ContaCorrente();
            var pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                Conta cadastrada com sucesso.     ");
            Console.WriteLine("               =============================      ");
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
