using Desafio_backend.Domain.Entities;
using System;

namespace Desafio_backend.Domain.Dtos
{
    public class PedidosDto {
        public Guid Id { get; set; }
        public int? NumeroDePedido { get; set; }
        public string? CicloDelPedido { get; set; }
        public Int64? CodigoDeContratoInterno { get; set; } 
        public string? CuentaCorriente { get; set; }
        public DateTime? Cuando { get; set; }
        public string? EstadoDelPedido { get; set; }
        }
}
