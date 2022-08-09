using Domain;

namespace Application.ViewModels
{
    public class ResponseUsuarioDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Alias { get; set; }

        public string Email { get; set; }

        public ICollection<Libro> Libros { get; set; }

    }
}
