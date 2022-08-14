using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.UserFeatures.Commands
{
    public class AddUsuarioCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birth { get; set; }

        public class AddUsuarioCommandHandler : IRequestHandler<AddUsuarioCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public AddUsuarioCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(AddUsuarioCommand command, CancellationToken cancellationToken)
            {
                var isInList = _applicationDbContext.Usuarios.Where(x => x.Alias == command.Alias && x.Password == command.Password).FirstOrDefault();

                if (isInList is null)
                {
                    var usuario = new Usuario();
                    usuario.FirstName = command.FirstName;
                    usuario.LastName = command.LastName;
                    usuario.Email = command.Email;
                    usuario.Password = command.Password;
                    usuario.Birth = command.Birth;
                    usuario.Alias = command.Alias;


                    _applicationDbContext.Usuarios.Add(usuario);
                    await _applicationDbContext.SaveChangesAsync();
                    return usuario.Id;

                }
                else
                {
                    return 101;
                }

            }
        }
    }
}
