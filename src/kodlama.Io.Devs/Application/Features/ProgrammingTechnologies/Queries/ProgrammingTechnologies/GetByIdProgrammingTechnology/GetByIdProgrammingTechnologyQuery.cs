using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries.ProgrammingTechnologies.GetByIdProgrammingTechnology
{
    public class GetByIdProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgrammingTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingTechnologyQuery, ProgrammingTechnologyGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public GetByIdProgrammingTechnologyQueryHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<ProgrammingTechnologyGetByIdDto> Handle(GetByIdProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology programmingTechnology = await _programmingTechnologyRepository.GetAsync(programmingTechnology => programmingTechnology.Id == request.Id);
                _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingTechnology);
                ProgrammingTechnologyGetByIdDto programmingTechnologyGetByIdDto = _mapper.Map<ProgrammingTechnologyGetByIdDto>(programmingTechnology);
                return programmingTechnologyGetByIdDto;
            }
        }
    }
}
