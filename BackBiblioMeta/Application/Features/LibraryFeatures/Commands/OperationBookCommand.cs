
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.LibraryFeatures.Commands
{
    public class OperationBookCommand : IRequest<int>
    {
        public string Alias { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Year { get; set; }

        public bool Status { get; set; }

        public string OperationType { get; set; }


        public class OperationBookCommandHandler : IRequestHandler<OperationBookCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public OperationBookCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            /// <summary>
            /// Se añadira el libro primero a la BD (Van a haber libros repetidos, con diferente ID)
            /// Luego se añadira este libro con su respectivo ID al usuario
            /// </summary>
            public async Task<int> Handle(OperationBookCommand command, CancellationToken cancellationToken)
            {

                var isInList = _applicationDbContext.Usuarios.Where(x => x.Alias == command.Alias).FirstOrDefault();

                if (isInList != null)
                {

                    var libro = new Libro();
                    libro.UsuarioId = isInList.Id;
                    libro.Title = command.Title;
                    libro.Author = command.Author;
                    libro.Year = command.Year;
                    libro.Status = command.Status;
                    libro.OperationType = command.OperationType;

                    _applicationDbContext.Libros.Add(libro);
                    _applicationDbContext.SaveChangesAsync().Wait();

                    try
                    {
                        isInList.BookList.Add(libro);
                        await _applicationDbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("***** " + ex.ToString());
                    }

                    return isInList.Id;
                }
                else
                {
                    return 0;
                }

            }
        }

    }
}
