using System;
using System.Collections.Generic;
using System.Text;
using ProjetoGrillo.Enums;

namespace ProjetoGrillo
{
    internal class Transacao
    {
        public TipoTansacao TipoTansacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHora { get; private set; }

        public Transacao(string descricao, decimal valor, TipoTansacao tipotransacao)
        {
            Descricao = descricao;
            Valor = valor;
            TipoTansacao = tipotransacao;
            DataHora = DateTime.Now;
        }
    }
}
