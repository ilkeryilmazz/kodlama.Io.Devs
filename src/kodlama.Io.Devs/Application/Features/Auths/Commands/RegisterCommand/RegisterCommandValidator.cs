using Core.Security.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RegisterCommand
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u=>u.UserForRegister.Email).NotEmpty();
            RuleFor(u => u.UserForRegister.Email).EmailAddress();
            RuleFor(u => u.UserForRegister.Password).NotEmpty();
            RuleFor(u => u.UserForRegister.FirstName).NotEmpty();
            RuleFor(u => u.UserForRegister.LastName).NotEmpty();
        }
    }
}
