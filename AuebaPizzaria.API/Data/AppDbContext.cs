using AuebaPizzaria.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuebaPizzaria.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "aueba@gmail.com",
                NormalizedEmail = "AUEBA@GMAIL.COM",
                UserName = "AuebaPizzaria@gmail.com",
                NormalizedUserName = "AUEBAPIZZARIA@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Aueba Pizzaria",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            new Categoria { Id = 1, Nome = "Tradicionais", Foto = "tradicionais.png", ExibirHome = true },
            new Categoria { Id = 2, Nome = "Especiais", Foto = "especiais.png", ExibirHome = true },
            new Categoria { Id = 3, Nome = "Veganas", Foto = "veganas.png", ExibirHome = true },
            new Categoria { Id = 4, Nome = "Vegetarianas", Foto = "vegetarianas.png", ExibirHome = false },
            new Categoria { Id = 5, Nome = "Frutos do Mar", Foto = "mar.png", ExibirHome = false },
            new Categoria { Id = 6, Nome = "Premium / Regionais", Foto = "premium.png", ExibirHome = true }
        };

        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto { Id = 1, Nome = "Alcachofra", Descricao = "Pizza com alcachofras selecionadas.", Qtde = 100, ValorVenda = 42.90m, ValorCusto = 21.45m, Destaque = false, CategoriaId = 2, Foto = "alcachofra.png" },
            new Produto { Id = 2, Nome = "Braz", Descricao = "Pizza especial estilo tradicional.", Qtde = 100, ValorVenda = 49.90m, ValorCusto = 24.95m, Destaque = false, CategoriaId = 2, Foto = "braz.png" },
            new Produto { Id = 3, Nome = "Calabresa", Descricao = "Calabresa artesanal com cebola.", Qtde = 100, ValorVenda = 38.90m, ValorCusto = 19.45m, Destaque = true, CategoriaId = 1, Foto = "calabresa.png" },
            new Produto { Id = 4, Nome = "Calabria Vegana", Descricao = "Versão vegana da clássica calabresa.", Qtde = 100, ValorVenda = 44.90m, ValorCusto = 22.45m, Destaque = false, CategoriaId = 3, Foto = "calabria_vegana.png" },
            new Produto { Id = 5, Nome = "Calacheese", Descricao = "Mistura intensa de queijos especiais.", Qtde = 100, ValorVenda = 46.90m, ValorCusto = 23.45m, Destaque = false, CategoriaId = 2, Foto = "calacheese.png" },
            new Produto { Id = 6, Nome = "Canadense", Descricao = "Pizza inspirada nos sabores do Canadá.", Qtde = 100, ValorVenda = 41.90m, ValorCusto = 20.95m, Destaque = false, CategoriaId = 2, Foto = "canadense.png" },
            new Produto { Id = 7, Nome = "Caprese", Descricao = "Muçarela, tomate e manjericão frescos.", Qtde = 100, ValorVenda = 43.90m, ValorCusto = 21.95m, Destaque = false, CategoriaId = 4, Foto = "caprese.png" },
            new Produto { Id = 8, Nome = "Carbonara", Descricao = "Inspirada no clássico italiano Carbonara.", Qtde = 100, ValorVenda = 52.90m, ValorCusto = 26.45m, Destaque = true, CategoriaId = 2, Foto = "carbonara.png" },
            new Produto { Id = 9, Nome = "Carnevale Vegana", Descricao = "Pizza vegana com sabores vibrantes.", Qtde = 100, ValorVenda = 45.90m, ValorCusto = 22.95m, Destaque = false, CategoriaId = 3, Foto = "carnevale_vegana.png" },
            new Produto { Id = 10, Nome = "Casteloes", Descricao = "Pizza clássica portuguesa.", Qtde = 100, ValorVenda = 40.90m, ValorCusto = 20.45m, Destaque = false, CategoriaId = 6, Foto = "casteloes.png" },
            new Produto { Id = 11, Nome = "Da Roca", Descricao = "Ingredientes frescos e naturais da roça.", Qtde = 100, ValorVenda = 42.90m, ValorCusto = 21.45m, Destaque = false, CategoriaId = 6, Foto = "da_roca.png" },
            new Produto { Id = 12, Nome = "Escarola Speciale", Descricao = "Pizza de escarola com toque especial.", Qtde = 100, ValorVenda = 39.90m, ValorCusto = 19.95m, Destaque = false, CategoriaId = 4, Foto = "escarola_speciale.png" },
            new Produto { Id = 13, Nome = "Funghi", Descricao = "Funghi italiano com muçarela premium.", Qtde = 100, ValorVenda = 48.90m, ValorCusto = 24.45m, Destaque = false, CategoriaId = 2, Foto = "funghi.png" },
            new Produto { Id = 14, Nome = "Iberica", Descricao = "Pizza com influência ibérica marcante.", Qtde = 100, ValorVenda = 49.90m, ValorCusto = 24.95m, Destaque = true, CategoriaId = 6, Foto = "iberica.png" },
            new Produto { Id = 15, Nome = "Italianinha", Descricao = "Sabores leves e tradicionais da Itália.", Qtde = 100, ValorVenda = 47.90m, ValorCusto = 23.95m, Destaque = false, CategoriaId = 1, Foto = "italianinha.png" },
            new Produto { Id = 16, Nome = "Jardineira Aliboni", Descricao = "Pizza leve com legumes frescos.", Qtde = 100, ValorVenda = 43.90m, ValorCusto = 21.95m, Destaque = false, CategoriaId = 4, Foto = "jardineira_aliboni.png" },
            new Produto { Id = 17, Nome = "Julienne", Descricao = "Vegetais cortados julienne com especiarias.", Qtde = 100, ValorVenda = 41.90m, ValorCusto = 20.95m, Destaque = false, CategoriaId = 4, Foto = "julienne.png" },
            new Produto { Id = 18, Nome = "Leggera", Descricao = "Pizza leve, ideal para refeições suaves.", Qtde = 100, ValorVenda = 37.90m, ValorCusto = 18.95m, Destaque = false, CategoriaId = 4, Foto = "leggera.png" },
            new Produto { Id = 19, Nome = "Lusa", Descricao = "Pizza portuguesa tradicional.", Qtde = 100, ValorVenda = 42.90m, ValorCusto = 21.45m, Destaque = false, CategoriaId = 1, Foto = "lusa.png" },
            new Produto { Id = 20, Nome = "Mafiosa", Descricao = "Sabor marcante com toque italiano forte.", Qtde = 100, ValorVenda = 52.90m, ValorCusto = 26.45m, Destaque = true, CategoriaId = 2, Foto = "mafiosa.png" },
            new Produto { Id = 21, Nome = "Manhattan", Descricao = "Pizza estilo Nova York.", Qtde = 100, ValorVenda = 49.90m, ValorCusto = 24.95m, Destaque = false, CategoriaId = 6, Foto = "manhattan.png" },
            new Produto { Id = 22, Nome = "Margherita", Descricao = "Clássica margherita com manjericão.", Qtde = 100, ValorVenda = 36.90m, ValorCusto = 18.45m, Destaque = true, CategoriaId = 1, Foto = "margherita.png" },
            new Produto { Id = 23, Nome = "Marinara", Descricao = "Molho de tomate fresco e alho.", Qtde = 100, ValorVenda = 34.90m, ValorCusto = 17.45m, Destaque = false, CategoriaId = 1, Foto = "marinara.png" },
            new Produto { Id = 24, Nome = "Mediterranea", Descricao = "Sabores frescos do mediterrâneo.", Qtde = 100, ValorVenda = 43.90m, ValorCusto = 21.95m, Destaque = false, CategoriaId = 2, Foto = "mediterranea.png" },
            new Produto { Id = 25, Nome = "Mooca", Descricao = "Pizza típica paulistana.", Qtde = 100, ValorVenda = 48.90m, ValorCusto = 24.45m, Destaque = false, CategoriaId = 6, Foto = "mooca.png" },
            new Produto { Id = 26, Nome = "Mucarela", Descricao = "Pizza tradicional de muçarela.", Qtde = 100, ValorVenda = 35.90m, ValorCusto = 17.95m, Destaque = true, CategoriaId = 1, Foto = "mucarela.png" },
            new Produto { Id = 27, Nome = "Netuno", Descricao = "Pizza de frutos do mar selecionados.", Qtde = 100, ValorVenda = 55.90m, ValorCusto = 27.95m, Destaque = true, CategoriaId = 5, Foto = "netuno.png" },
            new Produto { Id = 28, Nome = "Palmito", Descricao = "Pizza clássica com palmito macio.", Qtde = 100, ValorVenda = 40.90m, ValorCusto = 20.45m, Destaque = false, CategoriaId = 4, Foto = "palmito.png" },
            new Produto { Id = 29, Nome = "Parmigiana", Descricao = "Parmegiana adaptada para pizza.", Qtde = 100, ValorVenda = 50.90m, ValorCusto = 25.45m, Destaque = false, CategoriaId = 2, Foto = "parmigiana.png" },
            new Produto { Id = 30, Nome = "Paulistana", Descricao = "Sabor típico da capital paulista.", Qtde = 100, ValorVenda = 46.90m, ValorCusto = 23.45m, Destaque = false, CategoriaId = 6, Foto = "paulistana.png" },
            new Produto { Id = 31, Nome = "Popeye", Descricao = "Pizza de espinafre ao estilo Popeye.", Qtde = 100, ValorVenda = 39.90m, ValorCusto = 19.95m, Destaque = false, CategoriaId = 4, Foto = "popeye.png" },
            new Produto { Id = 32, Nome = "Quatro Queijos", Descricao = "Mistura perfeita de quatro queijos.", Qtde = 100, ValorVenda = 39.90m, ValorCusto = 19.95m, Destaque = true, CategoriaId = 1, Foto = "quatro_queijos.png" },
            new Produto { Id = 33, Nome = "Raschietto", Descricao = "Pizza artesanal com toque rústico.", Qtde = 100, ValorVenda = 47.90m, ValorCusto = 23.95m, Destaque = false, CategoriaId = 2, Foto = "raschietto.png" },
            new Produto { Id = 34, Nome = "Romana", Descricao = "Pizza italiana tradicional romana.", Qtde = 100, ValorVenda = 38.90m, ValorCusto = 19.45m, Destaque = false, CategoriaId = 1, Foto = "romana.png" },
            new Produto { Id = 35, Nome = "Tacchino", Descricao = "Peito de peru com especiarias.", Qtde = 100, ValorVenda = 45.90m, ValorCusto = 22.95m, Destaque = false, CategoriaId = 2, Foto = "tacchino.png" },
            new Produto { Id = 36, Nome = "Tonno e Capparis", Descricao = "Atum e alcaparras ao estilo siciliano.", Qtde = 100, ValorVenda = 56.90m, ValorCusto = 28.45m, Destaque = true, CategoriaId = 5, Foto = "tonno_capparis.png" },
            new Produto { Id = 37, Nome = "Veneto", Descricao = "Pizza rica inspirada no Veneto.", Qtde = 100, ValorVenda = 49.90m, ValorCusto = 24.95m, Destaque = false, CategoriaId = 6, Foto = "veneto.png" }
        };

        builder.Entity<Produto>().HasData(produtos);
    }
}