

using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.UserFeatures.Queries
{
    // Remember to return a DTO
    public class GetUsuerByAliasPasswordQuery : IRequest<Usuario>
    {
        public string Alias { get; set; }
        public string Password { get; set; }
        public class GetUsuerByAliasPasswordQueryHandler : IRequestHandler<GetUsuerByAliasPasswordQuery, Usuario>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            //private readonly IMapper _mapper;

            public GetUsuerByAliasPasswordQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Usuario> Handle(GetUsuerByAliasPasswordQuery query, CancellationToken cancellationToken)
            {
                var usuario = _applicationDbContext.Usuarios.Where(x => x.Alias == query.Alias && x.Password == query.Password).FirstOrDefault();
                if (usuario == null) return null;
                //Remember to return a DTO
                return usuario;
            }

        }
    }
}
