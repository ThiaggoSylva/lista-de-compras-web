using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Compartilhado;
using ListaDeComprasWeb.ModuloListaCompras.Dominio;

namespace ListaDeComprasWeb.ModuloListaCompras.Infraestrutura;

public class RepositorioListaComprasEmArquivo
    : RepositorioBaseEmArquivo<ListaCompras>,
      IRepositorioListaCompras
{
    public RepositorioListaComprasEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<ListaCompras> ObterRegistros()
    {
        return contexto.Dados.ListasCompras;
    }

    public bool ExisteNome(string nome)
    {
        return contexto.Dados.ListasCompras
            .Any(x =>
                x.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteNome(
        Guid id,
        string nome)
    {
        return contexto.Dados.ListasCompras
            .Any(x =>
                x.Id != id &&
                x.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool PossuiItens(Guid listaId)
    {
        return contexto.Dados.ItensLista
        .Any(x => x.ListaComprasId == listaId);
    }

    public int ObterTotalItens(Guid listaId)
    {
        return contexto.Dados.ItensLista
        .Where(x => x.ListaComprasId == listaId)
        .Sum(x => x.Quantidade);
    }

    public decimal ObterValorTotal(Guid listaId)
    {
    var itens =
        contexto.Dados.ItensLista
            .Where(x => x.ListaComprasId == listaId);

    decimal total = 0;

    foreach (var item in itens)
    {
        var produto =
            contexto.Dados.Produtos
                .FirstOrDefault(x =>
                    x.Id == item.ProdutoId);

        if (produto is null)
            continue;

        total +=
            produto.Preco *
            item.Quantidade;
    }

    return total;
    }
}