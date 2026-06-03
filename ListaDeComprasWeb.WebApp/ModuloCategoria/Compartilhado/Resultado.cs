namespace ListaDeComprasWeb.Compartilhado;

public class Resultado
{
    public bool Sucesso { get; protected set; }

    public string Mensagem { get; protected set; } = string.Empty;

    protected Resultado()
    {
    }

    public static Resultado Ok()
    {
        return new Resultado
        {
            Sucesso = true
        };
    }

    public static Resultado Falha(string mensagem)
    {
        return new Resultado
        {
            Sucesso = false,
            Mensagem = mensagem
        };
    }
}