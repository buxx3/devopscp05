using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Models
{
    abstract class Conta
    {
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; protected set; }
        public DateTime DataAbertura { get; set; }
        public IList<Cliente> Clientes { get; set; }

        public Conta(int agencia, int numero, IList<Cliente> clientes)
        {
            Agencia = agencia;
            Numero = numero;
            Clientes = clientes;
        }

        public override string ToString()
        {
            var aux = ""; //variável auxiliar que armazena os dados dos clientes
            foreach (var item in Clientes)
            {
                aux += $"{item}\n";
            }
            return $"{aux}Número: {Numero}, Agência: {Agencia}, Saldo: {Saldo}\nData Abertura: {DataAbertura}";
        }

        public virtual void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public abstract void Retirar(decimal valor);
    }
}
