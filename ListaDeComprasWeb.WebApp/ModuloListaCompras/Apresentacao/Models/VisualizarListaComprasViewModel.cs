namespace ListaDeComprasWeb.ModuloListaCompras.Apresentacao.Models;

public class VisualizarListaComprasViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public DateTime DataCriacao { get; set; }

    public string Status { get; set; } = string.Empty;

    public int TotalItens { get; set; }

    public decimal ValorTotal { get; set; }
}