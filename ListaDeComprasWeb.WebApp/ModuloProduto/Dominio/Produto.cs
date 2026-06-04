using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloProduto.Dominio;

public class Produto : EntidadeBase<Produto>
{
    public string Nome { get; set; }

    public Guid CategoriaId { get; set; }

    public string UnidadeMedida { get; set; }

    public decimal PrecoAproximado { get; set; }

    public Produto()
    {
    }

    public Produto(
        string nome,
        Guid categoriaId,
        string unidadeMedida,
        decimal precoAproximado)
    {
        Id = Guid.NewGuid();

        Nome = nome;
        CategoriaId = categoriaId;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }

    public override void AtualizarRegistro(
        Produto registroEditado)
    {
        Nome = registroEditado.Nome;
        CategoriaId = registroEditado.CategoriaId;
        UnidadeMedida = registroEditado.UnidadeMedida;
        PrecoAproximado = registroEditado.PrecoAproximado;
    }
}