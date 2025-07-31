using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } 
        public ICollection<Livro> Livros { get; set; }
    }
}
