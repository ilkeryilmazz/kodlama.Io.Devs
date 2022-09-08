using Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;

using Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Queries.ProgrammingTechnologies.GetByIdProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Queries.ProgrammingTechnologies.GetListByDynamicProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Queries.ProgrammingTechnologies.GetListProgrammingTechnology;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController : BaseController
    {
          [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand, CancellationToken cancellationToken)
        {
            var createdProgrammingLanguage = await Mediator.Send(createProgrammingTechnologyCommand);
            return Created("", createdProgrammingLanguage);
        }
        [HttpPost("Delete/{Id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteProgrammingTechnologyByIdCommand deleteProgrammingTechnologyByIdCommand, CancellationToken cancellationToken)
        {
            var deletedProgrammingLanguage = await Mediator.Send(deleteProgrammingTechnologyByIdCommand);
            return Ok(deletedProgrammingLanguage);
        }
      
        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand, CancellationToken cancellationToken)
        {
            var updatedProgrammingLanguage = await Mediator.Send(updateProgrammingTechnologyCommand);
            return Ok(updatedProgrammingLanguage);
        }
        [HttpGet("Get/GetAll")]
        public async Task<ActionResult> GetAll([FromQuery] GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getListProgrammingTechnologyQuery);
            return Ok(result);
        }
        [HttpGet("Get/GetById{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdProgrammingTechnologyQuery getByIdProgrammingTechnologyQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getByIdProgrammingTechnologyQuery);
            return Ok(result);
        }
        [HttpPost("Get/GetByDynamic")]
        public async Task<ActionResult> GetByDynamic([FromQuery] PageRequest pageRequest ,[FromBody] Dynamic dynamic, CancellationToken cancellationToken)
        {
            GetListByDynamicProgrammingTechnologyQuery getListByDynamicProgrammingTechnologyQuery = new GetListByDynamicProgrammingTechnologyQuery { Dynamic=dynamic,PageRequest=pageRequest};
            var result = await Mediator.Send(getListByDynamicProgrammingTechnologyQuery);
            return Ok(result);
        }
    }
}
