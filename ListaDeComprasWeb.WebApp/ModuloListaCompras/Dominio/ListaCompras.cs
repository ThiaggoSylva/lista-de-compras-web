using ListaDeComprasWeb.Compartilhado;

namespace ListaDeComprasWeb.ModuloListaCompras.Dominio;

public class ListaCompras : EntidadeBase<ListaCompras>
{
    public string Nome { get; set; }

    public DateTime DataCriacao { get; set; }

    public string Status { get; set; }

    public ListaCompras(
        string nome)
    {
        Id = Guid.NewGuid();

        Nome = nome;

        DataCriacao = DateTime.Now;

        Status = "Aberta";
    }

    public override void AtualizarRegistro(
        ListaCompras registroEditado)
    {
        Nome = registroEditado.Nome;

        Status = registroEditado.Status;
    }
}