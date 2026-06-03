using System.ComponentModel.DataAnnotations;

namespace ListaDeComprasWeb.ModuloCategoria.Apresentacao.Models;

public record EditarCategoriaViewModel(

    Guid Id,

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(50,
        ErrorMessage = "O nome deve possuir no máximo 50 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "A cor é obrigatória.")]
    string Cor
);