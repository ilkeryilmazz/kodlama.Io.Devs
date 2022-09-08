using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries.ProgrammingTechnologies.GetListProgrammingTechnology
{
    public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public GetListProgrammingTechnologyQueryHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies= await _programmingTechnologyRepository.GetListAsync(include:c=>c.Include(c=>c.ProgrammingLanguage),index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                _programmingTechnologyBusinessRules.ProgrammingTechnologyListShouldExistWhenRequested(programmingTechnologies);
                ProgrammingTechnologyListModel mappedProgrammingTechnologyListModel = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
                return mappedProgrammingTechnologyListModel;

            }
        }
    }
}
