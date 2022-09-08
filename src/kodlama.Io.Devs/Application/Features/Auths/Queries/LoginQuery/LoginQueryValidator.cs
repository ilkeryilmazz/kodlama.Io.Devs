using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Queries.LoginQuery
{
    public class LoginQueryValidator:AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(u => u.UserForLoginDto.Email).NotEmpty();
            RuleFor(u => u.UserForLoginDto.Email).EmailAddress();
            RuleFor(u => u.UserForLoginDto.Password).NotEmpty();
        }
    }
}
