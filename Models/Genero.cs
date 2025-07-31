using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    // Modelo corrigido (exemplo para Genero.cs)
    public class Genero
    {
        // Construtor inicializando as coleções
        public Genero()
        {
            Livros = new HashSet<Livro>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!; // Null-forgiving operator

        public string? Descricao { get; set; } // Nullable

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
