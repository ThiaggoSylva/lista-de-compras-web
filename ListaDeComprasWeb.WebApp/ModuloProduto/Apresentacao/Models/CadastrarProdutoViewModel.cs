using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeComprasWeb.ModuloProduto.Apresentacao.Models;

public class CadastrarProdutoViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public Guid CategoriaId { get; set; }

    [Required]
    public string UnidadeMedida { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 999999)]
    public decimal PrecoAproximado { get; set; }

    public List<SelectListItem> Categorias { get; set; } = [];
}