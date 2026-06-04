using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloProduto.Dominio;

public interface IRepositorioProduto
    : IRepositorioBase<Produto>
{
    bool ExisteNome(
        string nome,
        Guid categoriaId);

    bool ExisteNome(
        Guid id,
        string nome,
        Guid categoriaId);
}