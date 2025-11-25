using AuebaPizzaria.UI.DTOs;

namespace AuebaPizzaria.UI.ViewModels;

public class HomeVM
{
    public List<CategoriaDto> Categorias { get; set; } = new();
    public List<ProdutoDto> ProdutosDestaque { get; set; } = new();
}