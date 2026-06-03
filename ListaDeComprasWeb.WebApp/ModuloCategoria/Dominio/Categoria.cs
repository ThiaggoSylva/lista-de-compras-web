using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloCategoria.Dominio;

public class Categoria : EntidadeBase<Categoria>
{
    public string Nome { get; private set; }

    public string Cor { get; private set; }

    public Categoria(
        string nome,
        string cor)
    {
        Id = Guid.NewGuid();

        Nome = nome;
        Cor = cor;
    }

    public override void AtualizarRegistro(
        Categoria registroEditado)
    {
        Nome = registroEditado.Nome;
        Cor = registroEditado.Cor;
    }
}