using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_backend.Domain.Exceptions
{
    public class PedidoNoEncontrado: Exception
        
    {
        public PedidoNoEncontrado(string npedido, Exception ex)
        : base($"Numero de pedido \"{npedido}\" es invalido.", ex)
        {
        }
    }
}
