using HubFintech.Domain.Entities.Conta;
using HubFintech.Domain.Entities.Transacao;
using HubFintech.Domain.Enum;
using HubFintech.Domain.Interfaces.Repositories.Conta;
using HubFintech.Domain.Interfaces.Repositories.Transacao;
using HubFintech.Domain.Interfaces.Services.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubFintech.Domain.Services.Transacao
{
    public class TransacaoService : ITransacaoService
    {
        private ITransacaoRepository _transacaoRepo;
        private IContaRepository _contaRepo;

        public TransacaoService(ITransacaoRepository transacaoRepo, IContaRepository contaRepo)
        {
            _transacaoRepo = transacaoRepo;
            _contaRepo = contaRepo;
        }

        public string Create(TransacaoModel transacao)
        {
            if (transacao.IsValid())
            {
                ContaModel contaOrigem = null;

                ContaModel contaDestino = _contaRepo.GetById(transacao.ContaDestinoId);

                // ** Para melhor controle do erros precisava-se implementar conjunto 
                //de Exceções especializadas no Cross cutting.
                //E uma implementação no Cross cutting de Log seria necessário.
                
                ValidarContaOrigem(transacao, contaDestino, ref contaOrigem);

                ValidarContaDestino(contaDestino, contaOrigem);

                transacao.CodigoTransacao = string.Format("{0}{1}", 
                    contaDestino != null && contaDestino.Matriz ?
                        "M" : string.Empty,
                        Guid.NewGuid().ToString().Replace("-", string.Empty));

                transacao.DataCadastro = transacao.DataAtualizacao = DateTime.Now;

                return _transacaoRepo.Create(transacao);
            }
            else
                throw new Exception(transacao.ValidationResult.Erros.Aggregate((i, j) => i + "," + j));
        }

        private void ValidarContaDestino(ContaModel contaDestino, ContaModel contaOrigem)
        {            
            if (contaDestino == null)
                throw new Exception("Conta destino inválida.");
            else if (contaDestino.Matriz)
            {
                if (contaOrigem != null)
                    throw new Exception("Não pode transferir à conta Matriz. Apenas aporte.");
                if (contaOrigem == null && contaDestino.Status != (short)EnumSituacaoConta.Ativo)
                    throw new Exception("Não pode fazer aporte à conta Matriz inativada.");
            }
            else if (!contaDestino.Matriz)
            {
                if (contaOrigem == null)
                    throw new Exception("Não pode transferir sem conta origem.");
                else if (contaDestino.Status != (short)EnumSituacaoConta.Ativo || contaOrigem.Status != (short)EnumSituacaoConta.Ativo)
                    throw new Exception("Não pode transferir entre contas ativas.");
                else if (contaOrigem != null)
                    if (!_contaRepo.ValidarHierarquia(contaDestino.Id, contaOrigem.Id))
                        throw new Exception("Não pode transferir entre contas de hierarquia diferente.");                
            }
        }

        private void ValidarContaOrigem(TransacaoModel transacao, ContaModel contaDestino, ref ContaModel contaOrigem)
        {
            if (transacao.ContaDestinoId > 0 && transacao.ContaOrigemId.HasValue)
            {
                if (transacao.ContaOrigemId.Value > 0)
                    contaOrigem = _contaRepo.GetById(transacao.ContaOrigemId.Value);
                else
                    transacao.ContaOrigemId = null;

                if (contaOrigem == null && !contaDestino.Matriz)
                    throw new Exception("Conta origem inválida.");
            }
        }

        public string Estornar(TransacaoModel transacao)
        {
            if (transacao.IsValid())
            {
                transacao.ContaOrigemId = transacao.ContaOrigemId.HasValue && transacao.ContaOrigemId.Value == 0 ? null : transacao.ContaOrigemId;

                //Aporte
                if (transacao.ContaOrigemId == null && transacao.ContaDestinoId > 0)
                {
                    var contaDestino = _contaRepo.GetById(transacao.ContaDestinoId);
                    if (contaDestino != null && contaDestino.Matriz)
                    {
                        var transacaoEstornar = _transacaoRepo.GetByCodTransacao(transacao.CodigoTransacao);

                        if (transacaoEstornar != null)
                            return CriarEstorno(transacao, transacaoEstornar);
                        else                        
                            throw new Exception(string.Format("Não foi possível realizar o estorno do aporte, código: {0}", transacao.CodigoTransacao));                        
                    }
                    else
                        throw new Exception("Não é possível fazer transferência para conta destino sem origem.");
                }
                else if (transacao.ContaOrigemId.HasValue && transacao.ContaOrigemId.Value > 0 && transacao.ContaDestinoId > 0)
                {
                    var transacaoEstornar = _transacaoRepo.GetById(transacao.Id);

                    if (transacaoEstornar != null)
                        return CriarEstorno(transacao, transacaoEstornar);
                    else                    
                        throw new Exception(string.Format("Não foi possível realizar o estorno do aporte, id: {0}", transacao.Id));                    
                }
                else
                    throw new Exception(string.Format("Não foi possível realizar o estorno da transferência, código: {0}", transacao.CodigoTransacao));
            }
            else
                throw new Exception(transacao.ValidationResult.Erros.Aggregate((i, j) => i + "," + j));
        }

        private string CriarEstorno(TransacaoModel transacao, TransacaoModel transacaoEstornar)
        {
            if (_transacaoRepo.TransacaoEstornada(transacaoEstornar.Id))
                throw new Exception(string.Format("Transação já foi estornada, código: {0}", transacao.CodigoTransacao));

            if(transacaoEstornar.ReferenciaId > 0)
                throw new Exception(string.Format("Transação de estorno não pode ser estornada, código: {0}", transacao.CodigoTransacao));

            if(transacao.ContaOrigemId != transacaoEstornar.ContaOrigemId || transacao.ContaDestinoId != transacaoEstornar.ContaDestinoId)
                throw new Exception(string.Format("Não foi possível realizar o estorno, dados não conferem, código: {0}", transacao.CodigoTransacao));

            transacaoEstornar.ReferenciaId = transacaoEstornar.Id;
            transacaoEstornar.Id = 0;
            return _transacaoRepo.Create(transacaoEstornar);
        }

        public IList<TransacaoModel> GetAll()
        {
            return _transacaoRepo.GetAll();
        }
    }
}
