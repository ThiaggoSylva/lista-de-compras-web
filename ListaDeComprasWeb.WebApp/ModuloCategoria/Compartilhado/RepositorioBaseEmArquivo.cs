namespace ListaDeComprasWeb.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T>
    : IRepositorioBase<T>
    where T : EntidadeBase<T>
{
    protected readonly ContextoJson contexto;

    protected RepositorioBaseEmArquivo(ContextoJson contexto)
    {
        this.contexto = contexto;
    }

    protected abstract List<T> ObterRegistros();

    public virtual void Cadastrar(T registro)
    {
        ObterRegistros().Add(registro);

        contexto.Salvar();
    }

    public virtual void Editar(Guid id, T registroEditado)
    {
        T? registro = SelecionarPorId(id);

        if (registro is null)
            return;

        registro.AtualizarRegistro(registroEditado);

        contexto.Salvar();
    }

    public virtual void Excluir(Guid id)
    {
        T? registro = SelecionarPorId(id);

        if (registro is null)
            return;

        ObterRegistros().Remove(registro);

        contexto.Salvar();
    }

    public virtual T? SelecionarPorId(Guid id)
    {
        return ObterRegistros()
            .FirstOrDefault(x => x.Id == id);
    }

    public virtual List<T> SelecionarTodos()
    {
        return ObterRegistros()
            .OrderBy(x => x.Id)
            .ToList();
    }
}