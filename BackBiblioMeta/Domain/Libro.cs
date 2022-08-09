namespace Domain
{
    public class Libro
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public string Year { get; set; }

        public bool Status { get; set; }

        public string OperationType { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
