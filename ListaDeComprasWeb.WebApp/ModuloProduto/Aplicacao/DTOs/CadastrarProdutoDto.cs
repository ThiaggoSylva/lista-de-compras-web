namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;

public record CadastrarProdutoDto(
    string Nome,
    Guid CategoriaId,
    string UnidadeMedida,
    decimal PrecoAproximado);