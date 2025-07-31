namespace BibliotecaAPI.DTOs
{
    public class LivroDetalhesDTO : LivroDTO
    {
        public GeneroDTO Genero { get; set; }
        public AutorDTO Autor { get; set; }
    }
}
