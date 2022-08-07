using Application.Common.Interfaces;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.UserFeatures.Queries
{
    public class GetUserListQuery : IRequest<IEnumerable<ResponseUsuarioDto>>
    {
        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<ResponseUsuarioDto>>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }
            public async Task<IEnumerable<ResponseUsuarioDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {

                var usuariosList = _applicationDbContext.Usuarios.ToList();
                if (usuariosList == null) return null;

                return _mapper.Map<List<ResponseUsuarioDto>>(usuariosList);
            }
        }
    }
}
