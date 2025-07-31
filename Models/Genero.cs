using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public ICollection<Livro> Livros { get; set; }
    }
}
