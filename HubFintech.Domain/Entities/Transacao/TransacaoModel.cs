using HubFintech.Domain.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Entities.Transacao
{
    public class TransacaoModel
    {
        public long Id { get; set; }
        public string CodigoTransacao { get; set; }
        public long ReferenciaId { get; set; }
        public long? ContaOrigemId { get; set; }
        public long ContaDestinoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal Valor { get; set; }
        public ValidationResultModel ValidationResult { get; set; }

        public bool IsValid()
        {
            if(ValidationResult == null)
                ValidationResult = new ValidationResultModel();
            return ValidationResult.IsValid;
        }
    }
}


