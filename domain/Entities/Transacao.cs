namespace domain.Entities;

public class Transacao
{
    public int? Id { get; set; }
    public required string Descricao { get; set; }
    public decimal Valor { get; set; }
    public required DateTime Data { get; set; }
    public required int CategoriaId { get; set; }
    public required virtual Categoria Categoria { get; set; }
}
