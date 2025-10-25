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

    [Display(Name = "Exibir na home")]
    public bool ExibirHome {get; set;}
}

