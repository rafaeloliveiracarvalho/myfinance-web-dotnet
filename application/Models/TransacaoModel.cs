using domain.Entities;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public required string Descricao { get; set; }
        public decimal Valor { get; set; }
        public required DateTime Data { get; set; }
        public required int CategoriaId { get; set; }
        public required virtual Categoria Categoria { get; set; }
    }
}