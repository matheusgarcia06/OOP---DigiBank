using System;
using System.Threading;
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
            Console.Write("                   Digite seu nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("               =============================  ");
            Console.Write("                   Digite o CPF: ");
            var cpf = Console.ReadLine();
            Console.WriteLine("               =============================  ");
            Console.Write("                   Digite sua senha: ");
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
            Console.WriteLine("                =============================     ");

            //Espera 1 segundo para ir para a telaLogada
            Thread.Sleep(1000);

            TelaContaLogada(pessoa);
        }

        private static void TelaDeLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                  ");
            Console.Write("                   Digite o CPF: ");
            var cpf = Console.ReadLine();
            Console.WriteLine("               =============================      ");
            Console.Write("                   Digite sua senha: ");
            var senha = Console.ReadLine();
            Console.WriteLine("               =============================      ");

            //Logar no sistema

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("                Pessoa não cadastrada.            ");
                Console.WriteLine("                =============================     ");

                Console.WriteLine();
                Console.WriteLine();
            }

        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo =
                $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()} " +
                $"| Conta: {pessoa.Conta.GetNumeroDaConta()}";
            Console.WriteLine("");
            Console.WriteLine($"         Seja bem vindo, {msgTelaBemVindo}");
            Console.WriteLine("");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                        Digite a opção desejada:                 ");
            Console.WriteLine("                        =============================            ");
            Console.WriteLine("                        1 - Realizar um Depósito:                ");
            Console.WriteLine("                        =============================            ");
            Console.WriteLine("                        2 - Realizar um Saque:                   ");
            Console.WriteLine("                        =============================            ");
            Console.WriteLine("                        3 - Consultar Saldo:                     ");
            Console.WriteLine("                        =============================            ");
            Console.WriteLine("                        4 - Extrato:                             ");
            Console.WriteLine("                        =============================            ");
            Console.WriteLine("                        5 - Sair:                                ");
            Console.WriteLine("                        =============================             ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                          Opção inválida                              ");
                    Console.WriteLine("                        =============================                 ");
                    break;
            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.Write("                   Digite o valor do depósito: ");
            var valor = double.Parse(Console.ReadLine());
            Console.Write("                  =============================                        ");

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                    Depósito realizado com sucesso                     ");
            Console.WriteLine("                    =============================                      ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.Write("                   Digite o valor do Saque:  ");
            var valor = double.Parse(Console.ReadLine());
            Console.Write("                   ==========================");

            bool okSaque = pessoa.Conta.Saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");

            if (okSaque)
            {
                Console.WriteLine("                    Saque realizado com sucesso                        ");
                Console.WriteLine("                    =============================                      ");
            }
            else
            {
                Console.WriteLine("                    Saldo insuficiente                                 ");
                Console.WriteLine("                    =============================                      ");
            }

            Console.WriteLine("                                                                           ");
            Console.WriteLine("                                                                           ");
              
            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine($"                    Seu saldo é: R$ {pessoa.Conta.ConsultaSaldo()}                     ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                     ============================================                       ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                //Mostrar extrato
                var total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                                          ");
                    Console.WriteLine($"                 Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}    ");
                    Console.WriteLine($"                 Tipo de Movimentação: {extrato.Descricao}               ");
                    Console.WriteLine($"                 Valor: R$ {extrato.Valor}                                  ");
                    Console.WriteLine("                  =============================                           ");
                }

                Console.WriteLine("                                                                          ");
                Console.WriteLine($"                            SUB TOTAL: R$ {total}                        ");
                Console.WriteLine("                             ==========================                   ");

            }
            else
            {
                //Mostrar uma mensagem que não há extrato
                Console.WriteLine("                    Não há extrato a ser exibido!                        ");
                Console.WriteLine("                    =============================                        ");
            }

            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                    Entre com uma opção abaixo?                        ");
            Console.WriteLine("                    =============================                      ");
            Console.WriteLine("                    1 - Voltar para minha conta                        ");
            Console.WriteLine("                    =============================                      ");
            Console.WriteLine("                    2 - Sair                                           ");
            Console.WriteLine("                    =============================                      ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();
        }

        private static void OpcaoVoltarDeslogado()
        {
            Console.WriteLine("                    Entre com uma opção abaixo?                        ");
            Console.WriteLine("                    =============================                      ");
            Console.WriteLine("                    1 - Voltar para menú principal                     ");
            Console.WriteLine("                    =============================                      ");
            Console.WriteLine("                    2 - Sair                                           ");
            Console.WriteLine("                    =============================                      ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaPrincipal();
            else
            {
                Console.WriteLine("                         Opção Inválida!                             ");
                Console.WriteLine("                        ====================                         ");
            }
        }

    }
}
