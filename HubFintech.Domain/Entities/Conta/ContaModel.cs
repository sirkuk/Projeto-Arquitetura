using HubFintech.Domain.Entities.Cliente;
using HubFintech.Domain.Entities.Validation;
using HubFintech.Domain.Validations.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Entities.Conta
{
    public class ContaModel
    {
        public long Id { get; set; }
        public long? ContaPaiId { get; set; }
        public long ClienteId { get; set; }
        public bool Matriz { get; set; }
        public string Nome { get; set; }
        public ClienteModel Cliente { get; set; }
        public short Status { get; set; }
        public DateTime DataCriacao { get; set; }        
        public ValidationResultModel ValidationResult { get; set; }

        public bool IsValid()
        {
            ContaEstaConsistenteValidation.Validar(this);
            return ValidationResult.IsValid;
        }
    }
}
