namespace ListaDeComprasWeb.ModuloListaCompras.Aplicacao.DTOs;

public record EditarListaComprasDto(
    Guid Id,
    string Nome,
    string Status
);