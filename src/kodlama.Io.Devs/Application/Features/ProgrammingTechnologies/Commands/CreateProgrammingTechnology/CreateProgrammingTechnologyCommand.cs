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

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand:IRequest<CreatedProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDto>
        {
            private protected IMapper _mapper;
            private protected IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private protected ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public CreateProgrammingTechnologyCommandHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);


                ProgrammingTechnology createdLanguage = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);
                CreatedProgrammingTechnologyDto createdProgrammingTechnologyDto = _mapper.Map<CreatedProgrammingTechnologyDto>(createdLanguage);
                return createdProgrammingTechnologyDto;
            }
        }
    }
}
