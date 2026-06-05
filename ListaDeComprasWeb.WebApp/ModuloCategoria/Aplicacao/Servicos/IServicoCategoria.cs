using FluentResults;

using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;

namespace ListaDeComprasWeb.ModuloCategoria.Aplicacao.Servicos;

public interface IServicoCategoria
{
    Result Cadastrar(
        CadastrarCategoriaDto dto);

    Result Editar(
        EditarCategoriaDto dto);

    Result Excluir(
        Guid id);

    CategoriaDto? SelecionarPorId(
        Guid id);

    List<CategoriaDto> SelecionarTodos();
}