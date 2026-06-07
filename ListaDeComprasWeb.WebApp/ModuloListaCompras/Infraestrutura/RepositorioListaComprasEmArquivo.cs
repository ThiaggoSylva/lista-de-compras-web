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
        return false;
    }

    public int ObterTotalItens(Guid listaId)
    {
        return 0;
    }

    public decimal ObterValorTotal(Guid listaId)
    {
        return 0;
    }
}