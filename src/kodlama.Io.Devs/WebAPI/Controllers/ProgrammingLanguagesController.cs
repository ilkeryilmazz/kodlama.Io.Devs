using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.ProgrammingLanguages.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.ProgrammingLanguages.GetListByDynamicProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.ProgrammingLanguages.GetListProgrammingLanguage;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand, CancellationToken cancellationToken)
        {
            var createdProgrammingLanguage = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", createdProgrammingLanguage);
        }
        [HttpPost("Delete/{Id}")]
     
        public async Task<ActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand, CancellationToken cancellationToken)
        {
            var deletedProgrammingLanguage = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deletedProgrammingLanguage);
        }
        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateProgammingLanguageCommand updateProgammingLanguageCommand, CancellationToken cancellationToken)
        {
            var updatedProgrammingLanguage = await Mediator.Send(updateProgammingLanguageCommand);
            return Ok(updatedProgrammingLanguage);
        }
        [HttpGet("Get/GetAll")]
        public async Task<ActionResult> GetAll([FromQuery] GetListProgrammingLanguageQuery getListProgrammingLanguageQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpGet("Get/GetById{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpPost("Get/GetByDynamic")]
        public async Task<ActionResult> GetByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic, CancellationToken cancellationToken)
        {
            GetListByDynamicProgrammingLanguageQuery getListByDynamicProgrammingLanguageQuery = new GetListByDynamicProgrammingLanguageQuery { Dynamic = dynamic, PageRequest = pageRequest };
            var result = await Mediator.Send(getListByDynamicProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
