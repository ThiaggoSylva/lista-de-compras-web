namespace ListaDeComprasWeb.ModuloItensListaCompras.Apresentacao.Models;

public class VisualizarItensListaViewModel
{
    public Guid ListaComprasId { get; set; }

    public string NomeLista { get; set; } = string.Empty;

    public decimal ValorTotalLista { get; set; }

    public List<VisualizarItemListaViewModel> Itens { get; set; } = [];
}