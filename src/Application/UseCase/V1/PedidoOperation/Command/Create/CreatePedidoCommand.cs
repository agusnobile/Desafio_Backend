using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Andreani.Scheme.Onboarding;
using Desafio_backend.Application.UseCase.V1.PersonOperation.Commands.Create;
using Desafio_backend.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_backend.Application.UseCase.V1.PedidoOperation.Command.Create
{
    public class CreatePedidoCommand : IRequest<Response<CreatePedidoResponse>>
    {
        public long CodigoDeContratoInterno { get; set; }
        public string CuentaCorriente { get; set; }
    }

    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, Response<CreatePedidoResponse>>
    {
        private readonly ITransactionalRepository _repository;
        private readonly ILogger<CreatePedidoCommandHandler> _logger;
        private Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher;

        public CreatePedidoCommandHandler(ITransactionalRepository repository, ILogger<CreatePedidoCommandHandler> logger, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher)
        {
            _repository = repository;
            _logger = logger;
            _publisher = publisher;
        }
        public async Task<Response<CreatePedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Id = Guid.NewGuid();
                Pedidos entity = new Pedidos
                {
                    Id = Id,
                    NumerodePedido = null,
                    CicloDelPedido = Id.ToString(),
                    CodigoDeContratoInterno = request.CodigoDeContratoInterno,
                    CuentaCorriente = request.CuentaCorriente,
                    Cuando = DateTime.Now,
                    EstadoDelPedido = 1,
                };
                _repository.Insert(entity);
                await _repository.SaveChangeAsync();
                _logger.LogDebug("el pedido se agrego correctamente");
              

                await _publisher.To<Pedido>(new Pedido()
                {
                    id = entity.Id.ToString(),
                    numeroDePedido = 123,
                    cicloDelPedido = Id.ToString(),
                    codigoDeContratoInterno = request.CodigoDeContratoInterno,
                    estadoDelPedido = "1",
                    cuentaCorriente = long.Parse(request.CuentaCorriente),
                    cuando = DateTime.Now.ToString(),


                },Id.ToString());

                return new Response<CreatePedidoResponse>
                {
                    Content = new CreatePedidoResponse
                    {
                        Message = "Success",
                        Id = entity.Id.ToString()
                    },
                    StatusCode = System.Net.HttpStatusCode.Created
                };

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
