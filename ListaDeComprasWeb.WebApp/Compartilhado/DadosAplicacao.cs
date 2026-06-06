using ListaDeComprasWeb.ModuloCategoria.Dominio;
using ListaDeComprasWeb.ModuloProduto.Dominio;
using ListaDeComprasWeb.ModuloListaCompras.Dominio;

namespace ListaDeComprasWeb.Compartilhado;

public class DadosAplicacao
{
    public List<Categoria> Categorias { get; set; } = [];

    public List<Produto> Produtos { get; set; } = [];

    public List<ListaCompras> ListasCompras { get; set; } = [];
}