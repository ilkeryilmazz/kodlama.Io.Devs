using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Commands.UpdateUserGithub
{
    public class UpdateUserGithubCommandValidator : AbstractValidator<UpdateUserGithubCommand>
    {
        public UpdateUserGithubCommandValidator()
        {
            RuleFor(c => c.GithubAddress).NotEmpty();
      
        }
    }
}
