namespace ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.DTOs;

public record CadastrarItemListaDto(
    Guid ListaComprasId,
    Guid ProdutoId,
    int Quantidade
);