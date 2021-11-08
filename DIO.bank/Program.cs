using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {

        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opçaoUsuario = ObterOpcaoUsuario();

            while (opçaoUsuario.ToUpper() != "x")
            {
                switch (opçaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opçaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigen = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            ListContas[indiceContaOrigen].Transferir(valorTransferencia, ListContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Dihite o valor do seu deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Depositar(valorDeposito);
        }

        private static void InserirConta()
        {
           Console.WriteLine("Inserir nova Conta");

           Console.Write("Digite 1 para Conta Fisica Ou 2 para Juridica: ");
           int entradaTipoConta = int.Parse(Console.ReadLine());

           Console.Write("Digite o Nome do Cliente: ");
           string entradaNome = Console.ReadLine();

           Console.Write("Digite o Saldo inicial: ");
           double entradaSaldo = double.Parse(Console.ReadLine());

           Console.Write("Digite o crédito: ");
           double entradaCredito = double.Parse(Console.ReadLine());

           Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        Credito: entradaCredito,
                                        nome: entradaNome);

            ListContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("listar Contas");

            if (ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }

            for (int i = 0; i < ListContas.Count; i++)
            {
                Conta conta = ListContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank a seu dispor");
            Console.WriteLine("Informe a desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opçaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçaoUsuario;

        }
    }
}
