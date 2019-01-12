using System;
using System.Collections.Generic;
using System.Text;
using ProjetoGrillo.Enums;

namespace ProjetoGrillo
{
    internal class Conta
    {
        public TipoConta TipoConta { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Banco Banco { get; private set; }
        public List<Transacao> Transacoes { get; private set; }

        public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;
            Transacoes = new List<Transacao>();
        }

        public void Sacar(decimal Valor)
        {
            if (Valor <= 0)
                throw new Exception("O valor solicitado é invalido");
            if (Valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar o saque");
            Debitar("Retirado", Valor);

            Console.WriteLine("Saque realizado com sucesso.");
        }

        public void Depositar(decimal Valor)
        {
            if (Valor <= 0)
                throw new Exception("O valor é invalido.");

            Creditar("Deposito", Valor);

            Console.WriteLine("Deposito realizado com sucesso.");
        }

        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor é invalido.");
            if (valor > Saldo)
                throw new Exception("Saldo insulficiente para realizar a transferencia.");

            var contaDestino = Banco.ObterConta(agencia, numeroConta);

            contaDestino.Creditar("Transferencia", valor);

            Debitar("Transferencia", valor);

            Console.WriteLine("Transferencia realizada com sucesso");
        }

        public void TirarEstrato()
        {
            if (Transacoes.Count > 0)
            {
                foreach(var transacao in Transacoes)
                {
                    var cor = transacao.TipoTansacao == TipoTansacao.Debito ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;
                    Console.WriteLine($"{transacao.Descricao.PadRight(20, '-')}{transacao.Valor.ToString("C")}");

                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Empty);
                var saldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldoDescricao);
            }
        }

        private void Creditar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTansacao.Credito);
            Transacoes.Add(transacao);
            Saldo = Saldo + valor;
        }

        private void Debitar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTansacao.Debito);
            Transacoes.Add(transacao);
            Saldo = Saldo - valor;
        }
    }
}
