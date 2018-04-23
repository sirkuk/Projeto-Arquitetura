using DFK.Application.ViewModel.Cliente;
using DFK.Application.ViewModel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.ViewModel.Conta
{
    public class ContaViewModel
    {
        public long Id { get; set; }
        public long? ContaPaiId { get; set; }
        public long ClienteId { get; set; }
        public bool Matriz { get; set; }
        public string Nome { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public short Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public ValidationResultViewModel ValidationResult { get; set; }
    }
}
