namespace ListaDeComprasWeb.ModuloProduto.Apresentacao.Models;

public class VisualizarProdutoViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string NomeCategoria { get; set; } = string.Empty;

    public string UnidadeMedida { get; set; } = string.Empty;

    public decimal Preco { get; set; }
}