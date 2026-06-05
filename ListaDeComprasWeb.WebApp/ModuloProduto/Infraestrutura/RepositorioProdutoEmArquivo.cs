using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Compartilhado;
using ListaDeComprasWeb.ModuloProduto.Dominio;

namespace ListaDeComprasWeb.ModuloProduto.Infraestrutura;

public class RepositorioProdutoEmArquivo
    : RepositorioBaseEmArquivo<Produto>,
      IRepositorioProduto
{
    public RepositorioProdutoEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<Produto> ObterRegistros()
    {
        return contexto.Dados.Produtos;
    }

    public bool ExisteProdutoNaCategoria(
        string nome,
        Guid categoriaId)
    {
        return contexto.Dados.Produtos
            .Any(x =>
                x.CategoriaId == categoriaId &&
                x.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteProdutoNaCategoria(
        Guid id,
        string nome,
        Guid categoriaId)
    {
        return contexto.Dados.Produtos
            .Any(x =>
                x.Id != id &&
                x.CategoriaId == categoriaId &&
                x.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }
}