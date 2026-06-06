using System.ComponentModel.DataAnnotations;

namespace ListaDeComprasWeb.ModuloListaCompras.Apresentacao.Models;

public class CadastrarListaComprasViewModel
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
}