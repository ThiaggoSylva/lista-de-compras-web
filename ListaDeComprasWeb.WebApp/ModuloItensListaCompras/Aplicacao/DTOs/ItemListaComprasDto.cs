namespace ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.DTOs;

public record ItemListaComprasDto(
    Guid Id,
    Guid ListaComprasId,
    Guid ProdutoId,
    string Produto,
    string Categoria,
    int Quantidade,
    decimal PrecoUnitario,
    decimal ValorTotal
);