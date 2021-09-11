using Fiap.Aula01.Exercicio.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Models
{
    class ContaPoupanca : Conta, IContaInvestimento
    {
        public decimal Taxa { get; set; }

        public ContaPoupanca(int agencia, int numero, IList<Cliente> clientes, 
                decimal taxa) : base(agencia, numero, clientes)
        {
            Taxa = taxa;
        }

        public decimal CalcularRetornoInvestimento()
        {
            return Saldo * 4/100;
        }

        public override void Retirar(decimal valor)
        {
            if (valor + Taxa > Saldo)
            {
                throw new NoBalanceException($"Saldo insuficiente, o valor disponível é {Saldo - Taxa}");
            }
            Saldo -= valor + Taxa;
        }
    }
}
