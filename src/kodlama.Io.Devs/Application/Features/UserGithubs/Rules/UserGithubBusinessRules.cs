using Application.Features.UserGithubs.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Rules
{
    public class UserGithubBusinessRules
    {
        IUserGithubRepository _userGithubRepository;
        public async Task CheckIfProgrammingTechologyAlreadyExistsOnTable(string githubAddress)
        {
            IPaginate<UserGithub> data = _userGithubRepository.GetListAsync(github=>github.GithubAddress == githubAddress).Result;
            if (data.Items.Any())
            {
                throw new BusinessException(BusinessRuleConstants.UserGithubAlreadyExists);
            }
        }
    }
}
