using HubFintech.Domain.Entities.Transacao;
using HubFintech.Domain.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Validations.Transacao
{
    public class TransacaoEstaConsistenteValidation
    {
        public static void Validar(TransacaoModel transacao)
        {
            transacao.ValidationResult = new ValidationResultModel();

            if(transacao.ContaDestinoId <= 0)
                transacao.ValidationResult.Add("Conta destino inválido.");

            if (transacao.Valor == 0)
                transacao.ValidationResult.Add("Valor de transação zerado.");
        }
    }
}
