using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Dominio;

namespace ListaDeComprasWeb.ModuloCategoria.Infraestrutura;

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
        return contexto.Dados.Categorias;
    }

    public bool ExisteNome(string nome)
    {
        return contexto.Dados.Categorias
            .Any(c => c.Nome.Equals(
                nome,
                StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteNome(
        Guid id,
        string nome)
    {
        return contexto.Dados.Categorias
            .Any(c =>
                c.Id != id &&
                c.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool PossuiProdutos(Guid categoriaId)
    {
        return contexto.Dados.Produtos
            .Any(p => p.CategoriaId == categoriaId);
    }
}