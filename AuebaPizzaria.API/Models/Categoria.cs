using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AuebaPizzaria.API.Models;

[Table("Categoria")]

public class Categoria {
    [Key]
    public int Id {get; set;}

    [StringLength(50)]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome {get; set;}

    [StringLength(300)]
    public string Foto {get; set;}

    [StringLength(26)]
    public string Cor { get; set; } = "rgba(0,0,0,1)";

    [Display(Name = "Exibir na home")]
    public bool ExibirHome {get; set;}
};