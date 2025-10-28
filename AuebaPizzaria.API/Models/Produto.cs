using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AuebaPizzaria.API.Models;

[Table("Produto")]

public class Produto
{
    [Key]
    public int Id {get; set;}

    [StringLength(100)]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome{get; set;}

    [StringLength(3000)]
    [Display(Name = "Descrição")]
    public string Descricao {get; set;}

    [Display(Name = "Quantidade em estoque")]
    [Required(ErrorMessage ="Por favor, informe a quantidade em estoque")]
    [Range(0, int.MaxValue)]
    public int QtdeEstoque {get; set;}

    [Display(Name ="Valor de Venda")]
    [Required(ErrorMessage = "Por favor, informe o valor de venda")]
    [Range(0, double.MaxValue)]
    [Column(TypeName ="numeric(10,2)")]
    public decimal ValorVenda {get; set;}
      
    public bool ExibirHome {get; set;} = false;
    public List<Produto> Fotos {get; set;}
}




