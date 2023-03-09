using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Desafio_backend.Domain.Common;
using Desafio_backend.Domain.Dtos;
using Desafio_backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_backend.Application.UseCase.V1.PedidoOperation.Queries.GetList
{
    public record struct GetPedido : IRequest<Response<PedidosDto>>
    {
        public string Id { get; set; }
    }

    public class GetPedidoHandler : IRequestHandler<GetPedido, Response<PedidosDto>>
    {
        private readonly IReadOnlyQuery _query;

        public GetPedidoHandler(IReadOnlyQuery query)
        {
            _query = query;
        }

        public async Task<Response<PedidosDto>> Handle(GetPedido request, CancellationToken cancellationToken)
        {
            var stringsql = $"select p.Id, p.CicloDelPedido, p.CodigoDeContratoInterno, p.cuando, p.CuentaCorriente, p.NumeroDePedido, ep.descripcion as EstadoDelPedido from pedidos p inner join EstadoDelPedido ep on p.EstadoDelPedido=ep.Id where p.Id='{request.Id}'";
            var pedidos = await _query.FirstOrDefaultQueryAsync<PedidosDto>(stringsql);
            var response = new Response<PedidosDto>
            {
                Content = pedidos,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            if (pedidos is null)
            {
                response.AddNotification("#3123", nameof(request.Id), string.Format(ErrorMessage.NOT_FOUND_RECORD, "Pedido", request.Id));
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                
            }
            return response;
        }
    }
}