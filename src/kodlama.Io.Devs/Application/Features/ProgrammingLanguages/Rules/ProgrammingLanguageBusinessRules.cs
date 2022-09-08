using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task CheckIfProgrammingLanguageAlreadyExistsOnTable(string name)
        {
            IPaginate<ProgrammingLanguage> data = _programmingLanguageRepository.GetListAsync(programmingLanguage=>programmingLanguage.Name==name).Result;
            if (data.Items.Any())
            {
                throw new BusinessException(BusinessRuleConstants.ProgrammingLanguageAlreadyExists);
            }
        }
        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException(BusinessRuleConstants.ProgrammingLanguageNotExists);
        }
        public void ProgrammingLanguageListShouldExistWhenRequested(IPaginate<ProgrammingLanguage> programmingLanguages)
        {
            if (programmingLanguages.Items == null) throw new BusinessException(BusinessRuleConstants.ProgrammingLanguageListNotExists);
        }
    }
}
