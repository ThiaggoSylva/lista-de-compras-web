namespace ListaDeComprasWeb.Compartilhado;

public class Resultado<T> : Resultado
{
    public T? Dados { get; private set; }

    private Resultado()
    {
    }

    public static Resultado<T> Ok(T dados)
    {
        return new Resultado<T>
        {
            Sucesso = true,
            Dados = dados
        };
    }

    public new static Resultado<T> Falha(string mensagem)
    {
        return new Resultado<T>
        {
            Sucesso = false,
            Mensagem = mensagem
        };
    }
}