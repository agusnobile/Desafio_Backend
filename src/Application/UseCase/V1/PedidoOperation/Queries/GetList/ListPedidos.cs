using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Desafio_backend.Domain.Dtos;
using Desafio_backend.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_backend.Application.UseCase.V1.PedidoOperation.Queries.GetList
{
    
    public record struct ListPedidos : IRequest<Response<List<PedidosDto>>>
    {
    }

    public class ListPedidosHandler : IRequestHandler<ListPedidos, Response<List<PedidosDto>>>
    {
        private readonly IReadOnlyQuery _query;

        public ListPedidosHandler(IReadOnlyQuery query)
        {
            _query = query;
        }

        public async Task<Response<List<PedidosDto>>> Handle(ListPedidos request, CancellationToken cancellationToken)
        {
            var pedidos = await _query.ExecuteQueryAsync<PedidosDto>("select p.Id, p.CicloDelPedido, p.CodigoDeContratoInterno, p.cuando, p.CuentaCorriente, p.NumeroDePedido, ep.descripcion as EstadoDelPedido from pedidos p inner join EstadoDelPedido ep on p.EstadoDelPedido=ep.Id");


            return new Response<List<PedidosDto>>
            {
                Content = pedidos.ToList(),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
