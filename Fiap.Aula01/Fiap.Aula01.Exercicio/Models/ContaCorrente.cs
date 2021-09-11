using Fiap.Aula01.Exercicio.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Models
{
    class ContaCorrente : Conta
    {
        public decimal Limite { get; set; }
        public TipoConta Tipo { get; set; }

        public ContaCorrente(int agencia, int numero, IList<Cliente> clientes,
                TipoConta tipo) : base (agencia, numero, clientes)
        {
            Tipo = tipo;
            //CTRL + K + C (Comenta o código selecionado)
            //Limite = 0;
            //if (Tipo == TipoConta.Especial)
            //{
            //    Limite = 500;
            //} else if (Tipo == TipoConta.Premium)
            //{
            //    Limite = 1000;
            //}
            //Ternário ( condição ? se verdadeiro : se falso)
            Limite = Tipo == TipoConta.Especial ? 500 : Tipo == TipoConta.Premium ? 1000 : 0;
        }

        public override string ToString()
        {
            return base.ToString() + $", Tipo: {Tipo}, Limte: {Limite}";
        }

        public override void Retirar(decimal valor)
        {
            if (valor > Saldo + Limite)
            {
                throw new NoBalanceException($"Saldo Insuficiente, valor disponível: {Saldo + Limite}");
            }
            Saldo -= valor;
        }
    }

    enum TipoConta
    {
        Comum, Especial, Premium
    }
}
