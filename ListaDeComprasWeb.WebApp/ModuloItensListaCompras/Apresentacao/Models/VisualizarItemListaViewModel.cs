namespace ListaDeComprasWeb.ModuloItemListaCompras.Apresentacao.Models;

public class VisualizarItemListaViewModel
{
    public Guid Id { get; set; }

    public Guid ListaComprasId { get; set; }

    public string Produto { get; set; } = string.Empty;

    public string Categoria { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal ValorTotal { get; set; }
}