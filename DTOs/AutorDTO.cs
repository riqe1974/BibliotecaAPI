namespace BibliotecaAPI.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } 
    }

}
