using DFK.Application.ViewModel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.ViewModel.Cliente
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public string Cnpj { get; set; }
        public string Razaosocial { get; set; }
        public string NomeFantasia { get; set; }
        public ValidationResultViewModel ValidationResult { get; set; }
    }
}
