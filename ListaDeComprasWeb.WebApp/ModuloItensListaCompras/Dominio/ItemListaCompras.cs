using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloItemListaCompras.Dominio;

public class ItemListaCompras
    : EntidadeBase<ItemListaCompras>
{
    public Guid ListaComprasId { get; set; }

    public Guid ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public ItemListaCompras(
        Guid listaComprasId,
        Guid produtoId,
        int quantidade)
    {
        Id = Guid.NewGuid();

        ListaComprasId = listaComprasId;

        ProdutoId = produtoId;

        Quantidade = quantidade;
    }

    public override void AtualizarRegistro(
        ItemListaCompras registroEditado)
    {
        ProdutoId = registroEditado.ProdutoId;

        Quantidade = registroEditado.Quantidade;
    }
}