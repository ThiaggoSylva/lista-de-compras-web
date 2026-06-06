namespace ListaDeComprasWeb.ModuloListaCompras.Aplicacao.DTOs;

public record ListaComprasDto(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    string Status,
    int TotalItens,
    decimal ValorTotal
);