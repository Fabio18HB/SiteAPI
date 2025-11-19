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
    public string Nome { get; set; }

    [StringLength(3000)]
    public string Descricao { get; set; }

    public int Qtde { get; set; }   // Controller usa "Qtde"

    [Column(TypeName = "numeric(10,2)")]
    public decimal ValorCusto { get; set; } // Controller usa isto

    [Column(TypeName = "numeric(10,2)")]
    public decimal ValorVenda { get; set; }

    public bool Destaque { get; set; } = false; // controller usa "Destaque"

    [StringLength(255)]
    public string Foto { get; set; }  // Controller usa Foto

    // Relação com Categoria
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public int QtdeEstoque { get; internal set; }
    public bool ExibirHome { get; internal set; }
}