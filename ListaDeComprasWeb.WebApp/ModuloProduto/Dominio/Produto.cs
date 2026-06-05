using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloProduto.Dominio;

public class Produto : EntidadeBase<Produto>
{
    public string Nome { get; set; } = string.Empty;

    public Guid CategoriaId { get; set; }

    public string UnidadeMedida { get; set; } = string.Empty;

    public decimal Preco { get; set; }

    public override void AtualizarRegistro(
        Produto registroEditado)
    {
        Nome = registroEditado.Nome;
        CategoriaId = registroEditado.CategoriaId;
        UnidadeMedida = registroEditado.UnidadeMedida;
        Preco = registroEditado.Preco;
    }
}