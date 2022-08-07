using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.UserFeatures.Queries
{
    public class GetUserListQuery : IRequest<IEnumerable<Usuario>>
    {
        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<Usuario>>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            //private readonly IMapper _mapper;

            public GetUserListQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }
            public async Task<IEnumerable<Usuario>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {

                var usuarios = _applicationDbContext.Usuarios.ToList();
                if (usuarios == null) return null;

                return usuarios;
            }
        }
    }
}
