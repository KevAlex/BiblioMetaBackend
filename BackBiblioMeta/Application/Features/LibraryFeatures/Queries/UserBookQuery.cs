using Application.Common.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.LibraryFeatures.Queries
{
    public class UserBookQuery : IRequest<IEnumerable<Libro>>
    {
        public string Alias { get; set; }
        public class UserBookQueryHandler : IRequestHandler<UserBookQuery, IEnumerable<Libro>>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public UserBookQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<Libro>> Handle(UserBookQuery query, CancellationToken cancellationToken)
            {
                var userInList = _applicationDbContext.Usuarios.Where(x => x.Alias == query.Alias).FirstOrDefault();

                if (userInList == null)
                {
                    return null;
                }
                else
                {
                    int id = userInList.Id;
                    var ownBooks = _applicationDbContext.Libros.Where(c => c.UsuarioId == id).ToList();
                    //var ownBooks = _applicationDbContext.Libros.ToList();
                    Console.WriteLine("DD");
                    if (ownBooks.Any())
                    {
                        return ownBooks;
                    }
                    else
                    {
                        return null;
                    }

                    //return _mapper.Map<List<Libro>>(ownBooks);
                }



            }
        }
    }
}
