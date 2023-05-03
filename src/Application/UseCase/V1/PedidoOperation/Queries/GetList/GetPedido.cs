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
            var result = await _query.GetByIdAsync<Pedidos>(nameof(request.Id), request.Id);



            var sqlString = $"select * from dbo.EstadoDelpedido where id = '{result.EstadoDelPedido}'";
            var resultadoEstadoDelPedido = await _query.FirstOrDefaultQueryAsync<EstadoDelPedido>(sqlString);




            PedidosDto pedidodto = new PedidosDto()
            {



                Id = result.Id,
                NumeroDePedido = result.NumerodePedido,
                CicloDelPedido = result.CicloDelPedido,
                CodigoDeContratoInterno = result.CodigoDeContratoInterno,
                EstadoDelPedido = new EstadoDelPedido()
                {
                    Id = resultadoEstadoDelPedido is null ? 1 : resultadoEstadoDelPedido.Id,
                    Descripcion = resultadoEstadoDelPedido is null ? "Vacio" : resultadoEstadoDelPedido.Descripcion
                },
                CuentaCorriente = result.CuentaCorriente,
                Cuando = result.Cuando.ToString("MM/dd/yyyy")


            };
            return new Response<PedidosDto>
            {
                Content = pedidodto,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}