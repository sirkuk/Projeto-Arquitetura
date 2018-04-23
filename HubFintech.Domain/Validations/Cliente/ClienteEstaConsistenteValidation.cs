using DFK.Domain.Entities.Cliente;
using DFK.Domain.Entities.Validation;
using DFK.Domain.Validations.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Validations.Cliente
{
    public class ClienteEstaConsistenteValidation
    {
        public static void Validar(ClienteModel cliente)
        {
            cliente.ValidationResult = new ValidationResultModel();

            if (string.IsNullOrEmpty(cliente.Cpf))
                cliente.ValidationResult.Add("CPF não pode ser nulo");
            else
            {
                if (!CPFValidation.Validate(cliente.Cpf))
                    cliente.ValidationResult.Add("CPF inválido");
            }

            if (!cliente.DataNascimento.HasValue)
                cliente.ValidationResult.Add("Data de Nascimento não pode ser nula");

        }
    }
}
