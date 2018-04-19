using HubFintech.Domain.Entities.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Interfaces.Services.Transacao
{
    public  interface ITransacaoService
    {
        string Create(TransacaoModel transacao);
        string Estornar(TransacaoModel transacao);
        IList<TransacaoModel> GetAll();
    }
}
