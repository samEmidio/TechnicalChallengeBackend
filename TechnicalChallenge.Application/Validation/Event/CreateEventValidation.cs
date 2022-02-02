using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.Event;

namespace TechnicalChallenge.Application.Validation.Event
{
    public class CreateEventValidation : AbstractValidator<CreateEventViewModel>
    {
        public CreateEventValidation()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("A data não pode estar vazia");

            RuleFor(x => x.Description).NotEmpty().WithMessage("O nome do não pode estar vazio");

        }
    }
}
