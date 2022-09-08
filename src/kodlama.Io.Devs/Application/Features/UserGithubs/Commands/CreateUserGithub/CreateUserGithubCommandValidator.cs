using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Commands.CreateUserGithub
{
    public class CreateUserGithubCommandValidator:AbstractValidator<CreateUserGithubCommand>
    {
        public CreateUserGithubCommandValidator()
        {
            RuleFor(c => c.GithubAddress).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
