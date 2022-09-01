using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.ProgrammingLanguages.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.ProgrammingLanguages.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand, CancellationToken cancellationToken)
        {
            var createdProgrammingLanguage = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", createdProgrammingLanguage);
        }
        [HttpPost("delete/{Id}")]
     
        public async Task<ActionResult> Add([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand, CancellationToken cancellationToken)
        {
            var deletedProgrammingLanguage = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deletedProgrammingLanguage);
        }
        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdateProgammingLanguageCommand updateProgammingLanguageCommand, CancellationToken cancellationToken)
        {
            var updatedProgrammingLanguage = await Mediator.Send(updateProgammingLanguageCommand);
            return Ok(updatedProgrammingLanguage);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll([FromQuery] GetListProgrammingLanguageQuery getListProgrammingLanguageQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpGet("getbyid/{Id}")]
        public async Task<ActionResult> GetAll([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
