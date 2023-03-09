using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Andreani.Scheme.Onboarding;
using Desafio_backend.Application.UseCase.V1.PedidoOperation.Command.Create;
using Desafio_backend.Domain.Entities;
using FluentValidation.Internal;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_backend.Application.UseCase.V1.PedidoOperation.Command.Update
{
    public class UpdatePedidoCommand : IRequest<bool>
    {
        public Pedido pedidoUpdate { get; set; }
    }

    public class UpdatePedidoCommandHandler : IRequestHandler<UpdatePedidoCommand, bool>
    {
        private readonly ITransactionalRepository _repository;
        private readonly IReadOnlyQuery _query;
        private readonly ILogger<CreatePedidoCommandHandler> _logger;

        public UpdatePedidoCommandHandler(ITransactionalRepository repository, ILogger<CreatePedidoCommandHandler> logger, IReadOnlyQuery query)
        {
            _repository = repository;
            _logger = logger;
            _query = query;
        }

        public async Task<bool> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            var ped = await _query.GetByIdAsync<Pedidos>(request.pedidoUpdate.id);

            if (ped is null)
            {
                _logger.LogInformation("No existe registro con id {0}", request.pedidoUpdate.id);
                return false;
            }

            ped.NumerodePedido = request.pedidoUpdate.numeroDePedido;
            
            _repository.Update(ped);

            await _repository.SaveChangeAsync();

            _logger.LogDebug("el pedido se agrego correctamente " + request.pedidoUpdate.numeroDePedido);

            return true;
        }
    }
}
