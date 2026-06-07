using FluentResults;

using ListaDeComprasWeb.ModuloListaCompras.Aplicacao.DTOs;

namespace ListaDeComprasWeb.ModuloListaCompras.Aplicacao.Servicos;

public interface IServicoListaCompras
{
    Result Cadastrar(
        CadastrarListaComprasDto dto);

    Result Editar(
        EditarListaComprasDto dto);

    Result Excluir(
        Guid id);

    ListaComprasDto? SelecionarPorId(
        Guid id);

    List<ListaComprasDto> SelecionarTodos();
}