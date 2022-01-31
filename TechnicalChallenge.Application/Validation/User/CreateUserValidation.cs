using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.User;

namespace TechnicalChallenge.Application.Validation.User
{
    public class CreateUserValidation : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do usuario não pode estar vazio");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("O sobrenome do usuario não pode estar vazio");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O Email é necessario")
                     .EmailAddress().WithMessage("Um Email valido é necessario");

            RuleFor(x => x.Pass).NotEmpty().WithMessage("A senha não pode estar vazia");

        }
    }
}
