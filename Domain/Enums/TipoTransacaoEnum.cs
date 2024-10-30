using System.ComponentModel.DataAnnotations;

namespace PortfolioAcoes.Domain.Enums;

public class TipoTransacaoEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descricao { get; set; } = null!;

    public TipoTransacaoEnum Tipo { get; set; }
}
public enum TipoTransacaoEnum
{
    Compra = 1,
    Venda
}