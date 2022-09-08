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

namespace Application.Features.UserGithubs.Commands.UpdateUserGithub
{
    public class UpdateUserGithubCommand : IRequest<UpdatedUserGithubDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
}

        public class UpdateUserGithubCommandHandler : IRequestHandler<UpdateUserGithubCommand, UpdatedUserGithubDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserGithubRepository _UserGithubRepository;
            private readonly UserGithubBusinessRules _UserGithubBusinessRules;

            public UpdateUserGithubCommandHandler(IMapper mapper, IUserGithubRepository UserGithubRepository, UserGithubBusinessRules UserGithubBusinessRules)
            {
                _mapper = mapper;
                _UserGithubRepository = UserGithubRepository;
                _UserGithubBusinessRules = UserGithubBusinessRules;
            }

            public async Task<UpdatedUserGithubDto> Handle(UpdateUserGithubCommand request, CancellationToken cancellationToken)
            {
               
                UserGithub mappedUserGithub = _mapper.Map<UserGithub>(request);



                UserGithub updatedUserGithub = await _UserGithubRepository.UpdateAsync(mappedUserGithub);

                UpdatedUserGithubDto updatedUserGithubDto = _mapper.Map<UpdatedUserGithubDto>(updatedUserGithub);
                return updatedUserGithubDto;
            }
        }

    }

