using Andreani.ARQ.AMQStreams.Interface;
using System.Threading.Tasks;
using System;
using Andreani.Scheme.Onboarding;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using MediatR;
using static Slapper.AutoMapper;
using System.Security.Policy;
using System.Drawing.Text;
using Desafio_backend.Application.UseCase.V1.PedidoOperation.Command.Update;

namespace Desafio_backend.Infrastructure.Services
{
    public class Subscriber : ISubscriber
    {
        private readonly ISender _mediator;
        public Subscriber(ISender mediator)
        {
            _mediator = mediator; 
        }
        public async Task ReciveCustomEvent(Pedido @event)
        {
            await _mediator.Send(new UpdatePedidoCommand()
            {
                pedidoUpdate = @event
            });

        }

    }
}
