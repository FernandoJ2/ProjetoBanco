using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetoGrillo
{
    internal class Banco
    {
        public string Nome { get; set; }
        public short Numero { get; set; }
        public Endereco Endereco { get; set; }
        public List<Conta> Contas { get; private set; }

        public Banco()
        {
            Contas = new List<Conta>();
        }

        public Conta AbrirConta(Cliente cliente)
        {
            var numeroConta = Contas.Count + 1;

            var conta = new Conta(Enums.TipoConta.Corrente, 1, numeroConta, this);

            Contas.Add(conta);
            return conta;
        }

        public Conta ObterConta(int agencia, int numeroConta)
        {
            var conta = Contas.FirstOrDefault(c => c.Agencia == agencia && c.Numero == numeroConta);

        if (conta == null)
            throw new Exception("Conta não encontrada");

        return conta;
        }

    }
}
