using Application.Common.Interfaces;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.LibraryFeatures.Queries
{
    public class UserBookQuery : IRequest<IEnumerable<ResponseLibroDto>>
    {
        public string Alias { get; set; }
        public class UserBookQueryHandler : IRequestHandler<UserBookQuery, IEnumerable<ResponseLibroDto>>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public UserBookQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ResponseLibroDto>> Handle(UserBookQuery query, CancellationToken cancellationToken)
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
                        return _mapper.Map<List<ResponseLibroDto>>(ownBooks);
                        //return ownBooks;
                    }
                    else
                    {
                        return null;
                    }


                }



            }
        }
    }
}
