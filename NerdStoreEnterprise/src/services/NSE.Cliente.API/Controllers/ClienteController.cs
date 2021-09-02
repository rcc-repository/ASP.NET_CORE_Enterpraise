using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSE.Cliente.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Cliente.API.Controllers
{
    public class ClienteController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClienteController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("cliente")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), "Rodrigo", "rccc@rod.com", "30314299076"));

            return CustomResponse(resultado);
        }
    }
}