using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.EventUser;

namespace TechnicalChallenge.Application.Validation.EventUser
{
    public class CreateEventUserValidation : AbstractValidator<CreateEventUserViewModel>
    {
        public CreateEventUserValidation()
        {
            RuleFor(x => x.EventId).NotEmpty().WithMessage("O id do envento não pode estar vazio");

            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do usuario não pode estar vazio");

            RuleFor(x => x.Value).GreaterThanOrEqualTo(0).WithMessage("O valor atribuido ao usuario não pode ser menor que zero");
        }
    }
}
