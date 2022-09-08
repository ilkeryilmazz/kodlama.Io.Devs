using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(programmingTechnology => programmingTechnology.Id).NotEmpty();
            
        }
    }
}
