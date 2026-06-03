namespace ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;

public record EditarCategoriaDto(
    Guid Id,
    string Nome,
    string Cor
);