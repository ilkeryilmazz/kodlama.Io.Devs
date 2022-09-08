using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;

using Application.Features.Users.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Users.Queries.GetUserByEmailQuery;

namespace Application.Features.Auths.Commands.RegisterCommand
{
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegister { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private protected IMapper _mapper;
            private protected AuthBusinessRules _authBusinessRules;
            private protected GetUserByEmailQueryHandler _getUserByEmailQueryHandler;

            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules, GetUserByEmailQueryHandler getUserByEmailQueryHandler)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
                _getUserByEmailQueryHandler = getUserByEmailQueryHandler;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegister.Password,out passwordHash,out passwordSalt);
                
                
                User user = new User {Email = request.UserForRegister.Email, FirstName = request.UserForRegister.FirstName, LastName = request.UserForRegister.LastName, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Status = true };
                User userToCheck = await _getUserByEmailQueryHandler.Handle(new GetUserByEmailQuery() { Email = request.UserForRegister.Email }, cancellationToken);
                _authBusinessRules.IsUserAlreadyRegistrated(userToCheck);
                User registeredUser= _userRepository.Add(user);
                
                _authBusinessRules.RegisteredUserCanNotBeNull(registeredUser);
                
                RegisteredDto registeredDto = _mapper.Map<RegisteredDto>(registeredUser);
           
                return registeredDto;
            }
        }

    }
}
