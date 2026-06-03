namespace ListaDeComprasWeb.Compartilhado;

public interface IRepositorioBase<T>
{
    void Cadastrar(T registro);

    void Editar(Guid id, T registroEditado);

    void Excluir(Guid id);

    T? SelecionarPorId(Guid id);

    List<T> SelecionarTodos();
}