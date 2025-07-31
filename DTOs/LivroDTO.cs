namespace BibliotecaAPI.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Sinopse { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int GeneroId { get; set; }
        public int AutorId { get; set; }
    }
}
