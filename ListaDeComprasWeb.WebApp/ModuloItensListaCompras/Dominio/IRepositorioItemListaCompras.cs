namespace ListaDeComprasWeb.ModuloItensListaCompras.Dominio;

public interface IRepositorioItemListaCompras
    : IRepositorioBase<ItemListaCompras>
{
    List<ItemListaCompras> SelecionarPorLista(
        Guid listaId);

    bool ProdutoJaExisteNaLista(
        Guid listaId,
        Guid produtoId);

    bool ProdutoJaExisteNaLista(
        Guid itemId,
        Guid listaId,
        Guid produtoId);
}