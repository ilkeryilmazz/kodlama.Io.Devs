using Application.Features.UserGithubs.Commands.CreateUserGithub;
using Application.Features.UserGithubs.Commands.DeleteUserGithub;
using Application.Features.UserGithubs.Commands.UpdateUserGithub;
using Application.Features.UserGithubs.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserGithub, CreateUserGithubCommand>().ReverseMap();
            CreateMap<UserGithub, CreatedUserGithubDto>().ReverseMap();

            CreateMap<UserGithub, DeleteUserGithubCommand>().ReverseMap();
            CreateMap<UserGithub, DeletedUserGithubDto>().ReverseMap();

            CreateMap<UserGithub, UpdateUserGithubCommand>().ReverseMap();
            CreateMap<UserGithub, UpdatedUserGithubDto>().ReverseMap();
        }
    }
}
