using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeComprasWeb.ModuloItensListaCompras.Apresentacao.Models;

public class CadastrarItemListaViewModel
{
    public Guid ListaComprasId { get; set; }

    [Required(ErrorMessage = "Selecione um produto.")]
    public Guid ProdutoId { get; set; }

    [Required(ErrorMessage = "Informe a quantidade.")]
    [Range(1, int.MaxValue,
        ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }

    public List<SelectListItem> Produtos { get; set; } = [];
}