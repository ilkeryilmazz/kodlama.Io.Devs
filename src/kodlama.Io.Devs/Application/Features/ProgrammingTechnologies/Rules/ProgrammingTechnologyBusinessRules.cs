using Application.Features.ProgrammingTechnologies.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private protected IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task CheckIfProgrammingTechologyAlreadyExistsOnTable(string name)
        {
            IPaginate<ProgrammingTechnology> data = _programmingTechnologyRepository.GetListAsync(programmingTechnology => programmingTechnology.Name == name).Result;
            if (data.Items.Any())
            {
                throw new BusinessException(BusinessRuleConstants.ProgrammingTechnologyAlreadyExists);
            }
        }

        public void ProgrammingTechnologyShouldExistWhenRequested(ProgrammingTechnology programmingTechnology)
        {
            if (programmingTechnology == null) throw new BusinessException(BusinessRuleConstants.ProgrammingTechnologyNotExists);
        }
        public void ProgrammingTechnologyListShouldExistWhenRequested(IPaginate<ProgrammingTechnology> programmingTechnologies)
        {
            if (programmingTechnologies.Items == null) throw new BusinessException(BusinessRuleConstants.ProgrammingTechnologyListNotExists);
        }
    }
}
