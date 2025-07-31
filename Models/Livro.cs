using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;
        public string Sinopse { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public required Genero Genero { get; set; }

        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public required Autor Autor { get; set; }
    }
}
