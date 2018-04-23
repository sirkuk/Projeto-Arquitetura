using DFK.Domain.Entities.Validation;
using DFK.Domain.Validations.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Entities.Cliente
{
    public class ClienteModel
    {
        public long Id { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public string Cnpj { get; set; }
        public string Razaosocial { get; set; }
        public string NomeFantasia { get; set; }
        public ValidationResultModel ValidationResult { get; set; }

        public bool IsValid()
        {
            ClienteEstaConsistenteValidation.Validar(this);
            return ValidationResult.IsValid;
        }
    }
}
