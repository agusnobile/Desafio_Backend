using Desafio_backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_backend.Domain.Entities
{
    public class Pedidos
    {
        public Guid Id { get; set; } 
        public int? NumerodePedido { get; set; }
        public string CicloDelPedido { get; set; }
        public Int64 CodigoDeContratoInterno { get; set; }
        public string CuentaCorriente { get; set; }
        public DateTime Cuando { get; set; }
        public int? EstadoDelPedido { get; set; }

    }
}
