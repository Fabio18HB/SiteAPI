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
        new Produto { Id = 1, Nome = "Alcachofra", Descricao = "Pizza com alcachofras selecionadas.", QtdeEstoque = 100, ValorVenda = 42.90m, ExibirHome = false },
        new Produto { Id = 2, Nome = "Braz", Descricao = "Pizza especial estilo tradicional.", QtdeEstoque = 100, ValorVenda = 49.90m, ExibirHome = false },
        new Produto { Id = 3, Nome = "Calabresa", Descricao = "Calabresa artesanal com cebola.", QtdeEstoque = 100, ValorVenda = 38.90m, ExibirHome = false },
        new Produto { Id = 4, Nome = "Calabria Vegana", Descricao = "Versão vegana da clássica calabresa.", QtdeEstoque = 100, ValorVenda = 44.90m, ExibirHome = false },
        new Produto { Id = 5, Nome = "Calacheese", Descricao = "Mistura intensa de queijos especiais.", QtdeEstoque = 100, ValorVenda = 46.90m, ExibirHome = false },
        new Produto { Id = 6, Nome = "Canadense", Descricao = "Pizza inspirada nos sabores do Canadá.", QtdeEstoque = 100, ValorVenda = 41.90m, ExibirHome = false },
        new Produto { Id = 7, Nome = "Caprese", Descricao = "Muçarela, tomate e manjericão frescos.", QtdeEstoque = 100, ValorVenda = 43.90m, ExibirHome = false },
        new Produto { Id = 8, Nome = "Carbonara", Descricao = "Inspirada no clássico italiano Carbonara.", QtdeEstoque = 100, ValorVenda = 52.90m, ExibirHome = false },
        new Produto { Id = 9, Nome = "Carnevale Vegana", Descricao = "Pizza vegana com sabores vibrantes.", QtdeEstoque = 100, ValorVenda = 45.90m, ExibirHome = false },
        new Produto { Id = 10, Nome = "Casteloes", Descricao = "Pizza clássica portuguesa.", QtdeEstoque = 100, ValorVenda = 40.90m, ExibirHome = false },
        new Produto { Id = 11, Nome = "Da Roca", Descricao = "Ingredientes frescos e naturais da roça.", QtdeEstoque = 100, ValorVenda = 42.90m, ExibirHome = false },
        new Produto { Id = 12, Nome = "Escarola Speciale", Descricao = "Pizza de escarola com toque especial.", QtdeEstoque = 100, ValorVenda = 39.90m, ExibirHome = false },
        new Produto { Id = 13, Nome = "Funghi", Descricao = "Funghi italiano com muçarela premium.", QtdeEstoque = 100, ValorVenda = 48.90m, ExibirHome = false },
        new Produto { Id = 14, Nome = "Iberica", Descricao = "Pizza com influência ibérica marcante.", QtdeEstoque = 100, ValorVenda = 49.90m, ExibirHome = false },
        new Produto { Id = 15, Nome = "Italianinha", Descricao = "Sabores leves e tradicionais da Itália.", QtdeEstoque = 100, ValorVenda = 47.90m, ExibirHome = false },
        new Produto { Id = 16, Nome = "Jardineira Aliboni", Descricao = "Pizza leve com legumes frescos.", QtdeEstoque = 100, ValorVenda = 43.90m, ExibirHome = false },
        new Produto { Id = 17, Nome = "Julienne", Descricao = "Vegetais cortados julienne com especiarias.", QtdeEstoque = 100, ValorVenda = 41.90m, ExibirHome = false },
        new Produto { Id = 18, Nome = "Leggera", Descricao = "Pizza leve, ideal para refeições suaves.", QtdeEstoque = 100, ValorVenda = 37.90m, ExibirHome = false },
        new Produto { Id = 19, Nome = "Lusa", Descricao = "Pizza portuguesa tradicional.", QtdeEstoque = 100, ValorVenda = 42.90m, ExibirHome = false },
        new Produto { Id = 20, Nome = "Mafiosa", Descricao = "Sabor marcante com toque italiano forte.", QtdeEstoque = 100, ValorVenda = 52.90m, ExibirHome = false },
        new Produto { Id = 21, Nome = "Manhattan", Descricao = "Pizza estilo Nova York.", QtdeEstoque = 100, ValorVenda = 49.90m, ExibirHome = false },
        new Produto { Id = 22, Nome = "Margherita", Descricao = "Clássica margherita com manjericão.", QtdeEstoque = 100, ValorVenda = 36.90m, ExibirHome = false },
        new Produto { Id = 23, Nome = "Marinara", Descricao = "Molho de tomate fresco e alho.", QtdeEstoque = 100, ValorVenda = 34.90m, ExibirHome = false },
        new Produto { Id = 24, Nome = "Mediterranea", Descricao = "Sabores frescos do mediterrâneo.", QtdeEstoque = 100, ValorVenda = 43.90m, ExibirHome = false },
        new Produto { Id = 25, Nome = "Mooca", Descricao = "Pizza típica paulistana.", QtdeEstoque = 100, ValorVenda = 48.90m, ExibirHome = false },
        new Produto { Id = 26, Nome = "Mucarela", Descricao = "Pizza tradicional de muçarela.", QtdeEstoque = 100, ValorVenda = 35.90m, ExibirHome = false },
        new Produto { Id = 27, Nome = "Netuno", Descricao = "Pizza de frutos do mar selecionados.", QtdeEstoque = 100, ValorVenda = 55.90m, ExibirHome = false },
        new Produto { Id = 28, Nome = "Palmito", Descricao = "Pizza clássica com palmito macio.", QtdeEstoque = 100, ValorVenda = 40.90m, ExibirHome = false },
        new Produto { Id = 29, Nome = "Parmigiana", Descricao = "Parmegiana adaptada para pizza.", QtdeEstoque = 100, ValorVenda = 50.90m, ExibirHome = false },
        new Produto { Id = 30, Nome = "Paulistana", Descricao = "Sabor típico da capital paulista.", QtdeEstoque = 100, ValorVenda = 46.90m, ExibirHome = false },
        new Produto { Id = 31, Nome = "Popeye", Descricao = "Pizza de espinafre ao estilo Popeye.", QtdeEstoque = 100, ValorVenda = 39.90m, ExibirHome = false },
        new Produto { Id = 32, Nome = "Quatro Queijos", Descricao = "Mistura perfeita de quatro queijos.", QtdeEstoque = 100, ValorVenda = 39.90m, ExibirHome = false },
        new Produto { Id = 33, Nome = "Raschietto", Descricao = "Pizza artesanal com toque rústico.", QtdeEstoque = 100, ValorVenda = 47.90m, ExibirHome = false },
        new Produto { Id = 34, Nome = "Romana", Descricao = "Pizza italiana tradicional romana.", QtdeEstoque = 100, ValorVenda = 38.90m, ExibirHome = false },
        new Produto { Id = 35, Nome = "Tacchino", Descricao = "Peito de peru com especiarias.", QtdeEstoque = 100, ValorVenda = 45.90m, ExibirHome = false },
        new Produto { Id = 36, Nome = "Tonno e Capparis", Descricao = "Atum e alcaparras ao estilo siciliano.", QtdeEstoque = 100, ValorVenda = 56.90m, ExibirHome = false },
        new Produto { Id = 37, Nome = "Veneto", Descricao = "Pizza rica inspirada no Veneto.", QtdeEstoque = 100, ValorVenda = 49.90m, ExibirHome = false }
    };

        builder.Entity<Produto>().HasData(produtos);
    }

};