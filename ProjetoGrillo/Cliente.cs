using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGrillo
{
    internal class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string cpf, DateTime dataDeNascimento, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
            Endereco = endereco;
        }

    }
}
