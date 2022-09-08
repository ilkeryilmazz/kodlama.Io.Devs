using Application.Features.Auths.Commands.RegisterCommand;
using Application.Features.Auths.Dtos;

using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisteredDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
        }
    }
}
