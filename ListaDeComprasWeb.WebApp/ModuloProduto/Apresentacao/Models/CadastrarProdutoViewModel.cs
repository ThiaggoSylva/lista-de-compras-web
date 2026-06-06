using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeComprasWeb.ModuloProduto.Apresentacao.Models;

public class CadastrarProdutoViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2)]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    public Guid CategoriaId { get; set; }

    [Required(ErrorMessage = "A unidade de medida é obrigatória.")]
    public string UnidadeMedida { get; set; } = string.Empty;

    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, double.MaxValue)]
    public decimal PrecoAproximado { get; set; }

    public List<SelectListItem> Categorias { get; set; }
        = [];
}