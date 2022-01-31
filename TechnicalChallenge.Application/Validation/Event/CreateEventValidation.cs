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
            RuleFor(x => x.Date).NotEmpty().WithMessage("O nome do usuario não pode estar vazio");

            RuleFor(x => x.Description).NotEmpty().WithMessage("O sobrenome do usuario não pode estar vazio");

        }
    }
}
