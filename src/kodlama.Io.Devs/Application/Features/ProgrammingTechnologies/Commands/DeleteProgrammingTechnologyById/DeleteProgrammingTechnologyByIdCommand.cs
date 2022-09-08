using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyByIdCommand : IRequest<DeletedProgrammingTechnologyByIdDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyByIdCommand, DeletedProgrammingTechnologyByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

            public DeleteProgrammingTechnologyCommandHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
            }

            public async Task<DeletedProgrammingTechnologyByIdDto> Handle(DeleteProgrammingTechnologyByIdCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology mappedProgrammingTechology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology deletedProgrammingTechnology = await _programmingTechnologyRepository.DeleteAsync(mappedProgrammingTechology);

                DeletedProgrammingTechnologyByIdDto deletedProgrammingTechnologyDto = _mapper.Map<DeletedProgrammingTechnologyByIdDto>(deletedProgrammingTechnology);
                return deletedProgrammingTechnologyDto;
            }
        }
    }
}
