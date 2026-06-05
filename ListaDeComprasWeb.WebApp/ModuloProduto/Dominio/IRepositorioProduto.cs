using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloProduto.Dominio;

public interface IRepositorioProduto
    : IRepositorioBase<Produto>
{
    bool ExisteProdutoNaCategoria(
        string nome,
        Guid categoriaId);

    bool ExisteProdutoNaCategoria(
        Guid id,
        string nome,
        Guid categoriaId);
}