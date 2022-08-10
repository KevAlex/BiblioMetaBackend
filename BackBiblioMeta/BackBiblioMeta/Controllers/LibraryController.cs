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

        /// <summary>
        /// Obtiene los libros para un determinado alias del usuario
        /// </summary>
        /// <param name="alias"> Alias del usuario usado en el registro</param>
        /// <returns></returns>
        [HttpGet(Name = "getUserBook")]
        public async Task<IEnumerable<ResponseLibroDto>> GetUserBook(string alias)
        {
            return await _mediator.Send(new UserBookQuery { Alias = alias });
        }

        /// <summary>
        /// Añade un libro a un usuario
        /// </summary>
        /// <param name="command">Ver estructura de OperationBookCommand</param>
        /// <returns></returns>
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
