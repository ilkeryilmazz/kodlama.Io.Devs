
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

namespace Application.Features.Users.Queries
{
    public class GetUserByEmailQuery:IRequest<User>
    {
        public string Email { get; set; }

        public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery,User>
        {
            IUserRepository _userRepository;
            IMapper _mapper;

            public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            {
                User user =  _userRepository.Get(user => user.Email == request.Email);
           
                return user;
            }
        }
    }
}
