using Desafio_backend.Application.UseCase.V1.PersonOperation.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_backend.Application.UseCase.V1.PedidoOperation.Command.Create
{
    public class CreatePedidoValidation : AbstractValidator<CreatePedidoCommand>
    {

        public CreatePedidoValidation()
        {
            RuleFor(x => x.CodigoDeContratoInterno)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Numero Vacio");
            RuleFor(x => x.CuentaCorriente)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Numero Vacio")
                .Matches("[0-9]")
                .WithMessage("No contiene numeros");

                
        }
    }
}
