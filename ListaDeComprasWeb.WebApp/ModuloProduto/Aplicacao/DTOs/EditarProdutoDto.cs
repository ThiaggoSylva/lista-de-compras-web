namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;

public record EditarProdutoDto(
    Guid Id,
    string Nome,
    Guid CategoriaId,
    string UnidadeMedida,
    decimal PrecoAproximado);