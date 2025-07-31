using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Livro
    {
        public Livro()
        {
            Titulo = string.Empty;
            Sinopse = string.Empty;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        public string Sinopse { get; set; }

        public int AnoPublicacao { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }

        public virtual Genero Genero { get; set; } = null!;

        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        public virtual Autor Autor { get; set; } = null!;
    }
}
