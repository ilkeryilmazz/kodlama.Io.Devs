using Application.Features.UserGithubs.Dtos;
using Application.Features.UserGithubs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Commands.CreateUserGithub
{
    public class CreateUserGithubCommand:IRequest<CreatedUserGithubDto>
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }

        public class CreateUserGithubCommandHandler : IRequestHandler<CreateUserGithubCommand, CreatedUserGithubDto>
        {
            IMapper _mapper;
            IUserGithubRepository _userGithubRepository;
            UserGithubBusinessRules _userGithubBusinessRules;

            public CreateUserGithubCommandHandler(IMapper mapper, IUserGithubRepository userGithubRepository, UserGithubBusinessRules userGithubBusinessRules)
            {
                _mapper = mapper;
                _userGithubRepository = userGithubRepository;
                _userGithubBusinessRules = userGithubBusinessRules;
            }

            public async Task<CreatedUserGithubDto> Handle(CreateUserGithubCommand request, CancellationToken cancellationToken)
            {
                UserGithub userGithub = _mapper.Map<UserGithub>(request);
                await _userGithubBusinessRules.CheckIfProgrammingTechologyAlreadyExistsOnTable(request.GithubAddress);
                UserGithub addedGithub = await _userGithubRepository.AddAsync(userGithub);
                CreatedUserGithubDto createdUserGithubDto = _mapper.Map<CreatedUserGithubDto>(addedGithub);
                return createdUserGithubDto;
            }
        }
    }
}
