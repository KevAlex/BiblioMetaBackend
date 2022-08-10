using Application.Features.LibraryFeatures.Commands;
using Application.Features.LibraryFeatures.Queries;
using Application.ViewModels;
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

        [HttpGet(Name = "getUserBook")]
        // It should return a UsuarioDTO object list
        public async Task<IEnumerable<ResponseLibroDto>> GetUserBook(string alias)
        {
            return await _mediator.Send(new UserBookQuery { Alias = alias });
        }

        [HttpPost(Name = "postBook")]
        public async Task<IActionResult> AddBookUser(OperationBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[HttpPost(Name = "deleteBook")]
        //public async Task<IActionResult> DeleteBookUser()
        //{
        //    return Ok("");
        //}

    }
}
