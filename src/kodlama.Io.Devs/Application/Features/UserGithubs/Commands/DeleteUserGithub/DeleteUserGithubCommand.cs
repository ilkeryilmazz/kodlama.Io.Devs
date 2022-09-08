using Application.Features.UserGithubs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Commands.DeleteUserGithub
{
    public class DeleteUserGithubCommand : IRequest<DeletedUserGithubDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteUserGithubCommand, DeletedUserGithubDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserGithubRepository _userGithubRepository;
            
            public DeleteProgrammingTechnologyCommandHandler(IMapper mapper, IUserGithubRepository userGithubRepository)
            {
                _mapper = mapper;
                _userGithubRepository = userGithubRepository;
            }

            public async Task<DeletedUserGithubDto> Handle(DeleteUserGithubCommand request, CancellationToken cancellationToken)
            {
                UserGithub  mappedGithub = _mapper.Map<UserGithub>(request);
                UserGithub deletedGithub = await _userGithubRepository.DeleteAsync(mappedGithub);

                DeletedUserGithubDto deletedUserGithubDto = _mapper.Map<DeletedUserGithubDto>(deletedGithub);
                return deletedUserGithubDto;
            }
        }
    }
}
