namespace ListaDeComprasWeb.ModuloListaCompras.Dominio;

public interface IRepositorioListaCompras
    : IRepositorioBase<ListaCompras>
{
    bool ExisteNome(string nome);

    bool ExisteNome(
        Guid id,
        string nome);

    bool PossuiItens(Guid listaId);

    int ObterTotalItens(Guid listaId);

    decimal ObterValorTotal(Guid listaId);
}