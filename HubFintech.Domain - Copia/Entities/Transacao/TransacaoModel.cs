using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Entities.Transacao
{
    public class TransacaoModel
    {
        public long Id { get; set; }
        public Guid CodigoTransacao { get; set; }
        public long ReferenciaId { get; set; }
        public long ContaOrigem { get; set; }
        public long ContaDestino { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}


