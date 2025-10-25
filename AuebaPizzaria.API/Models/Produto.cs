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
    public string Foto {get; set;}

    [Display(Name = "Exibir na home")]
    public bool ExibirHome {get; set;}
}




