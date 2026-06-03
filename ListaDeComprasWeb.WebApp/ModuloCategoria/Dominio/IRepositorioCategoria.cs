using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloCategoria.Dominio;

public interface IRepositorioCategoria
    : IRepositorioBase<Categoria>
{
    bool ExisteNome(string nome);

    bool ExisteNome(Guid id, string nome);

    bool PossuiProdutos(Guid categoriaId);
}