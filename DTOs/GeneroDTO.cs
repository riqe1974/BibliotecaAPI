namespace BibliotecaAPI.DTOs
{
    public class GeneroDTO(int Id, string Nome, string Descricao)
    {
        public int Id { get; set; } = Id;
        public string Nome { get; set; } = Nome;
        public string Descricao { get; set;} = Descricao;
    }
}
