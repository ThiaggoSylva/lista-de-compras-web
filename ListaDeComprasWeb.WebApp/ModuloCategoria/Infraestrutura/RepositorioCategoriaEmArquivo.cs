using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Dominio;
using ListaDeComprasWeb.WebApp.ModuloCategoria.Compartilhado;

namespace ListaDeComprasWeb.WebApp.ModuloCategoria.Infraestrutura;

public class RepositorioCategoriaEmArquivo
    : RepositorioBaseEmArquivo<Categoria>,
      IRepositorioCategoria
{
    public RepositorioCategoriaEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<Categoria> ObterRegistros()
    {
        return contexto.Categorias;
    }

    public bool ExisteNome(string nome)
    {
        return contexto.Categorias
            .Any(x =>
                x.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool PossuiProdutos(Guid categoriaId)
    {
        return false;
    }
}