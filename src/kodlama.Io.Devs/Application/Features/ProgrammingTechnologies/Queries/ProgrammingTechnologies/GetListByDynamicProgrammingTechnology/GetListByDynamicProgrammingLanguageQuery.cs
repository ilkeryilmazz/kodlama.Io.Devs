using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries.ProgrammingTechnologies.GetListByDynamicProgrammingTechnology
{
    public class GetListByDynamicProgrammingTechnologyQuery:IRequest<ProgrammingTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListByDynamicProgrammingTechnologyQueryHandler : IRequestHandler<GetListByDynamicProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public GetListByDynamicProgrammingTechnologyQueryHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListByDynamicProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListByDynamicAsync(request.Dynamic, include: c => c.Include(c => c.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                _programmingTechnologyBusinessRules.ProgrammingTechnologyListShouldExistWhenRequested(programmingTechnologies);

                ProgrammingTechnologyListModel programmingTechnologyListModel = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
                return programmingTechnologyListModel;
            } 
        }
    }
}
