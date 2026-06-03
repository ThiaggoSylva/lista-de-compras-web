using System.Text.Json;

namespace ListaDeComprasWeb.Compartilhado;

public class ContextoJson
{
    private readonly string caminhoArquivo;

    public DadosAplicacao Dados { get; private set; }

    public ContextoJson()
    {
        string pastaAplicacao =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "ListaDeComprasWeb");

        Directory.CreateDirectory(pastaAplicacao);

        caminhoArquivo =
            Path.Combine(
                pastaAplicacao,
                "dados.json");

        Dados = new DadosAplicacao();
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
        {
            Salvar();

            return;
        }

        string json =
            File.ReadAllText(caminhoArquivo);

        if (string.IsNullOrWhiteSpace(json))
        {
            Dados = new DadosAplicacao();

            return;
        }

        Dados =
            JsonSerializer.Deserialize<DadosAplicacao>(json)!
            ?? new DadosAplicacao();
    }

    public void Salvar()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };

        string json =
            JsonSerializer.Serialize(
                Dados,
                options);

        File.WriteAllText(
            caminhoArquivo,
            json);
    }
}