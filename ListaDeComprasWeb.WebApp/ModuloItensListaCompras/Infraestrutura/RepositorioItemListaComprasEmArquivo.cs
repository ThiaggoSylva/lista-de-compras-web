using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Compartilhado;
using ListaDeComprasWeb.ModuloItemListaCompras.Dominio;

namespace ListaDeComprasWeb.ModuloItemListaCompras.Infraestrutura;

public class RepositorioItemListaComprasEmArquivo
    : RepositorioBaseEmArquivo<ItemListaCompras>,
      IRepositorioItemListaCompras
{
    public RepositorioItemListaComprasEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<ItemListaCompras> ObterRegistros()
    {
        return contexto.Dados.ItensLista;
    }

    public List<ItemListaCompras> SelecionarPorLista(
        Guid listaId)
    {
        return contexto.Dados.ItensLista
            .Where(x => x.ListaComprasId == listaId)
            .ToList();
    }

    public bool ProdutoJaExisteNaLista(
        Guid listaId,
        Guid produtoId)
    {
        return contexto.Dados.ItensLista
            .Any(x =>
                x.ListaComprasId == listaId &&
                x.ProdutoId == produtoId);
    }

    public bool ProdutoJaExisteNaLista(
        Guid itemId,
        Guid listaId,
        Guid produtoId)
    {
        return contexto.Dados.ItensLista
            .Any(x =>
                x.Id != itemId &&
                x.ListaComprasId == listaId &&
                x.ProdutoId == produtoId);
    }
}