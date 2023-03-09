using Desafio_backend.Application.UseCase.V1.PersonOperation.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_backend.Application.UseCase.V1.PedidoOperation.Queries.GetList
{
    public class PedidoValidadion : AbstractValidator<GetPedido>
    {
        public PedidoValidadion()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Id no puede estar vacio")
                .Length(36)
                .WithMessage("Largo de Id invalido")
                .Matches("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}")
                .WithMessage("Expersion sin formato de GuId");
        }
    }
}
