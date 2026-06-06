namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;

public record ProdutoDto(
    Guid Id,
    string Nome,
    Guid CategoriaId,
    string NomeCategoria,
    string UnidadeMedida,
    decimal Preco
);