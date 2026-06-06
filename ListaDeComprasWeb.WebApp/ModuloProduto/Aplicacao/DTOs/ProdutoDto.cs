namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;

public record ProdutoDto(
    Guid Id,
    string Nome,
    Guid CategoriaId,
    string UnidadeMedida,
    decimal Preco
);