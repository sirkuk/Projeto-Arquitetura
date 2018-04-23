using DFK.Domain.Entities.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Interfaces.Repositories.Transacao
{
    public interface ITransacaoRepository
    {
        string Create(TransacaoModel transacao);
        TransacaoModel GetById(long transacaoId);
        TransacaoModel GetByCodTransacao(string codigoTransacao);
        bool TransacaoEstornada(long referenciaId);
        IList<TransacaoModel> GetAll();
    }
}
