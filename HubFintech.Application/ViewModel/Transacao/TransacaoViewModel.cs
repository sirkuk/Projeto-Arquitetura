using HubFintech.Application.ViewModel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.ViewModel.Transacao
{
    public class TransacaoViewModel
    {
        public long Id { get; set; }
        public string CodigoTransacao { get; set; }     //Código transação alfanumérico
        public long ReferenciaId { get; set; }          //Id da transação da qual esta estornou
        public long? ContaOrigemId { get; set; }
        public long ContaDestinoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal Valor { get; set; }
        public ValidationResultViewModel ValidationResult { get; set; }
    }
}
