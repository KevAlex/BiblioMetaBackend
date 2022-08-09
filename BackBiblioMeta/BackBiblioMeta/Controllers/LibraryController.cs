using Application.Features.LibraryFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackBiblioMeta.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LibraryController : Controller
    {
        private readonly IMediator _mediator;

        public LibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "postBook")]
        public async Task<IActionResult> AddBookUser(OperationBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost(Name = "deleteBook")]
        public async Task<IActionResult> DeleteBookUser()
        {
            return Ok("");
        }

    }
}
