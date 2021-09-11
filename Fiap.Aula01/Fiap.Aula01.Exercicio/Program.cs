using Fiap.Aula01.Exercicio.Exceptions;
using Fiap.Aula01.Exercicio.Models;
using System;
using System.Collections.Generic;

namespace Fiap.Aula01.Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ler a quantidade de clientes
            Console.WriteLine("Digite a quantidade de clientes");
            var quantidade = int.Parse(Console.ReadLine());

            //Instanciar uma lista de clientes
            var clientes = new List<Cliente>();

            //Laço para ler os dados do cliente e adicionar na lista
            for (int i = 0; i < quantidade; i++)
            {
                //Ler os dados do cliente (Id, Nome e Cpf)
                Console.WriteLine("Digite o Id cliente");
                var id = long.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Nome do cliente");
                var nome = Console.ReadLine();

                Console.WriteLine("Digite o Cpf do cliente");
                var cpf = Console.ReadLine();

                //Instanciar um cliente
                var cliente = new Cliente(id, nome) { Cpf = cpf };

                //Adicionar o cliente na lista
                clientes.Add(cliente);
            }//For

            //Ler os dados da conta corrente (Número, Agencia, Data Abertura e Tipo)
            Console.WriteLine("Digite o número da conta");
            var numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da agência");
            var agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de abertura");
            var data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tipo de conta (comum, especial, premium)");
            var tipo = (TipoConta)Enum.Parse(typeof(TipoConta), Console.ReadLine(), true);

            //Instanciar a Conta corrente
            var conta = new ContaCorrente(agencia, numero, clientes, tipo) { DataAbertura = data };

            //Exibir os dados da conta
            Console.WriteLine(conta);

            //Variável para armazenar a escolha do usuário
            int opcao;
            //Laço de repetição
            do
            {
                //Exibir o menu com as opções 1-Depositar 2-Retirar 3-Exibir Dados 0-Sair
                Console.WriteLine("\nEscolha: \n1-Depositar \n2-Retirar \n3-Exibir Dados \n0-Sair");
                //Ler a opção do usuário
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        //1-Ler o valor para depósito
                        Console.WriteLine("Digite o valor para depósito");
                        var valor = decimal.Parse(Console.ReadLine());
                        //Depositar
                        conta.Depositar(valor);
                        //Mensagem de sucesso
                        Console.WriteLine($"Valor depositado! Novo saldo: {conta.Saldo}");
                        break;
                    case 2:
                        //2-Ler o valor para retirada
                        Console.WriteLine("Digite o valor para retirar");
                        valor = decimal.Parse(Console.ReadLine());
                        try
                        {
                            //Retirar (tratar a exception)
                            conta.Retirar(valor);
                            //Mensagem de sucesso
                            Console.WriteLine($"Valor retirado! Novo saldo: {conta.Saldo}");
                        }
                        catch (NoBalanceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine(conta);
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o sistema");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 0);
        }//main
    }//class
}//namespace
