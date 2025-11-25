using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuebaPizzaria.API.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(3000)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    [Range(0, int.MaxValue)]
    public int Qtde { get; set; } = 0;

    [Required]
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorCusto { get; set; } = 0;

    [Required]
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorVenda { get; set; } = 0;

    public bool Destaque { get; set; } = false;

    [StringLength(255)]
    public string Foto { get; set; } = string.Empty;

    // Relação com Categoria
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}