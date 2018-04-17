using HubFintech.Domain.Entities.Conta;
using HubFintech.Domain.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Validations.Conta
{
    public class ContaEstaConsistenteValidation
    {
        public static void Validar(ContaModel conta)
        {
            conta.ValidationResult = new ValidationResultModel();

            //Conta tipo Filial
            if(!conta.Matriz)
            {
                if (!conta.ContaPaiId.HasValue)
                    conta.ValidationResult.Add("Conta Filial deve possuir uma conta Pai associada");
            }
        }
    }
}

