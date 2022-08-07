

using Application.Common.Interfaces;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.UserFeatures.Queries
{
    // Remember to return a DTO
    public class GetUserByAliasPasswordQuery : IRequest<ResponseUsuarioDto>
    {
        public string Alias { get; set; }
        public string Password { get; set; }
        public class GetUsuerByAliasPasswordQueryHandler : IRequestHandler<GetUserByAliasPasswordQuery, ResponseUsuarioDto>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public GetUsuerByAliasPasswordQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<ResponseUsuarioDto> Handle(GetUserByAliasPasswordQuery query, CancellationToken cancellationToken)
            {
                var usuario = _applicationDbContext.Usuarios.Where(x => x.Alias == query.Alias && x.Password == query.Password).FirstOrDefault();
                if (usuario == null) return null;
                //Remember to return a DTO
                return _mapper.Map<ResponseUsuarioDto>(usuario);
            }

        }
    }
}
