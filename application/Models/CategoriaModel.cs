namespace myfinance_web_dotnet.Models
{
    public class CategoriaModel
    {
        public int? Id { get; set; }
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }
    }
}