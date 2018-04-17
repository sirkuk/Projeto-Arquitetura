using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HubFintech.Application.Interfaces.Cliente;
using HubFintech.Application.Interfaces.Conta;
using HubFintech.Application.Interfaces.Transacao;
using Microsoft.AspNetCore.Mvc;

namespace HubFintech.Service.ContaAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContaController : Controller
    {
        private readonly IContaAppService _contaAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly ITransacaoAppService _transacaoAppService;

        public ContaController(IContaAppService contaAppService, 
            IClienteAppService clienteAppService, ITransacaoAppService transacaoAppService)
        {
            _contaAppService     =  contaAppService;
            _clienteAppService   =  clienteAppService;
            _transacaoAppService =  transacaoAppService;
        }

        [HttpGet("cliente/{cliente}")]
        public IActionResult GetById([FromRoute]long cliente)
        {
            try
            {
                var retorno = _clienteAppService.GetById(cliente);

                if (retorno != null)
                    return Ok(retorno);
                else
                    return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
