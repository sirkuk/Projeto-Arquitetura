using HubFintech.Domain.Entities.Conta;
using HubFintech.Domain.Interfaces.Repositories.Conta;
using HubFintech.Domain.Interfaces.Services.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubFintech.Domain.Services.Conta
{
    public class ContaService : IContaService
    {
        private IContaRepository _contaRepo;

        public ContaService(IContaRepository contaRepo)
        {
            _contaRepo = contaRepo;
        }

        public void Create(ContaModel conta)
        {
            if (conta.IsValid())
            {
                if (conta.ContaPaiId.HasValue && this.GetById(conta.ContaPaiId.Value) == null)
                    throw new Exception("Conta referência inexistente.");
                                
                _contaRepo.Create(conta);
            }
            else
                throw new Exception(conta.ValidationResult.Erros.Aggregate((i, j) => i + "," + j));
        }

        public ContaModel GetById(long contaId)
        {
            return _contaRepo.GetById(contaId);
        }
    }
}
