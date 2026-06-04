using ListaDeComprasWeb.ModuloCategoria.Dominio;
using ListaDeComprasWeb.ModuloProduto.Dominio;

namespace ListaDeComprasWeb.Compartilhado;

public class DadosAplicacao
{
    public List<Categoria> Categorias { get; set; } = [];

    public List<Produto> Produtos { get; set; } = [];
}