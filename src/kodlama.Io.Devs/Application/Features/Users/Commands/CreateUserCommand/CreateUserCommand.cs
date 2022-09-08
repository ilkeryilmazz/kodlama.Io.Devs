using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand:IRequest<CreatedUserDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
        {
            private protected IUserRepository _userRepository;
            private protected IMapper _mapper;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);
                User createdUser = await _userRepository.AddAsync(user);
     
                CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);
                return createdUserDto;

            }
        }
    }
}
