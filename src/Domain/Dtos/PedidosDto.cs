using Desafio_backend.Domain.Entities;
using System;

namespace Desafio_backend.Domain.Dtos
{
    public record struct PedidosDto(Guid Id, int? NumeroDePedido, string CicloDelPedido, long? CodigoDeContratoInterno, EstadoDelPedido EstadoDelPedido, string CuentaCorriente, string Cuando) { }
}
