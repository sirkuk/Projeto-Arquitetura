using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFK.Application.Interfaces.Cliente;
using DFK.Application.Interfaces.Conta;
using DFK.Application.Interfaces.Transacao;
using DFK.Application.ViewModel.Cliente;
using DFK.Application.ViewModel.Conta;
using DFK.Application.ViewModel.Transacao;
using Microsoft.AspNetCore.Mvc;

namespace DFK.Service.ContaAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContaController : Controller
    {
        private readonly IContaAppService _contaAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IContaClienteAppService _contaclienteAppService;
        private readonly ITransacaoAppService _transacaoAppService;

        public ContaController(IContaAppService contaAppService, 
            IClienteAppService clienteAppService, IContaClienteAppService contaclienteAppService, 
            ITransacaoAppService transacaoAppService)
        {
            _contaAppService     =  contaAppService;
            _clienteAppService   =  clienteAppService;
            _contaclienteAppService = contaclienteAppService;
            _transacaoAppService =  transacaoAppService;
        }

        [HttpPost("contatransacao/criar")]
        public IActionResult Create([FromBody]TransacaoViewModel transacao)
        {
            try
            {
                var codigoTransacao =_transacaoAppService.Create(transacao);

                return Ok(codigoTransacao);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("contatransacao/estornar")]
        public IActionResult Estornar([FromBody]TransacaoViewModel transacao)
        {
            try
            {
                var codigoTransacao = _transacaoAppService.Estornar(transacao);

                return Ok(codigoTransacao);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("contatransacao/historico")]
        public IActionResult GetAll()
        {
            try
            {
                var historico = _transacaoAppService.GetAll();

                return Ok(historico);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost("contacliente/criar")]
        public IActionResult Create([FromBody]ContaViewModel conta)
        {
            try
            {
                _contaclienteAppService.Create(conta);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("contacliente/consultar/{contaId}")]
        public IActionResult GetById([FromRoute]long contaId)
        {
            try
            {
                var conta = _contaAppService.GetById(contaId);

                return Ok(conta);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
