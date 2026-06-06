using System.ComponentModel.DataAnnotations;

namespace ListaDeComprasWeb.ModuloListaCompras.Apresentacao.Models;

public class EditarListaComprasViewModel
{
    public Guid Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = string.Empty;
}