using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
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

namespace Application.Features.Auths.Queries.LoginQuery
{
    public class LoginQuery : IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginDto>
        {

            IUserRepository _userRepository;
            IMapper _mapper;
            AuthBusinessRules _authBusinessRules;


            public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;

            }

            public async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {

                User user =  _userRepository.Get(user => user.Email == request.UserForLoginDto.Email);
                _authBusinessRules.IsUserExists(user);
                _authBusinessRules.VerifyPassword(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
                LoginDto loginDto = _mapper.Map<LoginDto>(user);
                return loginDto;
            }
        }
    }
}

