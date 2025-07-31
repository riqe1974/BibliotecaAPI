using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Autor
    {
        public Autor()
        {
            Livros = new HashSet<Livro>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        public string Biografia { get; set; } = null!;

        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
