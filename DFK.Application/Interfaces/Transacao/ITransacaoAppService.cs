using DFK.Application.ViewModel.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.Interfaces.Transacao
{
    public interface ITransacaoAppService
    {
        string Create(TransacaoViewModel transacao);
        string Estornar(TransacaoViewModel transacao);
        IList<TransacaoViewModel> GetAll();
    }
}
