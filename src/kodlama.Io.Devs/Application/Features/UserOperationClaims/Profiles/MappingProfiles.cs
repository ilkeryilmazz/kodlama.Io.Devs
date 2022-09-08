using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClamListModel>().ForMember(c=>c.OperationClaim,opt=>opt.MapFrom(c=>c.Items)).ReverseMap();
            CreateMap<UserOperationClaim, OperationClaim>().ForMember(C => C.Name, opt => opt.MapFrom(c => c.OperationClaim.Name)).ReverseMap();
            
        }
    }
}
