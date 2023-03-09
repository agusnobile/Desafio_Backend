using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.WebHost.Controllers;
using Desafio_backend.Application.UseCase.V1.PedidoOperation.Command.Create;
using Desafio_backend.Application.UseCase.V1.PedidoOperation.Queries.GetList;
using Desafio_backend.Application.UseCase.V1.PersonOperation.Commands.Create;
using Desafio_backend.Application.UseCase.V1.PersonOperation.Queries.GetList;
using Desafio_backend.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio_backend.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<PedidosDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListPedidos()));

        [HttpPost]
        [ProducesResponseType(typeof(CreatePedidoResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreatePedidoCommand body) => Result(await Mediator.Send(body));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => this.Result(await Mediator.Send(new GetPedido() { Id = id }));
    }

}
