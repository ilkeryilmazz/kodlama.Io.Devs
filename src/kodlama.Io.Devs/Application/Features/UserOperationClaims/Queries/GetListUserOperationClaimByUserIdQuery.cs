using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries
{
    public class GetListUserOperationClaimByUserIdQuery:IRequest<UserOperationClamListModel>
    {
        public int UserId { get; set; }

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimByUserIdQuery, UserOperationClamListModel>
        {
            IUserOperationClaimRepository _userOperationClaimRepository;
            IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClamListModel> Handle(GetListUserOperationClaimByUserIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims =   _userOperationClaimRepository.GetList(include:m=>m.Include(c=>c.User).Include(c=>c.OperationClaim));
                

                UserOperationClamListModel userOperationClamListModel = _mapper.Map<UserOperationClamListModel>(userOperationClaims);
                return userOperationClamListModel;
            }
        }
    }
}
